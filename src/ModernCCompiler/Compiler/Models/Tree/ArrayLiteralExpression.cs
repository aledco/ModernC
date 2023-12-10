namespace Compiler.Models.Tree
{
    public class ArrayLiteralExpression : ComplexLiteralExpression
    {
        public IList<ArrayLiteralElement> Elements { get; }
        public int Offset { get; set; }

        public ArrayLiteralExpression(Span span, IList<ArrayLiteralElement> elements) : base(span)
        {
            Elements = elements;
        }

        public override Expression Copy(Span span)
        {
            return new ArrayLiteralExpression(span, Elements);
        }
    }
}
