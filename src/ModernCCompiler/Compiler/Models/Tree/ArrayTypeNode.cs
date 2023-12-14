using Compiler.Models.Context;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    public class ArrayTypeNode : TypeNode
    {
        /// <summary>
        /// Gets the element type.
        /// </summary>
        public TypeNode ElementType { get; }

        /// <summary>
        /// Gets or sets the array length.
        /// </summary>
        public int? Length { get; set; }

        /// <summary>
        /// Initializes a new instance of an <see cref="ArrayTypeNode"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="elementType">The element type.</param>
        /// <param name="length">The length of the array.</param>
        public ArrayTypeNode(Span span, TypeNode elementType, int? length) : base(span)
        {
            ElementType = elementType;
            Length = length;
        }

        public override SemanticType ToSemanticType()
        {
            return new ArrayType(ElementType.ToSemanticType(), Length);
        }

        public override SemanticType GlobalTypeCheck(GlobalTypeCheckContext context)
        {
            throw new NotImplementedException();
        }
    }
}
