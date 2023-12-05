namespace Compiler.Models.Tree
{
    public abstract class ComplexLiteralExpression : Expression
    {
        protected ComplexLiteralExpression(Span span) : base(span)
        {
        }
    }
}
