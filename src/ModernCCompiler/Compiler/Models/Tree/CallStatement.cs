namespace Compiler.Models.Tree
{
    public class CallStatement : Statement
    {
        public CallExpression CallExpression { get; }

        public CallStatement(Span span, CallExpression callExpression) : base(span)
        {
            CallExpression = callExpression;
        }

        public override bool AllPathsReturn()
        {
            return false;
        }
    }
}
