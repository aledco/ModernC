using Compiler.Models.Operators;

namespace Compiler.Models.Tree
{
    public class AssignmentStatement : Statement
    {
        public Expression Left { get; }
        public AssignmentOperator Operator { get; }
        public Expression Right { get; }
        public BinaryOperatorExpression? BinaryExpression { get; }

        public AssignmentStatement(Span span, Expression left, AssignmentOperator op, Expression right) : base(span)
        {
            Operator = op;
            Left = left;
            Right = right;

            BinaryExpression = op switch
            {
                AssignmentOperator.Equals => null,
                AssignmentOperator.PlusEquals => new BinaryOperatorExpression(span, BinaryOperator.Plus, left, right),
                AssignmentOperator.MinusEquals => new BinaryOperatorExpression(span, BinaryOperator.Minus, left, right),
                AssignmentOperator.TimesEquals => new BinaryOperatorExpression(span, BinaryOperator.Times, left, right),
                AssignmentOperator.DividedByEquals => new BinaryOperatorExpression(span, BinaryOperator.DividedBy, left, right),
                _ => throw new NotImplementedException()
            };
        }
    }
}
