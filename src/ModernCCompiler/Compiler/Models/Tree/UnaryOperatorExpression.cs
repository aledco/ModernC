namespace Compiler.Models.Tree
{
    public class UnaryOperatorExpression : Expression
    {
        public string Operator { get; }
        public Expression Operand { get; }

        public UnaryOperatorExpression(Span span, string op, Expression operand) : base(span)
        {
            Operator = op;
            Operand = operand;
        }
    }
}
