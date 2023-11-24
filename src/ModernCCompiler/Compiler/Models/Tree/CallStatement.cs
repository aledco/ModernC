namespace Compiler.Models.Tree
{
    internal class CallStatement : Statement
    {
        public CallExpression CallExpression { get; }

        public CallStatement(Span span, CallExpression callExpression) : base(span)
        {
            CallExpression = callExpression;
        }
    }
}
