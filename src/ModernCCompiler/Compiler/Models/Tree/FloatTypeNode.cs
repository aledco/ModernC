using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The float type node.
    /// </summary>
    public class FloatTypeNode : PrimitiveTypeNode
    {
        /// <summary>
        /// Instantiates a new instance of a <see cref="FloatTypeNode"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        public FloatTypeNode(Span span) : base(span)
        {
        }

        public override SemanticType ToSemanticType()
        {
            return new FloatType();
        }
    }
}
