namespace Compiler.Models.Tree
{
    public class ArrayLiteralExpression : Expression
    {
        public IList<Expression> Elements { get; }
        public int Offset { get; set; }

        public ArrayLiteralExpression(Span span, IList<Expression> elements) : base(span)
        {
            Elements = elements;
        }
    }
}
