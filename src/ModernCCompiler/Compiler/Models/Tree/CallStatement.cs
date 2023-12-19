using Compiler.Context;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The call statement.
    /// </summary>
    public class CallStatement : Statement
    {
        /// <summary>
        /// Gets the call expression.
        /// </summary>
        public CallExpression CallExpression { get; }

        /// <summary>
        /// Initializes a new instance of a <see cref="CallStatement"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="callExpression">The call expression.</param>
        public CallStatement(Span span, CallExpression callExpression) : base(span)
        {
            CallExpression = callExpression;
        }

        public override bool AllPathsReturn()
        {
            return false;
        }

        public override SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context)
        {
            return GlobalSemanticCheckContext.StatementNotValidGlobally(this);
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            CallExpression.IgnoreReturn = true;
            CallExpression.CheckLocalSemantics(context);
            return SemanticType.NoType;
        }
    }
}
