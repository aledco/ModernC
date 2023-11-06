namespace Compiler.Models.Tree
{
    internal class VoidTypeNode : TypeNode
    {
        public VoidTypeNode(Span span) : base(span)
        {
        }

        public override string ToString()
        {
            return $"VoidType(Span={Span})";
        }
    }
}
