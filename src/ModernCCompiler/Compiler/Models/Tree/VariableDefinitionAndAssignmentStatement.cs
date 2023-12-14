using Compiler.ErrorHandling;
using Compiler.Models.Context;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Operators;

namespace Compiler.Models.Tree
{
    public class VariableDefinitionAndAssignmentStatement : Statement
    {
        public TypeNode Type { get; }
        public IdNode Id { get; }
        public AssignmentOperator Operator { get; }
        public Expression Expression { get; }

        public VariableDefinitionAndAssignmentStatement(Span span, TypeNode type, IdNode id, Expression expression) : base(span)
        {
            Type = type;
            Id = id;
            Expression = expression;
        }

        public override bool AllPathsReturn()
        {
            return false;
        }

        public override SemanticType GlobalTypeCheck(GlobalTypeCheckContext context)
        {
            var type = Type.ToSemanticType();
            if (type.IsParameterized)
            {
                ErrorHandler.Throw("Type can only be used in function parameters");
            }
            else if (type is PointerType)
            {
                ErrorHandler.Throw("Pointers cannot be global", this);
            }

            context.Scope?.AddSymbol(Id, type);
            context.VariableAssignmentType = type;
            Id.GlobalTypeCheck(context);
            var expressionType = Expression.GlobalTypeCheck(context);
            if (type is ArrayType assignArrayType && !assignArrayType.Length.HasValue)
            {
                if (Expression is ComplexLiteralExpression && expressionType is ArrayType literalArrayType)
                {
                    if (Type is ArrayTypeNode typeNode)
                    {
                        typeNode.Length = literalArrayType.Length;
                        type = typeNode.ToSemanticType();
                    }
                    else if (Type is UserDefinedTypeNode)
                    {
                        assignArrayType.Length = literalArrayType.Length;
                    }
                }
                else
                {
                    ErrorHandler.Throw("Arrays must be declared with a size", this);
                }
            }

            if (!type.TypeEquals(expressionType))
            {
                ErrorHandler.Throw("Variable assignment must have matching types.", this);
            }

            return type;
        }
    }
}
