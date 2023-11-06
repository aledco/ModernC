using Compiler.Models.NameResolution.Types;
using Compiler.Models.Symbols;
using Compiler.Models.Tree;

namespace Compiler.TreeWalking
{
    /// <summary>
    /// Does local type checking for compound statements.
    /// </summary>
    public class LocalTypeChecker : IWalker
    {
        public void Walk(ProgramRoot program)
        {
            VisitProgramRoot(program);
        }

        private static void VisitProgramRoot(ProgramRoot program)
        {
            foreach (var functionDefinition in program.FunctionDefinitions)
            {
                VisitFunctionDefinition(functionDefinition);
            }
        }

        private static void VisitFunctionDefinition(FunctionDefinition functionDefinition)
        {
            VisitCompoundStatement(functionDefinition.Body);
        }

        private static void VisitCompoundStatement(CompoundStatement body)
        {
            body.LocalScope = new Scope();
            foreach (var statement in  body.Statements)
            {
                VisitStatement(statement, body.LocalScope);
            }
        }

        private static void VisitStatement(Statement statement, Scope scope)
        {
            switch (statement)
            {
                case PrintStatement s:
                    VisitPrintStatement(s, scope); 
                    break;
                case VariableDefinitionStatement s:
                    VisitVariableDefinitionStatement(s, scope);
                    break;
                case AssignmentStatement s:
                    VisitAssignmentStatement(s, scope);
                    break;
                case VariableDefinitionAndAssignmentStatement s:
                    VisitVariableDefinitionAndAssignmentStatement(s, scope);
                    break;
                default:
                    throw new NotImplementedException($"Unknown statement {statement}");
            }
        }

        private static void VisitPrintStatement(PrintStatement statement, Scope scope)
        {
            var type = VisitExpression(statement.Expression, scope);
            if (type.GetType() ==  typeof(VoidType))
            {
                throw new Exception($"Expressions can not have a type of void: {statement.Span}");
            }
        }

        private static void VisitVariableDefinitionStatement(VariableDefinitionStatement statement, Scope scope)
        {
            var type = statement.Type.ToSemanticType();
            scope.Add(statement.Id, type);
            VisitIdNode(statement.Id, scope);
        }

        private static void VisitAssignmentStatement(AssignmentStatement statement, Scope scope)
        {
            var leftType = VisitExpression(statement.Left, scope);
            var rightType = VisitExpression(statement.Right, scope);
            if (leftType != rightType)
            {
                throw new Exception($"Variable assignment must have matching types: {statement.Span}");
            }
        }

        private static void VisitVariableDefinitionAndAssignmentStatement(VariableDefinitionAndAssignmentStatement statement, Scope scope)
        {
            var type = statement.Type.ToSemanticType();
            var expressionType = VisitExpression(statement.Expression, scope);
            if (type != expressionType)
            {
                throw new Exception($"Variable assignment must have matching types: {statement.Span}");
            }

            scope.Add(statement.Id, type);
            VisitIdNode(statement.Id, scope);
        }

        private static SemanticType VisitExpression(Expression expression, Scope scope)
        {
            return expression switch
            {
                BinaryOperatorExpression e => VisitBinaryOperatorExpression(e, scope),
                UnaryOperatorExpression e => VisitUnaryOperatorExpression(e, scope),
                IntLiteralExpression e => VisitIntLiteralExpression(e, scope),
                BoolLiteralExpression e => VisitBoolLiteralExpression(e, scope),
                IdExpression e => VisitIdExpression(e, scope),
                _ => throw new NotImplementedException($"Unknown expression: {expression}"),
            };
        }

        private static SemanticType VisitBinaryOperatorExpression(BinaryOperatorExpression e, Scope scope)
        {
            var leftType = VisitExpression(e.LeftOperand, scope);
            var rightType = VisitExpression(e.RightOperand, scope);
            if (leftType != rightType)
            {
                throw new Exception($"Variable assignment must have matching types: {e.Span}");
            }

            return leftType;
        }

        private static SemanticType VisitUnaryOperatorExpression(UnaryOperatorExpression e, Scope scope)
        {
            return VisitExpression(e.Operand, scope);
        }

        private static SemanticType VisitIntLiteralExpression(IntLiteralExpression e, Scope scope)
        {
            return new IntType();
        }

        private static SemanticType VisitBoolLiteralExpression(BoolLiteralExpression e, Scope scope)
        {
            return new BoolType();
        }

        private static SemanticType VisitIdExpression(IdExpression e, Scope scope)
        {
            return VisitIdNode(e.Id, scope);
        }

        private static SemanticType VisitIdNode(IdNode id, Scope scope)
        {
            id.Symbol = scope.Get(id);
            return id.Symbol.Type;
        }
    }
}
