using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The byte type node.
    /// </summary>
    public class ByteTypeNode : PrimitiveTypeNode
    {
        /// <summary>
        /// Initializes a new instance of a <see cref="ByteTypeNode"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        public ByteTypeNode(Span span) : base(span)
        {
        }

        public override SemanticType ToSemanticType()
        {
            return new ByteType();
        }
    }
}
