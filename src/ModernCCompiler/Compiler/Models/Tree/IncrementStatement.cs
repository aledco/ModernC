using Compiler.Models.Operators;

namespace Compiler.Models.Tree
{
    public class IncrementStatement : Statement
    {
        public Expression Left { get; }
        public IncrementOperator Operator { get; }

        public IncrementStatement(Span span, Expression left, IncrementOperator op) : base(span)
        {
            Left = left;
            Operator = op;
        }
    }
}
