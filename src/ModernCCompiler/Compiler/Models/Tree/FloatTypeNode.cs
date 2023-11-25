using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    public class FloatTypeNode : PrimitiveTypeNode
    {
        public FloatTypeNode(Span span) : base(span)
        {
        }

        public override SemanticType ToSemanticType()
        {
            return new FloatType();
        }
    }
}
