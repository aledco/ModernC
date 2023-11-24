using Compiler.Models.NameResolution.Types;
using Compiler.Models.Tree;
using Compiler.VirtualMachine;
using Compiler.VirtualMachine.Instructions;

namespace Compiler.TreeWalking.CodeGeneration.VirtualMachine
{
    public static class CodeGenerator
    {
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
                VariableDefinitionAndAssignmentStatement s => VisitVariableDefinitionAndAssignmentStatement(s),
                CallStatement s => VisitCallStatement(s),
                ReturnStatement s => VisitReturnStatement(s),
                CompoundStatement s => VisitCompoundStatement(s),
                _ => throw new NotImplementedException($"Unknown statement {statement}"),
            };
        }

        private static List<IInstruction> VisitPrintStatement(PrintStatement s)
        {
            var instructions = ExpressionRValue(s.Expression);
            instructions.Add(new Print(s.Expression.Register));
            return instructions;
        }

        private static List<IInstruction> VisitVariableDefinitionStatement(VariableDefinitionStatement s)
        {
            return new List<IInstruction>();
        }

        private static List<IInstruction> VisitAssignmentStatement(AssignmentStatement s)
        {
            var instructions = ExpressionRValue(s.Right);
            instructions.AddRange(ExpressionLValue(s.Left));
            instructions.Add(new Store(s.Left.Register, s.Right.Register));
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
                BoolLiteralExpression e => BoolLiteralExpressionRValue(e),
                _ => throw new NotImplementedException($"Unknown expression: {expression}"),
            };
        }

        private static List<IInstruction> BinaryOperatorExpressionRValue(BinaryOperatorExpression e)
        {
            var instructions = ExpressionRValue(e.LeftOperand);
            switch (e.Operator) 
            {
                case "+":
                    instructions.AddRange(ExpressionRValue(e.RightOperand));
                    instructions.Add(new Add(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                    break;
                case "-":
                    instructions.AddRange(ExpressionRValue(e.RightOperand));
                    instructions.Add(new Negate(e.RightOperand.Register, e.RightOperand.Register));
                    instructions.Add(new Add(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                    break;
                case "*":
                    instructions.AddRange(ExpressionRValue(e.RightOperand));
                    instructions.Add(new Multiply(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                    break;
                case "/":
                    instructions.AddRange(ExpressionRValue(e.RightOperand));
                    instructions.Add(new Divide(e.Register, e.LeftOperand.Register, e.RightOperand.Register));
                    break;
                case "and":
                    // TODO short circuit
                case "or":
                    // TODO short circuit
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
                    "-" => new Negate(e.Register, e.Register),
                    "not" => new Not(e.Register, e.Register),
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

        private static List<IInstruction> BoolLiteralExpressionRValue(BoolLiteralExpression e)
        {
            return new List<IInstruction>()
            {
                new LoadImmediate(e.Register, e.Value ? 1 : 0)
            };
        }

        private static List<IInstruction> IntLiteralExpressionRValue(IntLiteralExpression e)
        {
            return new List<IInstruction>()
            {
                new LoadImmediate(e.Register, e.Value)
            };
        }


        private static List<IInstruction> ExpressionLValue(Expression expression)
        {
            return expression switch
            {
                BinaryOperatorExpression e => BinaryOperatorExpressionLValue(e),
                UnaryOperatorExpression e => UnaryOperatorExpressionLValue(e),
                CallExpression e => CallExpressionLValue(e),
                IdExpression e => IdExpressionLValue(e),
                IntLiteralExpression e => IntLiteralExpressionLValue(e),
                BoolLiteralExpression e => BoolLiteralExpressionLValue(e),
                _ => throw new NotImplementedException($"Unknown expression: {expression}"),
            };
        }

        private static List<IInstruction> BinaryOperatorExpressionLValue(BinaryOperatorExpression e)
        {
            throw new Exception("Binary expressions do not have l-values");
        }

        private static List<IInstruction> UnaryOperatorExpressionLValue(UnaryOperatorExpression e)
        {
            throw new Exception("Unary expressions do not have l-values");
        }

        private static List<IInstruction> CallExpressionLValue(CallExpression e)
        {
            throw new Exception("Call expressions do not have l-values");
        }


        private static List<IInstruction> IdExpressionLValue(IdExpression e)
        {
            if (e.Id.Symbol == null)
            {
                throw new Exception("Symbol was null");
            }

            return new List<IInstruction>()
            {
                new AddImmediate(e.Register, "FP", e.Id.Symbol.Offset)
            };
        }

        private static List<IInstruction> BoolLiteralExpressionLValue(BoolLiteralExpression e)
        {
            throw new Exception("Bool literals do not have l-values");
        }

        private static List<IInstruction> IntLiteralExpressionLValue(IntLiteralExpression e)
        {
            throw new Exception("Int literals do not have l-values");
        }
    }
}
