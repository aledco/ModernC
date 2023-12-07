using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    public class PointerTypeNode : TypeNode
    {
        public TypeNode UnderlyingType { get; }

        public PointerTypeNode(Span span, TypeNode underlyingType) : base(span)
        {
            UnderlyingType = underlyingType;
        }

        public override SemanticType ToSemanticType()
        {
            return new PointerType(UnderlyingType.ToSemanticType());
        }
    }
}
