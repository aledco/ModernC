namespace Compiler.Models.Tree
{
    public class BoolTypeNode : PrimitiveTypeNode
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
