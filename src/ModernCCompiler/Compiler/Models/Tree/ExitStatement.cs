namespace Compiler.Models.Tree
{
    public class ExitStatement : Statement
    {
        public Expression Expression { get; }

        public ExitStatement(Span span, Expression expression) : base(span)
        {
            Expression = expression;
        }

        public override bool AllPathsReturn()
        {
            return true;
        }
    }
}
