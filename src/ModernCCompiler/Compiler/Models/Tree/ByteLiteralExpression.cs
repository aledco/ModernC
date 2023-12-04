namespace Compiler.Models.Tree
{
    public class ByteLiteralExpression : Expression
    {
        public byte Value { get; }

        public ByteLiteralExpression(Span span, byte value) : base(span)
        {
            Value = value;
        }

        public override Expression Copy(Span span)
        {
            return new ByteLiteralExpression(span, Value);
        }
    }
}
