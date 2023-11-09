using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Tree;

namespace Compiler.TreeWalking
{
    /// <summary>
    /// Does local type checking for compound statements.
    /// </summary>
    public class LocalTypeChecker : IWalker
    {
        private class Context
        {
            public Scope? Scope { get; set; }
            public FunctionDefinition? EnclosingFunction { get; set; }
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
            if (functionDefinition.FunctionScope == null)
            {
                throw new Exception("Function scope was null");
            }
            
            context.Scope = functionDefinition.FunctionScope;
            context.EnclosingFunction = functionDefinition;
            VisitCompoundStatement(functionDefinition.Body, context);
        }

        private static void VisitCompoundStatement(CompoundStatement body, Context context)
        {
            body.LocalScope = new Scope(context.Scope);
            context.Scope = body.LocalScope;
            foreach (var statement in  body.Statements)
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
            if (context.EnclosingFunction?.Id?.Symbol?.Type is FunctionType functionType)
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
                    var expressionType = VisitExpression(statement.Expression, context);
                    if (functionType.ReturnType is not VoidType && expressionType != functionType.ReturnType)
                    {
                        throw new Exception($"Function return type does not match return value: {statement.Span}");
                    }
                }

                statement.EnclosingFunction = context.EnclosingFunction;
                
            }
            else
            {
                throw new Exception("Enclosing function is null");
            }       
        }

        private static void VisitPrintStatement(PrintStatement statement, Context context)
        {
            var type = VisitExpression(statement.Expression, context);
            if (type.GetType() ==  typeof(VoidType))
            {
                throw new Exception($"Expressions can not have a type of void: {statement.Span}");
            }
        }

        private static void VisitVariableDefinitionStatement(VariableDefinitionStatement statement, Context context)
        {
            var type = statement.Type.ToSemanticType();
            context.Scope?.Add(statement.Id, type);
            VisitIdNode(statement.Id, context);
        }

        private static void VisitAssignmentStatement(AssignmentStatement statement, Context context)
        {
            var leftType = VisitExpression(statement.Left, context);
            var rightType = VisitExpression(statement.Right, context);
            if (leftType != rightType)
            {
                throw new Exception($"Variable assignment must have matching types: {statement.Span}");
            }
        }

        private static void VisitVariableDefinitionAndAssignmentStatement(VariableDefinitionAndAssignmentStatement statement, Context context)
        {
            var type = statement.Type.ToSemanticType();
            var expressionType = VisitExpression(statement.Expression, context);
            if (type != expressionType)
            {
                throw new Exception($"Variable assignment must have matching types: {statement.Span}");
            }

            context.Scope?.Add(statement.Id, type);
            VisitIdNode(statement.Id, context);
        }

        private static SemanticType VisitExpression(Expression expression, Context context)
        {
            return expression switch
            {
                BinaryOperatorExpression e => VisitBinaryOperatorExpression(e, context),
                UnaryOperatorExpression e => VisitUnaryOperatorExpression(e, context),
                IdExpression e => VisitIdExpression(e, context),
                IntLiteralExpression => new IntType(),
                BoolLiteralExpression => new BoolType(),
                _ => throw new NotImplementedException($"Unknown expression: {expression}"),
            };
        }

        private static SemanticType VisitBinaryOperatorExpression(BinaryOperatorExpression e, Context context)
        {
            var leftType = VisitExpression(e.LeftOperand, context);
            var rightType = VisitExpression(e.RightOperand, context);
            if (leftType != rightType)
            {
                throw new Exception($"Variable assignment must have matching types: {e.Span}");
            }

            return leftType;
        }

        private static SemanticType VisitUnaryOperatorExpression(UnaryOperatorExpression e, Context context)
        {
            return VisitExpression(e.Operand, context);
        }

        private static SemanticType VisitIdExpression(IdExpression e, Context context)
        {
            return VisitIdNode(e.Id, context);
        }

        private static SemanticType VisitIdNode(IdNode id, Context context)
        {
            id.Symbol = context?.Scope?.Lookup(id);
            if (id.Symbol == null) 
            {
                throw new Exception("Symbol is null");
            }
            
            return id.Symbol.Type;
        }
    }
}
