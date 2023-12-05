using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    public class ArrayTypeNode : TypeNode
    {
        public TypeNode ElementType { get; }
        public int Length { get; }

        public ArrayTypeNode(Span span, TypeNode elementType, int length) : base(span)
        {
            ElementType = elementType;
            Length = length;
        }

        public override SemanticType ToSemanticType()
        {
            return new ArrayType(ElementType.ToSemanticType(), Length);
        }
    }
}
