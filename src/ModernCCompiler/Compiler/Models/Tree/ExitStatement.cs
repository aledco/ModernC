using Compiler.Context;
using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{

    /// <summary>
    /// The exit statement.
    /// </summary>
    public class ExitStatement : Statement
    {
        /// <summary>
        /// Gets the expression.
        /// </summary>
        public Expression Expression { get; }

        /// <summary>
        /// Initializes a new instance of a <see cref="ExitStatement"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="expression">The expression.</param>
        public ExitStatement(Span span, Expression expression) : base(span)
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
            var type = Expression.CheckLocalSemantics(context);
            if (type is not IntegralType)
            {
                ErrorHandler.Throw("Exit code must be an integer", this);
            }

            return SemanticType.NoType;
        }
    }
}
