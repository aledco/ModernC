namespace Compiler.Models.Tree
{
    internal class BoolTypeNode : PrimitiveTypeNode
    {
        public BoolTypeNode(Span span) : base(span)
        {
        }

        public override string ToString()
        {
            return $"BoolTypeNode(Span={Span})";
        }
    }
}
