using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The void type node.
    /// </summary>
    public class VoidTypeNode : TypeNode
    {
        /// <summary>
        /// Instantiates a new instance of a <see cref="VoidTypeNode"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        public VoidTypeNode(Span span) : base(span)
        {
        }

        public override SemanticType ToSemanticType()
        {
            return new VoidType();
        }

        public override SemanticType ToSemanticTypeSafe()
        {
            return new VoidType();
        }
    }
}
