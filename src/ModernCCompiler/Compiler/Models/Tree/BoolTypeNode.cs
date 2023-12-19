using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The bool type node.
    /// </summary>
    public class BoolTypeNode : PrimitiveTypeNode
    {
        /// <summary>
        /// Initializes a new instance of a <see cref="BoolTypeNode"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        public BoolTypeNode(Span span) : base(span)
        {
        }

        public override SemanticType ToSemanticType()
        {
            return new BoolType();
        }
    }
}
