using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    public class IntTypeNode : PrimitiveTypeNode
    {
        public IntTypeNode(Span span) : base(span)
        {
        }

        public override SemanticType ToSemanticType()
        {
            return new IntType();
        }
    }
}
