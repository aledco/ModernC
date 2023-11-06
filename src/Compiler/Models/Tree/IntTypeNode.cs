namespace Compiler.Models.Tree
{
    public class IntTypeNode : PrimitiveTypeNode
    {
        public IntTypeNode(Span span) : base(span)
        {
        }

        public override string ToString()
        {
            return $"IntTypeNode(Span={Span})";
        }
    }
}
