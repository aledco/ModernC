namespace Compiler.Models.Tree
{
    public class ReturnStatement : Statement
    {
        public Expression? Expression { get; }

        public ReturnStatement(Span span, Expression? expression) : base(span)
        {
            Expression = expression;
        }
    }
}
