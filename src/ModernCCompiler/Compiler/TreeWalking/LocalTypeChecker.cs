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
        private FunctionDefinition? _currentFunction;

        public void Walk(ProgramRoot program)
        {
            VisitProgramRoot(program);
        }

        private void VisitProgramRoot(ProgramRoot program)
        {
            foreach (var functionDefinition in program.FunctionDefinitions)
            {
                VisitFunctionDefinition(functionDefinition);
            }
        }

        private void VisitFunctionDefinition(FunctionDefinition functionDefinition)
        {
            _currentFunction = functionDefinition;
            VisitCompoundStatement(functionDefinition.Body);
        }

        private void VisitCompoundStatement(CompoundStatement body)
        {
            body.LocalScope = new Scope();
            foreach (var statement in  body.Statements)
            {
                VisitStatement(statement, body.LocalScope);
            }
        }

        private void VisitStatement(Statement statement, Scope scope)
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
                case ReturnStatement s:
                    VisitReturnStatement(s, scope);
                    break;
                default:
                    throw new NotImplementedException($"Unknown statement {statement}");
            }
        }

        private void VisitReturnStatement(ReturnStatement statement, Scope scope)
        {
            if (_currentFunction?.Id.Symbol != null && _currentFunction.Id.Symbol.Type is FunctionType functionType)
            {
                if (functionType.ReturnType is VoidType && statement.Expression != null)
                {
                    throw new Exception($"Function has a return type of void and cannot return a value: {statement.Span}");
                }
                else if (functionType.ReturnType is not VoidType && statement.Expression == null)
                {
                    throw new Exception($"Function cannot have an empty return: {statement.Span}");
                }

                if (statement.Expression != null)
                {
                    var expressionType = VisitExpression(statement.Expression, scope);
                    if (functionType.ReturnType is not VoidType && expressionType != functionType.ReturnType)
                    {
                        throw new Exception($"Function return type does not match return value: {statement.Span}");
                    }
                }
                
            }
            else
            {
                throw new Exception("_currentFunction is null");
            }       
        }

        private void VisitPrintStatement(PrintStatement statement, Scope scope)
        {
            var type = VisitExpression(statement.Expression, scope);
            if (type.GetType() ==  typeof(VoidType))
            {
                throw new Exception($"Expressions can not have a type of void: {statement.Span}");
            }
        }

        private void VisitVariableDefinitionStatement(VariableDefinitionStatement statement, Scope scope)
        {
            var type = statement.Type.ToSemanticType();
            scope.Add(statement.Id, type);
            VisitIdNode(statement.Id, scope);
        }

        private void VisitAssignmentStatement(AssignmentStatement statement, Scope scope)
        {
            var leftType = VisitExpression(statement.Left, scope);
            var rightType = VisitExpression(statement.Right, scope);
            if (leftType != rightType)
            {
                throw new Exception($"Variable assignment must have matching types: {statement.Span}");
            }
        }

        private void VisitVariableDefinitionAndAssignmentStatement(VariableDefinitionAndAssignmentStatement statement, Scope scope)
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

        private SemanticType VisitExpression(Expression expression, Scope scope)
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

        private SemanticType VisitBinaryOperatorExpression(BinaryOperatorExpression e, Scope scope)
        {
            var leftType = VisitExpression(e.LeftOperand, scope);
            var rightType = VisitExpression(e.RightOperand, scope);
            if (leftType != rightType)
            {
                throw new Exception($"Variable assignment must have matching types: {e.Span}");
            }

            return leftType;
        }

        private SemanticType VisitUnaryOperatorExpression(UnaryOperatorExpression e, Scope scope)
        {
            return VisitExpression(e.Operand, scope);
        }

        private SemanticType VisitIntLiteralExpression(IntLiteralExpression e, Scope scope)
        {
            return new IntType();
        }

        private SemanticType VisitBoolLiteralExpression(BoolLiteralExpression e, Scope scope)
        {
            return new BoolType();
        }

        private SemanticType VisitIdExpression(IdExpression e, Scope scope)
        {
            return VisitIdNode(e.Id, scope);
        }

        private SemanticType VisitIdNode(IdNode id, Scope scope)
        {
            id.Symbol = scope.Get(id);
            return id.Symbol.Type;
        }
    }
}
