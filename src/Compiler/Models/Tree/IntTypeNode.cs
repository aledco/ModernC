namespace Compiler.Models.Tree
{
    internal class IntTypeNode : PrimitiveTypeNode
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
