using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    public class VoidTypeNode : TypeNode
    {
        public VoidTypeNode(Span span) : base(span)
        {
        }

        public override SemanticType ToSemanticType()
        {
            return new VoidType();
        }
    }
}
