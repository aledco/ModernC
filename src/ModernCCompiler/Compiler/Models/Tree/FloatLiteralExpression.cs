namespace Compiler.Models.Tree
{
    public class FloatLiteralExpression : Expression
    {
        public float Value { get; }

        public FloatLiteralExpression(Span span, float value) : base(span)
        {
            Value = value;
        }

        public override Expression Copy(Span span)
        {
            return new FloatLiteralExpression(span, Value);
        }
    }
}
