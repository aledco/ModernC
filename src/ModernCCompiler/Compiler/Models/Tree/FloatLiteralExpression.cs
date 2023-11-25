namespace Compiler.Models.Tree
{
    public class FloatLiteralExpression : Expression
    {
        public float Value { get; }

        public FloatLiteralExpression(Span span, float value) : base(span)
        {
            Value = value;
        }
    }
}
