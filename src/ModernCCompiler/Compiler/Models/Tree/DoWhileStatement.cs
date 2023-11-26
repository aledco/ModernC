namespace Compiler.Models.Tree
{
    public class DoWhileStatement : Statement
    {
        public CompoundStatement Body { get; }

        public Expression Expression { get; }
        
        public DoWhileStatement(Span span, CompoundStatement body, Expression expression) : base(span)
        {
            Body = body;
            Expression = expression;     
        }
    }
}
