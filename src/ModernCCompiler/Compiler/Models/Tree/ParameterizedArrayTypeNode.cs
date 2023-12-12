using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    public class ParameterizedArrayTypeNode : TypeNode
    {
        public TypeNode ElementType { get; }
        public IdNode Parameter { get; }

        public ParameterizedArrayTypeNode(Span span, TypeNode elementType, IdNode parameter) : base(span)
        {
            ElementType = elementType;
            Parameter = parameter;
        }

        public override SemanticType ToSemanticType()
        {
            return new ArrayType(ElementType.ToSemanticType(), null, Parameter.Value);
        }
    }
}
