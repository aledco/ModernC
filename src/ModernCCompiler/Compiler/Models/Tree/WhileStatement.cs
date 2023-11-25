namespace Compiler.Models.Tree
{
    public class WhileStatement : Statement
    {
        public Expression Expression { get; }
        public CompoundStatement Body { get; }

        public WhileStatement(Span span, Expression expression, CompoundStatement body) : base(span)
        {
            Expression = expression;
            Body = body;
        }
    }
}
