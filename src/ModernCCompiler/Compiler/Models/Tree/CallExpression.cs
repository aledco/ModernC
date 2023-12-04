namespace Compiler.Models.Tree
{
    public class CallExpression : TailedExpression
    {
        public Expression Function { get; }
        public ArgumentList ArgumentList { get; }
        public bool IgnoreReturn { get; set; } = false;
        public int ReturnOffset { get; set; }

        public CallExpression(Span span, Expression function, ArgumentList? args) : base(span, function)
        {
            Function = function;
            ArgumentList = args ?? new ArgumentList();
        }

        public override Expression Copy(Span span)
        {
            return new CallExpression(span, Function, ArgumentList);
        }
    }
}
