namespace Compiler.Models.Tree
{
    public class ArgumentList : AbstractSyntaxTree
    {
        public IList<Expression> Arguments { get; }

        public ArgumentList(Span span, IList<Expression> arguments) : base(span)
        {
            Arguments = arguments;
        }

        public ArgumentList() : base(new Span(-1, -1, -1, -1))
        {
            Arguments = new List<Expression>();
        }
    }
}
