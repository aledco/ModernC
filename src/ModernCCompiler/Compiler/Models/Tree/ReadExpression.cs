using Compiler.Context;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The read expression.
    /// </summary>
    public class ReadExpression : Expression
    {
        /// <summary>
        /// Instantiates a new instance of a <see cref="ReadExpression"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        public ReadExpression(Span span) : base(span)
        {
            Type = new ByteType();
        }

        public override Expression Copy(Span span)
        {
            return new ReadExpression(span);
        }

        public override SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context)
        {
            return GlobalSemanticCheckContext.ExpressionNotValidGlobaly(this);
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            return Type!;
        }
    }
}
