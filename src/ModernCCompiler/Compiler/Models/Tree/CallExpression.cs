namespace Compiler.Models.Tree
{
    public class CallExpression : Expression
    {
        public IdExpression Function { get; }
        public ArgumentList ArgumentList { get; }

        public CallExpression(Span span, IdExpression function, ArgumentList? args) : base(span)
        {
            Function = function;
            ArgumentList = args ?? new ArgumentList();
        }
    }
}
