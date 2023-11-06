namespace Compiler.Models.Tree
{
    public class IntLiteralExpression : Expression
    {
        public int Value { get; }
        public IntLiteralExpression(Span span, int value) : base(span)
        {
            Value = value;
        }
    }
}
