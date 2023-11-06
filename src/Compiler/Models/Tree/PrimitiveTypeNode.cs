namespace Compiler.Models.Tree
{
    internal abstract class PrimitiveTypeNode : TypeNode
    {
        public PrimitiveTypeNode(Span span) : base(span)
        {
        }
    }
}
