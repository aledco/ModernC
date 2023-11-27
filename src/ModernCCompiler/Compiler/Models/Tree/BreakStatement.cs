namespace Compiler.Models.Tree
{
    public class BreakStatement : Statement
    {
        public LoopStatement? EnclosingLoop { get; set; }

        public BreakStatement(Span span) : base(span)
        {
        }
    }
}
