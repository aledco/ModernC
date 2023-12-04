using System.Reflection.Metadata.Ecma335;

namespace Compiler.Models.Tree
{
    public class ArrayLiteralExpression : ComplexLiteralExpression
    {
        public IList<Expression> Elements { get; }
        public int Offset { get; set; }

        public ArrayLiteralExpression(Span span, IList<Expression> elements) : base(span)
        {
            Elements = elements;
        }

        public override Expression Copy(Span span)
        {
            return new ArrayLiteralExpression(span, Elements);
        }
    }
}
