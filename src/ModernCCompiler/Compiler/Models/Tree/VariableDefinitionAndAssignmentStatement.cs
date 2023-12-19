using Compiler.Context;
using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Operators;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The variabe definition and assignment statement.
    /// </summary>
    public class VariableDefinitionAndAssignmentStatement : Statement
    {
        /// <summary>
        /// Gets the type.
        /// </summary>
        public TypeNode Type { get; }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public IdNode Id { get; }

        /// <summary>
        /// Gets the operator.
        /// </summary>
        public AssignmentOperator Operator { get; }

        /// <summary>
        /// Gets the expression.
        /// </summary>
        public Expression Expression { get; }

        /// <summary>
        /// Instantiates a new instance of a <see cref="VariableDefinitionAndAssignmentStatement"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="type">The type.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="expression">The expression.</param>
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

        public override SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context)
        {
            return CheckSemantics(context);
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            return CheckSemantics(context);
        }

        /// <summary>
        /// Checks the semantics of the statement.
        /// </summary>
        /// <param name="context">The context;</param>
        /// <returns>The type.</returns>
        private SemanticType CheckSemantics(SemanticCheckContext context)
        {
            var type = Type.ToSemanticType();
            if (type.IsParameterized)
            {
                ErrorHandler.Throw("Parameterized type can only be used in function parameters");
            }
            if (context is GlobalSemanticCheckContext && type is PointerType)
            {
                ErrorHandler.Throw("Pointers cannot be global", this);
            }

            context.AssignmentLeftHandSideType = type;
            var expressionType = Expression.CheckSemanticsInferred(context);
            if (expressionType.IsComplex && Expression is not ComplexLiteralExpression)
            {
                ErrorHandler.Throw("Complex types cannot be reassigned.");
            }

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
                    ErrorHandler.Throw("Non array literals must be declared with a size", this);
                }
            }

            if (!type.TypeEquals(expressionType))
            {
                ErrorHandler.Throw("Variable assignment must have matching types.", this);
            }

            context.Scope.AddSymbol(Id, type);
            Id.CheckSemanticsInferred(context);
            return SemanticType.NoType;
        }
    }
}
