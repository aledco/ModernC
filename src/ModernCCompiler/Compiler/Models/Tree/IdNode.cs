using Compiler.Context;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Symbols;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The id node.
    /// </summary>
    public class IdNode : AbstractSyntaxTree
    {
        /// <summary>
        /// Gets the value of the identifier.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Gets or sets the symbol of the identifier.
        /// </summary>
        public Symbol? Symbol { get; set; }

        /// <summary>
        /// Initializes a new instance of an <see cref="IdNode"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="value">The value of the node.</param>
        public IdNode(Span span, string value) : base(span)
        {
            Value = value;
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
        /// Checks the semantics of the id node.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The type.</returns>
        private SemanticType CheckSemantics(SemanticCheckContext context)
        {
            Symbol = context.Scope.LookupSymbol(this);
            return Symbol.Type;
        }
    }
}
