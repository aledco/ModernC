using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    public class ByteTypeNode : PrimitiveTypeNode
    {
        public ByteTypeNode(Span span) : base(span)
        {
        }

        public override SemanticType ToSemanticType()
        {
            return new ByteType();
        }
    }
}
