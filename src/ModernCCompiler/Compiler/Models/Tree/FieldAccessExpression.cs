namespace Compiler.Models.Tree
{
    public class FieldAccessExpression : TailedExpression
    {
        public IdNode Id { get; }
        public int Offset { get; set; }

        public FieldAccessExpression(Span span, Expression left, IdNode id) : base(span, left)
        {
            Id = id;
        }

        public override Expression Copy(Span span)
        {
            return new FieldAccessExpression(span, Left, Id);
        }
    }
}
