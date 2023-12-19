using Compiler.Context;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The id expression.
    /// </summary>
    public class IdExpression : Expression
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public IdNode Id { get; }

        /// <summary>
        /// Initializes a new instance of a <see cref="IdExpression"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="id">The identifier.</param>
        public IdExpression(Span span, IdNode id) : base(span)
        {
            Id = id;
        }

        public override Expression Copy(Span span)
        {
            return new IdExpression(span, Id);
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
        /// Checks the semantics of the expression.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The type.</returns>
        private SemanticType CheckSemantics(SemanticCheckContext context)
        {
            Type = Id.CheckSemanticsInferred(context);
            return Type;
        }
    }
}
