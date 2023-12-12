namespace Compiler.Models.Tree
{
    public class ArrayLiteralElement : AbstractSyntaxTree
    {
        public Expression Expression { get; }
        public int Offset { get; set; }

        public ArrayLiteralElement(Span span, Expression expression) : base(span)
        {
            Expression = expression;
        }
    }
}
