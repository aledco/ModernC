using Compiler.Models.Tree;
using LLVMSharp.Interop;

namespace Compiler.TreeWalking.CodeGeneration
{
    public unsafe class LLVMCodeGenerator : IWalker
    {
        private class Context
        {
            public LLVMModuleRef Module { get; } = new LLVMModuleRef();
            public LLVMBuilderRef Builder { get; } = new LLVMBuilderRef();
            public Dictionary<string, LLVMValueRef> NamedValues { get; } = new Dictionary<string, LLVMValueRef>();
            public Stack<LLVMValueRef> ValueStack { get; } = new Stack<LLVMValueRef>();
        }

        public static void Walk(ProgramRoot program)
        {
            var context = new Context();
            VisitProgramRoot(program, context);
        }


        private static void VisitProgramRoot(ProgramRoot program, Context context)
        {
            foreach (var functionDefinition in program.FunctionDefinitions)
            {
                VisitFunctionDefinition(functionDefinition, context);
            }
        }

        private static void VisitFunctionDefinition(FunctionDefinition functionDefinition, Context context)
        {
            VisitCompoundStatement(functionDefinition.Body, context);
        }

        private static void VisitCompoundStatement(CompoundStatement body, Context context)
        {
            foreach (var statement in body.Statements)
            {
                VisitStatement(statement, context);
            }
        }

        private static void VisitStatement(Statement statement, Context context)
        {
            switch (statement)
            {
                case PrintStatement s:
                    VisitPrintStatement(s, context);
                    break;
                case VariableDefinitionStatement s:
                    VisitVariableDefinitionStatement(s, context);
                    break;
                case AssignmentStatement s:
                    VisitAssignmentStatement(s, context);
                    break;
                case VariableDefinitionAndAssignmentStatement s:
                    VisitVariableDefinitionAndAssignmentStatement(s, context);
                    break;
                case ReturnStatement s:
                    VisitReturnStatement(s, context);
                    break;
                case CompoundStatement s:
                    VisitCompoundStatement(s, context);
                    break;
                default:
                    throw new NotImplementedException($"Unknown statement {statement}");
            }
        }

        private static void VisitReturnStatement(ReturnStatement statement, Context context)
        {
            if (statement.Expression != null)
            {
                VisitExpression(statement.Expression, context);
            }
        }

        private static void VisitPrintStatement(PrintStatement statement, Context context)
        {
            VisitExpression(statement.Expression, context);
        }

        private static void VisitVariableDefinitionStatement(VariableDefinitionStatement statement, Context context)
        {
            VisitIdNode(statement.Id, context);
        }

        private static void VisitAssignmentStatement(AssignmentStatement statement, Context context)
        {
            VisitExpression(statement.Left, context);
            VisitExpression(statement.Right, context);
        }

        private static void VisitVariableDefinitionAndAssignmentStatement(VariableDefinitionAndAssignmentStatement statement, Context context)
        {
            VisitExpression(statement.Expression, context);
            VisitIdNode(statement.Id, context);
        }

        private static void VisitExpression(Expression expression, Context context)
        {
            switch (expression)
            {
                case BinaryOperatorExpression e:
                    VisitBinaryOperatorExpression(e, context);
                    break;
                case UnaryOperatorExpression e:
                    VisitUnaryOperatorExpression(e, context);
                    break;
                case IdExpression e:
                    VisitIdExpression(e, context);
                    break;
                case IntLiteralExpression e:
                    VisitIntLiteralExpression(e, context);
                    break;
                case BoolLiteralExpression e:
                    VisitBoolLiteralExpression(e, context);
                    break;
                default:
                    throw new NotImplementedException($"Unknown expression: {expression}");
            };
        }

        private static void VisitBinaryOperatorExpression(BinaryOperatorExpression e, Context context)
        {
            VisitExpression(e.LeftOperand, context);
            VisitExpression(e.RightOperand, context);
        }

        private static void VisitUnaryOperatorExpression(UnaryOperatorExpression e, Context context)
        {
            VisitExpression(e.Operand, context);
        }

        private static void VisitIdExpression(IdExpression e, Context context)
        {
            VisitIdNode(e.Id, context);
        }

        private static void VisitIdNode(IdNode id, Context context)
        {
            
        }

        private static void VisitIntLiteralExpression(IntLiteralExpression intLiteral, Context context)
        {
            var val = LLVM.ConstReal(LLVM.Int32Type(), intLiteral.Value);
            context.ValueStack.Push(val);
        }

        private static void VisitBoolLiteralExpression(BoolLiteralExpression boolLiteral, Context context)
        {
            var val = LLVM.ConstReal(LLVM.Int8Type(), boolLiteral.Value ? 1 : 0);
            context.ValueStack.Push(val);
        }
    }
}
