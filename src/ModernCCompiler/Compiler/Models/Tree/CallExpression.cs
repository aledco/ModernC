namespace Compiler.Models.Tree
{
    public class CallExpression : TailedExpression
    {
        public Expression Function { get; }
        public IList<Expression> Arguments { get; }
        public bool IgnoreReturn { get; set; } = false;
        public int ReturnOffset { get; set; }

        public CallExpression(Span span, Expression function, IList<Expression> args) : base(span, function)
        {
            Function = function;
            Arguments = args;
        }

        public override Expression Copy(Span span)
        {
            return new CallExpression(span, Function, Arguments);
        }
    }
}
