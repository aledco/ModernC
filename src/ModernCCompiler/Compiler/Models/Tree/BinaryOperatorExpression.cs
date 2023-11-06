namespace Compiler.Models.Tree
{
    public class BinaryOperatorExpression : Expression
    {
        public string Operator { get; }
        public Expression LeftOperand { get; }
        public Expression RightOperand { get; }

        public BinaryOperatorExpression(Span span, string op, Expression left, Expression right) : base(span)
        {
            Operator = op;
            LeftOperand = left;
            RightOperand = right;
        }

        public override string ToString()
        {
            return $"BinaryOperatorExpression(Span={Span}, Operator={Operator}, LeftOperand={LeftOperand}, RightOperand={RightOperand})";
        }
    }
}
