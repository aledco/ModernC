using Antlr4.Runtime.Tree.Xpath;
using Compiler.ErrorHandling;
using Compiler.Models;
using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Operators;
using Compiler.Models.Tree;
using VirtualMachine;
using VirtualMachine.Instructions;

namespace Compiler.TreeWalking.CodeGeneration.VirtualMachine
{
    /// <summary>
    /// Generates code for the virtual machine.
    /// </summary>
    public static class CodeGenerator
    {
        private static int _labelId = 0;
        private static int GetNextLabelId()
        {
            _labelId++;
            return _labelId;
        }

        public static List<IInstruction> Walk(ProgramRoot program)
        {
            AssignRegistersAndOffsets.Walk(program);
            return VisitProgramRoot(program);
        }

        private static List<IInstruction> VisitProgramRoot(ProgramRoot program)
        {
            var instructions = program.GlobalStatements
                .SelectMany(VisitStatement)
                .ToList(); // TODO make data section to put declarations in

            instructions.AddRange(new IInstruction[]
            {
                new Blank(),
                new Call(ProgramRoot.MainFunctionLabel),
                new Jump(ProgramRoot.ExitLabel),
                new Blank(),
            });

            instructions.AddRange(program.FunctionDefinitions.SelectMany(VisitFunctionDefinition));
            instructions.Add(new Label(ProgramRoot.ExitLabel));
            return instructions;
        }

        private static List<IInstruction> VisitFunctionDefinition(FunctionDefinition function)
        {
            // function prologue
            var instructions = new List<IInstruction>()
            {
                new Label(function.EnterLabel),
                new Store(Registers.StackPointer, Registers.ReturnAddress, 0),
                new Store(Registers.StackPointer, Registers.FramePointer, 1),
                new Store(Registers.StackPointer, Registers.StackPointer, 2),
                new Move(Registers.FramePointer, Registers.StackPointer),
                new AddImmediate(Registers.StackPointer, Registers.FramePointer, function.Size + 3 + function.RegisterPool.Count)
            };

            // save callees registers
            for (var i = 0; i < function.RegisterPool.Count; i++)
            {
                instructions.Add(new Store(Registers.StackPointer, function.RegisterPool[i], -i - 1));
            }

            // emit code for function body
            instructions.AddRange(VisitCompoundStatement(function.Body));


            // function epilogue
            instructions.Add(new Label(function.ReturnLabel));

            // restore callees registers
            for (var i = 0; i < function.RegisterPool.Count; i++)
            {
                instructions.Add(new Load(function.RegisterPool[i], Registers.StackPointer, -i - 1));
            }

            // restore SP, FP, RA
            instructions.AddRange(new IInstruction[]
            {
                new Load(Registers.StackPointer, Registers.FramePointer, 2),
                new Load(Registers.FramePointer, Registers.FramePointer, 1),
                new Load(Registers.ReturnAddress, Registers.StackPointer, 0),
                new JumpIndirect(Registers.ReturnAddress)
            });

            return instructions;
        }

        private static List<IInstruction> VisitCompoundStatement(CompoundStatement compoundStatement)
        {
            return compoundStatement.Statements.SelectMany(VisitStatement).ToList();
        }

        private static List<IInstruction> VisitStatement(Statement statement)
        {
            return statement switch
            {
                PrintStatement s => VisitPrintStatement(s),
                PrintLineStatement s => VisitPrintLineStatement(s),
                VariableDefinitionStatement s => VisitVariableDefinitionStatement(s),
                AssignmentStatement s => VisitAssignmentStatement(s),
                IncrementStatement s => VisitIncrementStatement(s),
                VariableDefinitionAndAssignmentStatement s => VisitVariableDefinitionAndAssignmentStatement(s),
                CallStatement s => VisitCallStatement(s),
                IfStatement s => VisitIfStatement(s),
                WhileStatement s => VisitWhileStatement(s),
                DoWhileStatement s => VisitDoWhileStatement(s),
                ForStatement s => VisitForStatement(s),
                BreakStatement s => VisitBreakStatement(s),
                ContinueStatement s => VisitContinueStatement(s),
                ReturnStatement s => VisitReturnStatement(s),
                ExitStatement s => VisitExitStatement(s),
                CompoundStatement s => VisitCompoundStatement(s),
                _ => throw new NotImplementedException($"Unknown statement {statement}"),
            };
        }

        private static List<IInstruction> VisitPrintStatement(PrintStatement s)
        {
            if (s.Expression is ComplexLiteralExpression)
            {
                ErrorHandler.Throw("Printing complex literals is not supported, store in a variable then print the variable", s);
            }

            var instructions = new List<IInstruction>();
            switch (s.Expression.Type)
            {
                case IntType:
                    instructions.AddRange(ExpressionRValue(s.Expression));
                    instructions.Add(new PrintInt(s.Expression.Register));
                    break;
                case ByteType:
                    instructions.AddRange(ExpressionRValue(s.Expression));
                    instructions.Add(new PrintByte(s.Expression.Register));
                    break;
                case FloatType:
                    instructions.AddRange(ExpressionRValue(s.Expression));
                    instructions.Add(new PrintFloat(s.Expression.Register));
                    break;
                case BoolType:
                    instructions.AddRange(ExpressionRValue(s.Expression));
                    instructions.Add(new PrintBool(s.Expression.Register));
                    break;
                case StructType t:
                    var definition = SymbolTable.LookupDefinition(t) as StructDefinition;
                    instructions.AddRange(ExpressionLValue(s.Expression));
                    instructions.AddRange(PrintStruct(s.Expression.Register, definition!, s.Span));
                    break;
                case PointerType:
                case FunctionType:
                    instructions.AddRange(ExpressionRValue(s.Expression));
                    instructions.Add(new PrintPointer(s.Expression.Register));
                    break;
                default:
                    ErrorHandler.Throw("Cannot print expression", s);
                    break;
            }
            
            return instructions;
        }

        private static IList<IInstruction> PrintSpaces(int spaces)
        {
            var instructions = new List<IInstruction>();
            for (int i = 0; i < spaces; i++)
            {
                instructions.Add(new LoadImmediate(Registers.Temporary, ' '));
                instructions.Add(new PrintByte(Registers.Temporary));
            }

            return instructions;
        }

        private static IList<IInstruction> PrintStruct(string lvalRegister, StructDefinition definition, Span span, int spaces = 0)
        {

            var instructions = new List<IInstruction>();
            foreach (var c in definition.Type.ToSemanticType().Value)
            {
                instructions.Add(new LoadImmediate(Registers.Temporary, c));
                instructions.Add(new PrintByte(Registers.Temporary));
            }

            instructions.Add(new LoadImmediate(Registers.Temporary, ' '));
            instructions.Add(new PrintByte(Registers.Temporary));
            instructions.Add(new LoadImmediate(Registers.Temporary, '{'));
            instructions.Add(new PrintByte(Registers.Temporary));
            instructions.Add(new LoadImmediate(Registers.Temporary, '\n'));
            instructions.Add(new PrintByte(Registers.Temporary));

            foreach (var field in definition.Fields)
            {
                instructions.AddRange(PrintSpaces(spaces + 4));
                foreach (var c in field.Id.Value)
                {
                    instructions.Add(new LoadImmediate(Registers.Temporary, c));
                    instructions.Add(new PrintByte(Registers.Temporary));
                }

                instructions.Add(new LoadImmediate(Registers.Temporary, ' '));
                instructions.Add(new PrintByte(Registers.Temporary));
                instructions.Add(new LoadImmediate(Registers.Temporary, '='));
                instructions.Add(new PrintByte(Registers.Temporary));
                instructions.Add(new LoadImmediate(Registers.Temporary, ' '));
                instructions.Add(new PrintByte(Registers.Temporary));

                switch (field.Type.ToSemanticType())
                {
                    case IntType:
                        instructions.Add(new Load(Registers.Temporary, lvalRegister, field.Offset));
                        instructions.Add(new PrintInt(Registers.Temporary));
                        break;
                    case ByteType:
                        instructions.Add(new Load(Registers.Temporary, lvalRegister, field.Offset));
                        instructions.Add(new PrintByte(Registers.Temporary));
                        break;
                    case FloatType:
                        instructions.Add(new Load(Registers.Temporary, lvalRegister, field.Offset));
                        instructions.Add(new PrintFloat(Registers.Temporary));
                        break;
                    case BoolType:
                        instructions.Add(new Load(Registers.Temporary, lvalRegister, field.Offset));
                        instructions.Add(new PrintBool(Registers.Temporary));
                        break;
                    case StructType t:
                        var fieldDefiniton = SymbolTable.LookupDefinition(t) as StructDefinition;
                        instructions.Add(new AddImmediate(lvalRegister, lvalRegister, field.Offset));
                        instructions.AddRange(PrintStruct(lvalRegister, fieldDefiniton!, span, spaces + field.Id.Value.Length + 7));
                        instructions.Add(new AddImmediate(lvalRegister, lvalRegister, -field.Offset));
                        break;
                    case FunctionType:
                        instructions.Add(new Load(Registers.Temporary, lvalRegister, field.Offset));
                        instructions.Add(new PrintPointer(Registers.Temporary));
                        break;
                    default:
                        ErrorHandler.Throw("Cannot print expression", span);
                        break;
                }

                instructions.Add(new LoadImmediate(Registers.Temporary, ','));
                instructions.Add(new PrintByte(Registers.Temporary));
                instructions.Add(new LoadImmediate(Registers.Temporary, '\n'));
                instructions.Add(new PrintByte(Registers.Temporary));
            }

            instructions.AddRange(PrintSpaces(spaces));
            instructions.Add(new LoadImmediate(Registers.Temporary, '}'));
            instructions.Add(new PrintByte(Registers.Temporary));
            return instructions;
        }

        private static List<IInstruction> VisitPrintLineStatement(PrintLineStatement s)
        {
            var instructions = VisitPrintStatement(s.PrintExpression);
            instructions.AddRange(VisitPrintStatement(s.PrintLine));
            return instructions;
        }

        private static List<IInstruction> VisitVariableDefinitionStatement(VariableDefinitionStatement s)
        {
            if (s.Id.Symbol == null)
            {
                throw new Exception("Symbol was null");
            }

            var instructions = new List<IInstruction>();
            if (s.Type is UserDefinedTypeNode userDefinedTypeNode)
            {
                var definition = SymbolTable.LookupDefinition(userDefinedTypeNode);
                switch (definition) 
                {
                    case StructDefinition d:
                        if (s.Id.Symbol.IsGlobal)
                        {
                            instructions.Add(new DeclareGlobal(s.Id.Symbol.Name, s.Id.Symbol.Type.GetSizeInWords()));
                        }

                        foreach (var field in d.Fields)
                        {
                            if (field.DefaultExpression != null)
                            {
                                instructions.AddRange(ExpressionRValue(field.DefaultExpression));
                                if (s.Id.Symbol.IsGlobal)
                                {
                                    instructions.Add(new LoadLabel(Registers.Temporary, s.Id.Symbol.Name));
                                    instructions.Add(new Store(Registers.Temporary, field.DefaultExpression.Register, field.Offset));
                                }
                                else
                                {
                                    instructions.Add(new Store(Registers.FramePointer, field.DefaultExpression.Register, s.Id.Symbol.Offset + field.Offset));
                                }
                            }
                        }
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            else if (s.Id.Symbol.IsGlobal)
            {
                instructions.Add(new DeclareGlobal(s.Id.Symbol.Name, s.Id.Symbol.Type.GetSizeInWords()));
            }

            return instructions;
        }

        private static List<IInstruction> VisitAssignmentStatement(AssignmentStatement s)
        {
            var instructions = new List<IInstruction>();
            instructions.AddRange(ExpressionRValue(s.Right));
            switch (s.Operator)
            {
                case AssignmentOperator.Equals:
                    instructions.AddRange(ExpressionLValue(s.Left));
                    break;
                case AssignmentOperator.PlusEquals:
                    instructions.AddRange(ExpressionRValue(s.Left));
                    switch (s.Left.Type)
                    {
                        case IntegralType or BoolType:
                            instructions.Add(new Add(s.Right.Register, s.Left.Register, s.Right.Register));
                            break;
                        case RealType:
                            instructions.Add(new AddFloat(s.Right.Register, s.Left.Register, s.Right.Register));
                            break;
                        default:
                            throw new Exception($"Invalid type: {s.Left.Type}");
                    }
                   
                    instructions.AddRange(ExpressionLValue(s.Left));
                    break;
                case AssignmentOperator.MinusEquals:
                    instructions.AddRange(ExpressionRValue(s.Left));
                    switch (s.Left.Type)
                    {
                        case IntegralType or BoolType:
                            instructions.Add(new Negate(s.Right.Register, s.Right.Register));
                            instructions.Add(new Add(s.Right.Register, s.Left.Register, s.Right.Register));
                            break;
                        case RealType:
                            instructions.Add(new NegateFloat(s.Right.Register, s.Right.Register));
                            instructions.Add(new AddFloat(s.Right.Register, s.Left.Register, s.Right.Register));
                            break;
                        default:
                            throw new Exception($"Invalid type: {s.Left.Type}");
                    }

                    instructions.AddRange(ExpressionLValue(s.Left));
                    break;
                case AssignmentOperator.TimesEquals:
                    instructions.AddRange(ExpressionRValue(s.Left));
                    switch (s.Left.Type)
                    {
                        case IntegralType or BoolType:
                            instructions.Add(new Multiply(s.Right.Register, s.Left.Register, s.Right.Register));
                            break;
                        case RealType:
                            instructions.Add(new MultiplyFloat(s.Right.Register, s.Left.Register, s.Right.Register));
                            break;
                        default:
                            throw new Exception($"Invalid type: {s.Left.Type}");
                    }

                    instructions.AddRange(ExpressionLValue(s.Left));
                    break;
                case AssignmentOperator.DividedByEquals:
                    instructions.AddRange(ExpressionRValue(s.Left));
                    switch (s.Left.Type)
                    {
                        case IntegralType or BoolType:
                            instructions.Add(new Divide(s.Right.Register, s.Left.Register, s.Right.Register));
                            break;
                        case RealType:
                            instructions.Add(new DivideFloat(s.Right.Register, s.Left.Register, s.Right.Register));
                            break;
                        default:
                            throw new Exception($"Invalid type: {s.Left.Type}");
                    }

                    instructions.AddRange(ExpressionLValue(s.Left));
                    break;
                case AssignmentOperator.ModuloEquals:
                    instructions.AddRange(ExpressionRValue(s.Left));
                    switch (s.Left.Type)
                    {
                        case IntegralType or BoolType:
                            instructions.Add(new Modulo(s.Right.Register, s.Left.Register, s.Right.Register));
                            break;
                        case RealType:
                            instructions.Add(new ModuloFloat(s.Right.Register, s.Left.Register, s.Right.Register));
                            break;
                        default:
                            throw new Exception($"Invalid type: {s.Left.Type}");
                    }

                    instructions.AddRange(ExpressionLValue(s.Left));
                    break;
            }

            instructions.Add(new Store(s.Left.Register, s.Right.Register));
            return instructions;
        }

        private static List<IInstruction> VisitIncrementStatement(IncrementStatement s)
        {
            var instructions = new List<IInstruction>();
            instructions.AddRange(ExpressionRValue(s.Left));
            int val = s.Operator switch
            {
                IncrementOperator.PlusPlus => 1,
                IncrementOperator.MinusMinus => -1,
                _ => throw new NotImplementedException()
            };

            switch (s.Left.Type)
            {
                case IntegralType or BoolType:
                    instructions.Add(new AddImmediate(Registers.Temporary, s.Left.Register, val));
                    break;
                case RealType:
                    instructions.Add(new AddFloatImmediate(Registers.Temporary, s.Left.Register, val));
                    break;
                default:
                    throw new Exception($"Invalid type: {s.Left.Type}");
            }

            instructions.AddRange(ExpressionLValue(s.Left));
            instructions.Add(new Store(s.Left.Register, Registers.Temporary));
            return instructions;
        }

        private static List<IInstruction> VisitVariableDefinitionAndAssignmentStatement(VariableDefinitionAndAssignmentStatement s)
        {
            if (s.Id.Symbol == null)
            {
                throw new Exception("Symbol was null");
            }

            var instructions = new List<IInstruction>();
            if (s.Expression is ComplexLiteralExpression complexLiteral)
            {
                if (s.Id.Symbol.IsGlobal)
                {
                    instructions.Add(new DeclareGlobal(s.Id.Symbol.Name, s.Id.Symbol.Type.GetSizeInWords()));
                    instructions.Add(new LoadLabel(complexLiteral.Register, s.Id.Symbol.Name));
                    instructions.AddRange(MakeComplexLiteral(complexLiteral));
                }
                else
                {
                    instructions.Add(new AddImmediate(complexLiteral.Register, Registers.FramePointer, s.Id.Symbol.Offset));
                    instructions.AddRange(MakeComplexLiteral(complexLiteral));
                }
            }
            else
            {
                instructions.AddRange(ExpressionRValue(s.Expression));
                if (s.Id.Symbol.IsGlobal)
                {
                    instructions.Add(new DeclareGlobal(s.Id.Symbol.Name, s.Id.Symbol.Type.GetSizeInWords()));
                    instructions.Add(new LoadLabel(Registers.Temporary, s.Id.Symbol.Name));
                    instructions.Add(new Store(Registers.Temporary, s.Expression.Register));
                }
                else
                {
                    instructions.Add(new Store(Registers.FramePointer, s.Expression.Register, s.Id.Symbol.Offset));
                }
            }
            
            return instructions;
        }

        private static List<IInstruction> VisitCallStatement(CallStatement s)
        {
            return CallExpressionRValue(s.CallExpression);
        }

        private static List<IInstruction> VisitIfStatement(IfStatement s)
        {
            var instructions = new List<IInstruction>();
            var labelId = GetNextLabelId();
            var exitLabel = $"if_exit_{labelId}";

            if (s.ElifExpressions.Count > 0 || s.ElseBody != null) 
            {
                string nextLabel(int n) => $"elif_{n}_{labelId}";

                instructions.AddRange(Flow(s.IfExpression, nextLabel(0), false));
                instructions.AddRange(VisitCompoundStatement(s.IfBody));
                instructions.Add(new Jump(exitLabel));
                instructions.Add(new Label(nextLabel(0)));
                var i = 1;
                foreach (var (e, b) in s.ElifExpressions.Zip(s.ElifBodies))
                {
                    instructions.AddRange(Flow(e, nextLabel(i), false));
                    instructions.AddRange(VisitCompoundStatement(b));
                    instructions.Add(new Jump(exitLabel));
                    instructions.Add(new Label(nextLabel(i)));
                    i++;
                }

                if (s.ElseBody != null)
                {
                    instructions.AddRange(VisitCompoundStatement(s.ElseBody));
                }
            }
            else
            {
                instructions.AddRange(Flow(s.IfExpression, exitLabel, false));
                instructions.AddRange(VisitCompoundStatement(s.IfBody));
            }

            instructions.Add(new Label(exitLabel));
            return instructions;
        }

        private static List<IInstruction> VisitWhileStatement(WhileStatement s)
        {
            var instructions = new List<IInstruction>();
            s.LabelId = GetNextLabelId();
            var topLabel = s.GetLoopLabel();
            var exitLabel = s.GetExitLabel();

            instructions.Add(new Label(topLabel));
            instructions.AddRange(Flow(s.Expression, exitLabel, false));
            instructions.AddRange(VisitCompoundStatement(s.Body));
            instructions.Add(new Jump(topLabel));
            instructions.Add(new Label(exitLabel));
            return instructions;
        }

        private static List<IInstruction> VisitDoWhileStatement(DoWhileStatement s)
        {
            var instructions = new List<IInstruction>();
            s.LabelId = GetNextLabelId();
            var topLabel = s.GetLoopLabel();
            var exitLabel = s.GetExitLabel();

            instructions.Add(new Label(topLabel));
            instructions.AddRange(VisitCompoundStatement(s.Body));
            instructions.AddRange(Flow(s.Expression, exitLabel, false));
            instructions.Add(new Jump(topLabel));
            instructions.Add(new Label(exitLabel));
            return instructions;
        }

        private static List<IInstruction> VisitForStatement(ForStatement s)
        {
            var instructions = new List<IInstruction>();
            s.LabelId = GetNextLabelId();
            var topLabel = s.GetLoopLabel();
            var exitLabel = s.GetExitLabel();

            instructions.AddRange(VisitStatement(s.InitialStatement));
            instructions.Add(new Label(topLabel));
            instructions.AddRange(Flow(s.Expression, exitLabel, false));
            instructions.AddRange(VisitCompoundStatement(s.Body));
            instructions.AddRange(VisitStatement(s.UpdateStatement));
            instructions.Add(new Jump(topLabel));
            instructions.Add(new Label(exitLabel));
            return instructions;
        }

        private static List<IInstruction> VisitBreakStatement(BreakStatement s)
        {
            if (s.EnclosingLoop == null)
            {
                throw new Exception("EnclosingLoop was null");
            }

            return new List<IInstruction>()
            {
                new Jump(s.EnclosingLoop.GetExitLabel())
            };
        }

        private static List<IInstruction> VisitContinueStatement(ContinueStatement s)
        {
            if (s.EnclosingLoop == null)
            {
                throw new Exception("EnclosingLoop was null");
            }
            
            if (s.EnclosingLoop is ForStatement forLoop)
            {
                var instructions = VisitStatement(forLoop.UpdateStatement);
                instructions.Add(new Jump(s.EnclosingLoop.GetLoopLabel()));
                return instructions;
            }

            return new List<IInstruction>()
            {
                new Jump(s.EnclosingLoop.GetLoopLabel())
            };
        }

        private static List<IInstruction> VisitReturnStatement(ReturnStatement s)
        {
            if (s.EnclosingFunction == null)
            {
                throw new Exception("EnclosingFunction was null");
            }

            var instructions = new List<IInstruction>();
            if (s.Expression != null)
            {
                instructions.AddRange(ExpressionRValue(s.Expression));
                instructions.Add(new Store(Registers.FramePointer, s.Expression.Register, -1));
            }

            instructions.Add(new Jump(s.EnclosingFunction.ReturnLabel));
            return instructions;
        }

        private static List<IInstruction> VisitExitStatement(ExitStatement s)
        {
            var instructions = ExpressionRValue(s.Expression);
            instructions.Add(new Jump(ProgramRoot.ExitLabel)); // TODO return error code to OS when running
            return instructions;
        }

        private static List<IInstruction> ExpressionRValue(Expression expression)
        {
            return expression switch
            {
                BinaryOperatorExpression e => BinaryOperatorExpressionRValue(e),
                UnaryOperatorExpression e => UnaryOperatorExpressionRValue(e),
                CallExpression e => CallExpressionRValue(e),
                ArrayIndexExpression e => ArrayIndexExpressionRVaule(e),
                FieldAccessExpression e => FieldAccessExpressionRValue(e),
                ReadExpression e => ReadExpressionRValue(e),
                IdExpression e => IdExpressionRValue(e),
                IntLiteralExpression e => IntLiteralExpressionRValue(e),
                ByteLiteralExpression e => ByteLiteralExpressionRValue(e),
                FloatLiteralExpression e => FloatLiteralExpressionRValue(e),
                BoolLiteralExpression e => BoolLiteralExpressionRValue(e),
                _ => throw new NotImplementedException($"Unknown expression: {expression}"),
            }; ;
        }

        private static List<IInstruction> BinaryOperatorExpressionRValue(BinaryOperatorExpression e)
        {
            var instructions = new List<IInstruction>();
            switch (e.Operator) 
            {
                case BinaryOperator.EqualTo:
                    instructions.AddRange(ExpressionRValue(e.LeftOperand));
                    instructions.AddRange(ExpressionRValue(e.RightOperand));
                    instructions.Add(new Equal(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                    break;
                case BinaryOperator.NotEqualTo:
                    instructions.AddRange(ExpressionRValue(e.LeftOperand));
                    instructions.AddRange(ExpressionRValue(e.RightOperand));
                    instructions.Add(new Equal(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                    instructions.Add(new Not(e.Register, e.Register));
                    break;
                case BinaryOperator.LessThan:
                    instructions.AddRange(ExpressionRValue(e.LeftOperand));
                    instructions.AddRange(ExpressionRValue(e.RightOperand));
                    switch (e.LeftOperand.Type) // TODO check the types here better
                    {
                        case IntegralType or BoolType:
                            instructions.Add(new LessThan(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                            break;
                        case RealType:
                            instructions.Add(new LessThanFloat(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                            break;
                        default:
                            throw new Exception($"Invalid type: {e.Type}");
                    }
                    break;
                case BinaryOperator.LessThanEqualTo:
                    instructions.AddRange(ExpressionRValue(e.LeftOperand));
                    instructions.AddRange(ExpressionRValue(e.RightOperand));
                    switch (e.LeftOperand.Type)
                    {
                        case IntegralType or BoolType:
                            instructions.Add(new LessThanEqual(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                            break;
                        case RealType:
                            instructions.Add(new LessThanEqualFloat(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                            break;
                        default:
                            throw new Exception($"Invalid type: {e.Type}");
                    }
                    break;
                case BinaryOperator.GreaterThan:
                    instructions.AddRange(ExpressionRValue(e.LeftOperand));
                    instructions.AddRange(ExpressionRValue(e.RightOperand));
                    switch (e.LeftOperand.Type)
                    {
                        case IntegralType or BoolType:
                            instructions.Add(new GreaterThan(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                            break;
                        case RealType:
                            instructions.Add(new GreaterThanFloat(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                            break;
                        default:
                            throw new Exception($"Invalid type: {e.Type}");
                    }
                    break;
                case BinaryOperator.GreaterThanEqualTo:
                    instructions.AddRange(ExpressionRValue(e.LeftOperand));
                    instructions.AddRange(ExpressionRValue(e.RightOperand));
                    switch (e.LeftOperand.Type)
                    {
                        case IntegralType or BoolType:
                            instructions.Add(new GreaterThanEqual(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                            break;
                        case RealType:
                            instructions.Add(new GreaterThanEqualFloat(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                            break;
                        default:
                            throw new Exception($"Invalid type: {e.Type}");
                    }
                    break;
                case BinaryOperator.Plus:
                    instructions.AddRange(ExpressionRValue(e.LeftOperand));
                    instructions.AddRange(ExpressionRValue(e.RightOperand));
                    switch (e.Type)
                    {
                        case IntegralType:
                            instructions.Add(new Add(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                            break;
                        case RealType:
                            instructions.Add(new AddFloat(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                            break;
                        case PointerType:
                            instructions.Add(new LoadImmediate(Registers.Temporary, e.LeftOperand.Type!.GetSizeInWords()));
                            instructions.Add(new Multiply(e.RightOperand.Register, e.RightOperand.Register, Registers.Temporary));
                            instructions.Add(new Add(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                            break;
                        default:
                            throw new Exception($"Invalid type: {e.Type}");
                    }
                    break;
                case BinaryOperator.Minus:
                    instructions.AddRange(ExpressionRValue(e.LeftOperand));
                    instructions.AddRange(ExpressionRValue(e.RightOperand));
                    switch (e.Type)
                    {
                        case IntegralType:
                            instructions.Add(new Negate(e.RightOperand.Register, e.RightOperand.Register));
                            instructions.Add(new Add(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                            break;
                        case RealType:
                            instructions.Add(new NegateFloat(e.RightOperand.Register, e.RightOperand.Register));
                            instructions.Add(new AddFloat(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                            break;
                        case PointerType:
                            instructions.Add(new LoadImmediate(Registers.Temporary, e.LeftOperand.Type!.GetSizeInWords()));
                            instructions.Add(new Multiply(e.RightOperand.Register, e.RightOperand.Register, Registers.Temporary));
                            instructions.Add(new Negate(e.RightOperand.Register, e.RightOperand.Register));
                            instructions.Add(new Add(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                            break;
                        default:
                            throw new Exception($"Invalid type: {e.Type}");
                    }
                    break;
                case BinaryOperator.Times:
                    instructions.AddRange(ExpressionRValue(e.LeftOperand));
                    instructions.AddRange(ExpressionRValue(e.RightOperand));
                    switch (e.Type)
                    {
                        case IntegralType:
                            instructions.Add(new Multiply(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                            break;
                        case RealType:
                            instructions.Add(new MultiplyFloat(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                            break;
                        default:
                            throw new Exception($"Invalid type: {e.Type}");
                    }
                    break;
                case BinaryOperator.DividedBy:
                    instructions.AddRange(ExpressionRValue(e.LeftOperand));
                    instructions.AddRange(ExpressionRValue(e.RightOperand));
                    switch (e.Type)
                    {
                        case IntegralType:
                            instructions.Add(new Divide(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                            break;
                        case RealType:
                            instructions.Add(new DivideFloat(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                            break;
                        default:
                            throw new Exception($"Invalid type: {e.Type}");
                    }
                    break;
                case BinaryOperator.Modulo:
                    instructions.AddRange(ExpressionRValue(e.LeftOperand));
                    instructions.AddRange(ExpressionRValue(e.RightOperand));
                    switch (e.Type)
                    {
                        case IntegralType:
                            instructions.Add(new Modulo(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                            break;
                        case RealType:
                            instructions.Add(new ModuloFloat(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                            break;
                        default:
                            throw new Exception($"Invalid type: {e.Type}");
                    }
                    break;
                case BinaryOperator.And:
                case BinaryOperator.Or:
                    var labelId = GetNextLabelId();
                    var trueLabel = $"bool_op_true_{labelId}";
                    var exitLabel = $"bool_op_exit_{labelId}";
                    instructions.AddRange(Flow(e, trueLabel, true));
                    instructions.Add(new LoadImmediate(e.Register, 0));
                    instructions.Add(new Jump(exitLabel));
                    instructions.Add(new Label(trueLabel));
                    instructions.Add(new LoadImmediate(e.Register, 1));
                    instructions.Add(new Label(exitLabel));
                    break;
                default:
                    throw new Exception($"Unrecognized binary operator: {e.Operator}");
            }

            return instructions;
        }

        private static List<IInstruction> UnaryOperatorExpressionRValue(UnaryOperatorExpression e)
        {
            var instructions = ExpressionRValue(e.Operand);
            switch (e.Operator)
            {
                case UnaryOperator.Not:
                    instructions.Add(new Not(e.Register, e.Register));
                    break;
                case UnaryOperator.Minus:
                    switch (e.Type)
                    {
                        case IntegralType:
                            instructions.Add(new Negate(e.Register, e.Register));
                            break;
                        case RealType:
                            instructions.Add(new NegateFloat(e.Register, e.Register));
                            break;
                    }

                    break;
                case UnaryOperator.AddressOf:
                    instructions.AddRange(ExpressionLValue(e.Operand));
                    instructions.Add(new Move(e.Register, e.Operand.Register));
                    break;
                case UnaryOperator.Dereference:
                    instructions.AddRange(ExpressionRValue(e.Operand));
                    instructions.Add(new Load(e.Register, e.Operand.Register));
                    break;
            }

            return instructions;
        }

        private static List<IInstruction> CallExpressionRValue(CallExpression e)
        {
            if (e.Function.Type is FunctionType functionType)
            {
                var instructions = ExpressionRValue(e.Function);
                var argSize = e.Arguments.Sum(a => a.Type!.GetSizeInWords());
                var returnSize = functionType.ReturnType is VoidType ? 1 : functionType.ReturnType.GetSizeInWords();
                instructions.Add(new AddImmediate(Registers.StackPointer, Registers.StackPointer, argSize + returnSize));
                for (var i = 0; i < e.Arguments.Count; i++)
                {
                    var arg = e.Arguments[i];
                    instructions.AddRange(ExpressionRValue(arg));
                    instructions.Add(new Store(Registers.StackPointer, arg.Register, -i - returnSize - 1));
                }

                instructions.Add(new CallIndirect(e.Function.Register));
                if (!e.IgnoreReturn && functionType.ReturnType is not VoidType)
                {
                    instructions.Add(new Load(e.Register, Registers.StackPointer, -1));
                }

                instructions.Add(new AddImmediate(Registers.StackPointer, Registers.StackPointer, -argSize - returnSize));
                return instructions;
            }

            throw new Exception("Function did not have function type");     
        }

        private static List<IInstruction> ArrayIndexExpressionRVaule(ArrayIndexExpression e)
        {
            var instructions = ExpressionLValue(e);
            instructions.Add(new Load(e.Register, e.Register));
            return instructions;
        }

        private static List<IInstruction> FieldAccessExpressionRValue(FieldAccessExpression e)
        {
            var instructions = ExpressionLValue(e.Left);
            instructions.Add(new Load(e.Register, e.Left.Register, e.Offset));
            return instructions;
        }

        private static List<IInstruction> ReadExpressionRValue(ReadExpression e)
        {
            return new List<IInstruction>()
            {
                new Read(e.Register)
            };
        }

        private static List<IInstruction> IdExpressionRValue(IdExpression e)
        {
            if (e.Id.Symbol == null)
            {
                throw new Exception("Symbol was null");
            }

            if (e.Id.Symbol.Type is FunctionType && e.Id.Symbol.IsDefinedGlobalFunction)
            {
                if (e.Id.Symbol.EnclosingFunction == null)
                {
                    throw new Exception("EnclosingFunction was null");
                }

                return new List<IInstruction>
                {
                    new LoadLabel(e.Register, e.Id.Symbol.EnclosingFunction.EnterLabel)
                };
            }
            else if (e.Id.Symbol.IsGlobal)
            {
                return new List<IInstruction>
                {
                    new LoadLabel(e.Register, e.Id.Symbol.Name),
                    new Load(e.Register, e.Register)
                };
            }

            //else if (e.Id.Symbol.Type is ArrayType)
            //{
            //    return ExpressionLValue(e);
            //}

            return new List<IInstruction>
            {
                new Load(e.Register, Registers.FramePointer, e.Id.Symbol.Offset),
            };
        }

        private static List<IInstruction> IntLiteralExpressionRValue(IntLiteralExpression e)
        {
            return new List<IInstruction>()
            {
                new LoadImmediate(e.Register, e.Value)
            };
        }
        private static List<IInstruction> ByteLiteralExpressionRValue(ByteLiteralExpression e)
        {
            return new List<IInstruction>()
            {
                new LoadImmediate(e.Register, e.Value)
            };
        }

        private static List<IInstruction> FloatLiteralExpressionRValue(FloatLiteralExpression e)
        {
            return new List<IInstruction>()
            {
                new LoadImmediate(e.Register, e.Value)
            };
        }

        private static List<IInstruction> BoolLiteralExpressionRValue(BoolLiteralExpression e)
        {
            return new List<IInstruction>()
            {
                new LoadImmediate(e.Register, e.Value ? 1 : 0)
            };
        }

        private static List<IInstruction> ExpressionLValue(Expression expression)
        {
            return expression switch
            {
                IdExpression e => IdExpressionLValue(e),
                UnaryOperatorExpression e => UnaryOperatorLValue(e),
                ArrayIndexExpression e => ArrayIndexExpressionLValue(e),
                FieldAccessExpression e => FieldAccessExpressionLValue(e),
                Expression e => NoExpressionLValue(e),
            };
        }

        private static List<IInstruction> IdExpressionLValue(IdExpression e)
        {
            if (e.Id.Symbol == null)
            {
                throw new Exception("Symbol was null");
            }

            if (e.Id.Symbol.IsGlobal)
            {
                return new List<IInstruction>()
                {
                    new LoadLabel(e.Register, e.Id.Symbol.Name),
                };
            }

            return new List<IInstruction>()
            {
                new AddImmediate(e.Register, Registers.FramePointer, e.Id.Symbol.Offset)
            };
        }

        private static List<IInstruction> UnaryOperatorLValue(UnaryOperatorExpression e)
        {
            switch (e.Operator)
            {
                case UnaryOperator.Minus:
                case UnaryOperator.Not:
                case UnaryOperator.AddressOf:
                    return NoExpressionLValue(e);
                case UnaryOperator.Dereference:
                    var instructions = ExpressionRValue(e.Operand);
                    instructions.Add(new Move(e.Register, e.Operand.Register));
                    return instructions;
                default:
                    throw new NotImplementedException();
            }
        }


        private static List<IInstruction> ArrayIndexExpressionLValue(ArrayIndexExpression e)
        {
            if (e.Array.Type == null || e.Index.Type == null)
            {
                throw new Exception("Type was null");
            }

            var instructions = ExpressionLValue(e.Array);
            instructions.AddRange(ExpressionRValue(e.Index));
            if (e.Index.Type.GetSizeInWords() > 1)
            {
                instructions.Add(new LoadImmediate(Registers.Temporary, e.Array.Type.GetSizeInWords()));
                instructions.Add(new Multiply(e.Index.Register, e.Index.Register, Registers.Temporary));
            }
            
            instructions.Add(new Add(e.Register, e.Array.Register, e.Index.Register));
            return instructions;
        }

        private static List<IInstruction> FieldAccessExpressionLValue(FieldAccessExpression e)
        {
            var instructions = ExpressionLValue(e.Left);
            instructions.Add(new AddImmediate(e.Register, e.Left.Register, e.Offset));
            return instructions;
        }

        private static List<IInstruction> NoExpressionLValue(Expression e)
        {
            ErrorHandler.Throw("Expression does not have an l-value.", e);
            throw new Exception("Error handler did not stop execution");
        }

        private static List<IInstruction> Flow(Expression expression, string label, bool condition)
        {
            return expression switch
            {
                BinaryOperatorExpression e => BinaryOperatorExpressionFlow(e, label, condition),
                UnaryOperatorExpression e => UnaryOperatorExpressionFlow(e, label, condition),
                BoolLiteralExpression e => BoolLiteralExpressionFlow(e, label, condition),
                Expression e => SimpleFlow(e, label, condition),
            };
        }

        private static List<IInstruction> BinaryOperatorExpressionFlow(BinaryOperatorExpression e, string label, bool condition)
        {
            var instructions = new List<IInstruction>();
            switch (e.Operator)
            {
                case BinaryOperator.And:
                    if (!condition)
                    {
                        instructions.AddRange(Flow(e.LeftOperand, label, false));
                        instructions.AddRange(Flow(e.RightOperand, label, false));
                    }
                    else
                    {
                        var labelId = GetNextLabelId();
                        var ftLabel = $"flow_fallthrough_{labelId}";
                        instructions.AddRange(Flow(e.LeftOperand, ftLabel, false));
                        instructions.AddRange(Flow(e.RightOperand, label, true));
                        instructions.Add(new Label(ftLabel));
                    }
                    break;
                case BinaryOperator.Or:
                    if (condition)
                    {
                        instructions.AddRange(Flow(e.LeftOperand, label, true));
                        instructions.AddRange(Flow(e.RightOperand, label, true));
                    }
                    else
                    {
                        var labelId = GetNextLabelId();
                        var ftLabel = $"flow_fallthrough_{labelId}";
                        instructions.AddRange(Flow(e.LeftOperand, ftLabel, true));
                        instructions.AddRange(Flow(e.RightOperand, label, false));
                        instructions.Add(new Label(ftLabel));
                    }
                    break;
                default:
                    instructions.AddRange(SimpleFlow(e, label, condition));
                    break;
            }

            return instructions;
        }

        private static List<IInstruction> UnaryOperatorExpressionFlow(UnaryOperatorExpression e, string label, bool condition)
        {
            return e.Operator switch
            {
                UnaryOperator.Not => Flow(e.Operand, label, !condition),
                _ => throw new Exception($"Invalid operator for flow: {e.Operator}")
            };
        }

        private static List<IInstruction> BoolLiteralExpressionFlow(BoolLiteralExpression e, string label, bool condition)
        {
            var instructions = new List<IInstruction>();
            if (e.Value == condition)
            {
                instructions.Add(new Jump(label));
            }

            return instructions;
        }

        private static List<IInstruction> SimpleFlow(Expression expression, string label, bool condition)
        {
            var instructions = ExpressionRValue(expression);
            if (condition)
            {
                instructions.Add(new JumpIfNotZero(expression.Register, label));
            }
            else
            {
                instructions.Add(new JumpIfZero(expression.Register, label));
            }

            return instructions;
        }

        /// <summary>
        /// Makes a complex literal. At the moment it is epected that the address of the memory where this literal will be stored is in expression.Register.
        /// </summary>
        /// <param name="expression">The literal.</param>
        /// <returns>The instructions.</returns>
        /// <exception cref="NotImplementedException"></exception>
        private static List<IInstruction> MakeComplexLiteral(ComplexLiteralExpression expression)
        {
            return expression switch
            {
                StructLiteralExpression e => MakeStructLiteral(e),
                ArrayLiteralExpression e => MakeArrayLiteral(e),
                _ => throw new NotImplementedException()
            };
        }

        private static List<IInstruction> MakeStructLiteral(StructLiteralExpression e)
        {
            var instructions = new List<IInstruction>();
            foreach (var field in e.Fields)
            {
                if (field.Expression is ComplexLiteralExpression complexLiteral)
                {
                    instructions.Add(new AddImmediate(complexLiteral.Register, e.Register, field.Offset));
                    instructions.AddRange(MakeComplexLiteral(complexLiteral));
                }
                else
                {
                    instructions.AddRange(ExpressionRValue(field.Expression));
                    instructions.Add(new Store(e.Register, field.Expression.Register, field.Offset));
                }
            }

            return instructions;
        }

        private static List<IInstruction> MakeArrayLiteral(ArrayLiteralExpression e)
        {
            // TODO fix this once done with structs and arrays
            var instructions = new List<IInstruction>();
            for (var i = 0; i < e.Elements.Count; i++)
            {
                var elem = e.Elements[i];
                instructions.AddRange(ExpressionRValue(elem));
                if (elem.Type != null && elem.Type is not ArrayType)
                {
                    var offset = e.Offset + (i * elem.Type.GetSizeInWords());
                    instructions.Add(new Store(Registers.FramePointer, elem.Register, offset));
                }
            }

            return instructions;
        }
    }
}
