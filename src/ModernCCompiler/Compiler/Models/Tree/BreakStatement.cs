namespace Compiler.Models.Tree
{
    public class BreakStatement : Statement
    {
        public LoopingStatement? EnclosingLoop { get; set; }

        public BreakStatement(Span span) : base(span)
        {
        }

        public override bool AllPathsReturn()
        {
            return false;
        }
    }
}
