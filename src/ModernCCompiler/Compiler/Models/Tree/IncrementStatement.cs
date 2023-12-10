using Compiler.Models.Operators;

namespace Compiler.Models.Tree
{
    public class IncrementStatement : Statement
    {
        public Expression Left { get; }
        public IncrementOperator Operator { get; }
        public string IncrementRegister { get; set; } = string.Empty;

        public IncrementStatement(Span span, Expression left, IncrementOperator op) : base(span)
        {
            Left = left;
            Operator = op;
        }

        public override bool AllPathsReturn()
        {
            return false;
        }
    }
}
