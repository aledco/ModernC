namespace Compiler.Models.Tree
{
    public class PrintLineStatement : Statement
    {
        public PrintStatement PrintExpression { get; }
        public PrintStatement PrintLine { get; }

        public PrintLineStatement(Span span, Expression expression) : base(span)
        {
            PrintExpression = new PrintStatement(span, expression);
            PrintLine = new PrintStatement(span, new ByteLiteralExpression(span, Convert.ToByte('\n')));
        }

        public override bool AllPathsReturn()
        {
            return false;
        }
    }
}
