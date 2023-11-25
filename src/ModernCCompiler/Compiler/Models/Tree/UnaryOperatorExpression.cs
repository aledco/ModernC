using Compiler.Models.Operators;

namespace Compiler.Models.Tree
{
    public class UnaryOperatorExpression : Expression
    {
        public UnaryOperator Operator { get; }
        public Expression Operand { get; }

        public UnaryOperatorExpression(Span span, UnaryOperator op, Expression operand) : base(span)
        {
            Operator = op;
            Operand = operand;
        }
    }
}
