namespace Compiler.Models.Tree
{
    public class AssignmentStatement : Statement
    {
        public Expression Left { get; set; }
        public Expression Right { get; set; }

        public AssignmentStatement(Span span, Expression left, Expression right) : base(span)
        {
            Left = left;
            Right = right;
        }
    }
}
