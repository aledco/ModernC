namespace Compiler.Models.Tree
{
    public class ContinueStatement : Statement
    {
        public LoopingStatement? EnclosingLoop { get; set; }

        public ContinueStatement(Span span) : base(span)
        {
        }

        public override bool AllPathsReturn()
        {
            return false;
        }
    }
}
