namespace Compiler.Models.Tree
{
    public class IntLiteralExpression : Expression
    {
        public int Value { get; }
        public IntLiteralExpression(Span span, int value) : base(span)
        {
            Value = value;
        }

        public override Expression Copy(Span span)
        {
            return new IntLiteralExpression(span, Value);
        }
    }
}
