using Compiler.Context;
using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;
using System.Text.Json.Serialization;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The return statement.
    /// </summary>
    public class ReturnStatement : Statement
    {
        /// <summary>
        /// Gets the expression.
        /// </summary>
        public Expression? Expression { get; }

        /// <summary>
        /// Gets or sets the enclosing function.
        /// </summary>
        [JsonIgnore]
        public FunctionDefinition? EnclosingFunction { get; set; }

        /// <summary>
        /// Instantiates a new instance of a <see cref="ReturnStatement"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="expression">The expression.</param>
        public ReturnStatement(Span span, Expression? expression) : base(span)
        {
            Expression = expression;
        }

        public override bool AllPathsReturn()
        {
            return true;
        }

        public override SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context)
        {
            return GlobalSemanticCheckContext.StatementNotValidGlobally(this);
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            if (context.EnclosingFunction?.Id?.Symbol?.Type is FunctionType functionType)
            {
                if (functionType.ReturnType is VoidType && Expression != null)
                {
                    ErrorHandler.Throw("Function has a return type of void and cannot return a value.", this);
                }
                else if (functionType.ReturnType is not VoidType && Expression == null)
                {
                    ErrorHandler.Throw("Function cannot have an empty return.", this);
                }

                if (Expression != null)
                {
                    var expressionType = Expression.CheckLocalSemantics(context);
                    if (functionType.ReturnType is not VoidType && !expressionType.TypeEquals(functionType.ReturnType))
                    {
                        ErrorHandler.Throw("Function return type does not match return value.", this);
                    }
                }

                EnclosingFunction = context.EnclosingFunction;
                return SemanticType.NoType;
            }
            else
            {
                throw new Exception("Enclosing function is null");
            }
        }
    }
}
