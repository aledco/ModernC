using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// Thee int type node.
    /// </summary>
    public class IntTypeNode : PrimitiveTypeNode
    {
        /// <summary>
        /// Initializes a new instance of a <see cref="IntTypeNode"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        public IntTypeNode(Span span) : base(span)
        {
        }

        public override SemanticType ToSemanticType()
        {
            return new IntType();
        }
    }
}
