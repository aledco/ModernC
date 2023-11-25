using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Operators;
using Compiler.Models.Tree;
using Compiler.VirtualMachine;
using Compiler.VirtualMachine.Instructions;

namespace Compiler.TreeWalking.CodeGeneration.VirtualMachine
{
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
            var instructions = new List<IInstruction>()
            {
                new Call("main"),
                new Jump("exit")
            };

            instructions.AddRange(program.FunctionDefinitions.SelectMany(VisitFunctionDefinition));
            instructions.Add(new Label("exit"));
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
                VariableDefinitionStatement s => VisitVariableDefinitionStatement(s),
                AssignmentStatement s => VisitAssignmentStatement(s),
                IncrementStatement s => VisitIncrementStatement(s),
                VariableDefinitionAndAssignmentStatement s => VisitVariableDefinitionAndAssignmentStatement(s),
                CallStatement s => VisitCallStatement(s),
                IfStatement s => VisitIfStatement(s),
                WhileStatement s => VisitWhileStatement(s),
                ForStatement s => VisitForStatement(s),
                ReturnStatement s => VisitReturnStatement(s),
                CompoundStatement s => VisitCompoundStatement(s),
                _ => throw new NotImplementedException($"Unknown statement {statement}"),
            };
        }

        private static List<IInstruction> VisitPrintStatement(PrintStatement s)
        {
            var instructions = ExpressionRValue(s.Expression);
            switch (s.Expression.Type)
            {
                case IntType:
                    instructions.Add(new PrintInt(s.Expression.Register));
                    break;
                case ByteType:
                    instructions.Add(new PrintByte(s.Expression.Register));
                    break;
                case FloatType:
                    instructions.Add(new PrintFloat(s.Expression.Register));
                    break;
                case BoolType:
                    instructions.Add(new PrintBool(s.Expression.Register));
                    break;
                case FunctionType:
                    instructions.Add(new PrintPointer(s.Expression.Register));
                    break;
                default:
                    ErrorHandler.Throw("Cannot print expression", s);
                    break;
            }
            
            return instructions;
        }

        private static List<IInstruction> VisitVariableDefinitionStatement(VariableDefinitionStatement _)
        {
            return new List<IInstruction>();
        }

        private static List<IInstruction> VisitAssignmentStatement(AssignmentStatement s)
        {
            var instructions = new List<IInstruction>();
            if (s.BinaryExpression != null)
            {
                if (s.Left.AssignmentRegister == null)
                {
                    throw new Exception("AssignmentRegister was null");
                }

                instructions.AddRange(BinaryOperatorExpressionRValue(s.BinaryExpression));
                instructions.AddRange(ExpressionLValue(s.Left));
                instructions.Add(new Store(s.Left.AssignmentRegister, s.BinaryExpression.Register));
            }
            else
            {
                instructions.AddRange(ExpressionRValue(s.Right));
                instructions.AddRange(ExpressionLValue(s.Left));
                instructions.Add(new Store(s.Left.Register, s.Right.Register));
            }

            return instructions;
        }

        private static List<IInstruction> VisitIncrementStatement(IncrementStatement s)
        {
            var instructions = new List<IInstruction>();
            if (s.Left.AssignmentRegister == null)
            {
                throw new Exception("AssignmentRegister was null");
            }

            instructions.AddRange(ExpressionRValue(s.Left));
            switch (s.Operator) 
            {
                case IncrementOperator.PlusPlus:

                    instructions.Add(new AddImmediate(s.Left.Register, s.Left.Register, 1));
                    break;
                case IncrementOperator.MinusMinus:
                    instructions.Add(new AddImmediate(s.Left.Register, s.Left.Register, -1));
                    break;
            }
            
            instructions.AddRange(ExpressionLValue(s.Left));
            instructions.Add(new Store(s.Left.AssignmentRegister, s.Left.Register));
            return instructions;
        }

        private static List<IInstruction> VisitVariableDefinitionAndAssignmentStatement(VariableDefinitionAndAssignmentStatement s)
        {
            if (s.Id.Symbol == null)
            {
                throw new Exception("Symbol was null");
            }

            var instructions = ExpressionRValue(s.Expression);
            instructions.Add(new Store("FP", s.Expression.Register, s.Id.Symbol.Offset));
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
                var nextLabel = (int n) => $"elif_{n}_{labelId}";
                
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
            var labelId = GetNextLabelId();
            var topLabel = $"while_top_{labelId}";
            var exitLabel = $"while_exit_{labelId}";

            instructions.Add(new Label(topLabel));
            instructions.AddRange(Flow(s.Expression, exitLabel, false));
            instructions.AddRange(VisitCompoundStatement(s.Body));
            instructions.Add(new Jump(topLabel));
            instructions.Add(new Label(exitLabel));
            return instructions;
        }

        private static List<IInstruction> VisitForStatement(ForStatement s)
        {
            var instructions = new List<IInstruction>();
            var labelId = GetNextLabelId();
            var topLabel = $"for_top_{labelId}";
            var exitLabel = $"for_exit_{labelId}";

            instructions.AddRange(VisitStatement(s.InitialStatement));
            instructions.Add(new Label(topLabel));
            instructions.AddRange(Flow(s.Expression, exitLabel, false));
            instructions.AddRange(VisitCompoundStatement(s.Body));
            instructions.AddRange(VisitStatement(s.UpdateStatement));
            instructions.Add(new Jump(topLabel));
            instructions.Add(new Label(exitLabel));
            return instructions;
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
                instructions.Add(new Store("FP", s.Expression.Register, -1));
            }

            instructions.Add(new Jump(s.EnclosingFunction.ReturnLabel));
            return instructions;
        }

        private static List<IInstruction> ExpressionRValue(Expression expression)
        {
            return expression switch
            {
                BinaryOperatorExpression e => BinaryOperatorExpressionRValue(e),
                UnaryOperatorExpression e => UnaryOperatorExpressionRValue(e),
                CallExpression e => CallExpressionRValue(e),
                IdExpression e => IdExpressionRValue(e),
                IntLiteralExpression e => IntLiteralExpressionRValue(e),
                ByteLiteralExpression e => ByteLiteralExpressionRValue(e),
                FloatLiteralExpression e => FloatLiteralExpressionRValue(e),
                BoolLiteralExpression e => BoolLiteralExpressionRValue(e),
                _ => throw new NotImplementedException($"Unknown expression: {expression}"),
            };
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
            instructions.Add(
                e.Operator switch
                {
                    UnaryOperator.Minus => new Negate(e.Register, e.Register),
                    UnaryOperator.Not => new Not(e.Register, e.Register),
                    _ => throw new Exception($"Unrecognized unary operator: {e.Operator}")
                });
            return instructions;
        }

        private static List<IInstruction> CallExpressionRValue(CallExpression e)
        {
            if (e.Function.Id.Symbol?.EnclosingFunction == null)
            {
                throw new Exception("EnclosingFunction was null");
            }

            var instructions = IdExpressionRValue(e.Function);
            instructions.Add(new AddImmediate(Registers.StackPointer, Registers.StackPointer, e.ArgumentList.Arguments.Count + 1));

            for (var i = 0; i < e.ArgumentList.Arguments.Count; i++)
            {
                var arg = e.ArgumentList.Arguments[i];
                instructions.AddRange(ExpressionRValue(arg));
                instructions.Add(new Store(Registers.StackPointer, arg.Register, -i - 2));
            }

            instructions.AddRange(new IInstruction[]
            {
                new CallIndirect(e.Function.Register),
                new Load(e.Register, Registers.StackPointer, -1),
                new AddImmediate(Registers.StackPointer, Registers.StackPointer, -e.ArgumentList.Arguments.Count - 1)
            });

            return instructions;
        }

        private static List<IInstruction> IdExpressionRValue(IdExpression e)
        {
            if (e.Id.Symbol == null)
            {
                throw new Exception("Symbol was null");
            }

            if (e.Id.Symbol.Type is FunctionType && e.Id.Symbol.IsGlobal)
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
                Expression e => NoExpressionLValue(e),
            };
        }

        private static List<IInstruction> IdExpressionLValue(IdExpression e)
        {
            if (e.Id.Symbol == null)
            {
                throw new Exception("Symbol was null");
            }

            return new List<IInstruction>()
            {
                new AddImmediate(e.AssignmentRegister ?? e.Register, "FP", e.Id.Symbol.Offset)
            };
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
    }
}
