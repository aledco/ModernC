using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The primitive type node.
    /// </summary>
    public abstract class PrimitiveTypeNode : TypeNode
    {
        /// <summary>
        /// Instantiates a new instance of a <see cref="PrimitiveTypeNode"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        public PrimitiveTypeNode(Span span) : base(span)
        {
        }

        public override SemanticType ToSemanticTypeSafe()
        {
            return ToSemanticType();
        }
    }
}
