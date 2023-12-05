namespace Compiler.Models.Tree
{
    public class ReadExpression : Expression
    {
        public ReadExpression(Span span) : base(span)
        {
        }

        public override Expression Copy(Span span)
        {
            return new ReadExpression(span);
        }
    }
}
