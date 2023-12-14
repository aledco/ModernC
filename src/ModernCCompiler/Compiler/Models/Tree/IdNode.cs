using Compiler.Models.Context;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Symbols;

namespace Compiler.Models.Tree
{
    public class IdNode : AbstractSyntaxTree
    {
        /// <summary>
        /// Gets the value of the identifier.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Gets or sets the symbol of the identifier.
        /// </summary>
        public Symbol? Symbol { get; private set; }

        /// <summary>
        /// Initializes a new instance of an <see cref="IdNode"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="value">The value of the node.</param>
        public IdNode(Span span, string value) : base(span)
        {
            Value = value;
        }

        public override SemanticType GlobalTypeCheck(GlobalTypeCheckContext context)
        {
            Symbol = context.Scope!.LookupSymbol(this);
            return Symbol.Type;
        }
    }
}
