using Compiler.Models.Operators;

namespace Compiler.Models.Tree
{
    public class BinaryOperatorExpression : Expression
    {
        public BinaryOperator Operator { get; }
        public Expression LeftOperand { get; }
        public Expression RightOperand { get; }

        public BinaryOperatorExpression(Span span, BinaryOperator op, Expression left, Expression right) : base(span)
        {
            Operator = op;
            LeftOperand = left;
            RightOperand = right;
        }
    }
}
