namespace Compiler.Models.Tree
{
    public class PrintStatement : Statement
    {
        public Expression Expression { get; set; }

        public PrintStatement(Span span, Expression expression) : base(span)
        {
            Expression = expression;
        }
    }
}
