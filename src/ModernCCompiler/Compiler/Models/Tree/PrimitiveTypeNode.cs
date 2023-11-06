namespace Compiler.Models.Tree
{
    public abstract class PrimitiveTypeNode : TypeNode
    {
        public PrimitiveTypeNode(Span span) : base(span)
        {
        }
    }
}
