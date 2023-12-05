using Compiler.Models.Operators;

namespace Compiler.Models.Tree
{
    public class AssignmentStatement : Statement
    {
        public Expression Left { get; }
        public AssignmentOperator Operator { get; }
        public Expression Right { get; }

        public AssignmentStatement(Span span, Expression left, AssignmentOperator op, Expression right) : base(span)
        {
            Operator = op;
            Left = left;
            Right = right;
        }

        public override bool AllPathsReturn()
        {
            return false;
        }
    }
}
