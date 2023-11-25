using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    public class BoolTypeNode : PrimitiveTypeNode
    {
        public BoolTypeNode(Span span) : base(span)
        {
        }

        public override SemanticType ToSemanticType()
        {
            return new BoolType();
        }
    }
}
