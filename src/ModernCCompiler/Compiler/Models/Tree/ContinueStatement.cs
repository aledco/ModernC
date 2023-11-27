namespace Compiler.Models.Tree
{
    public class ContinueStatement : Statement
    {
        public LoopStatement? EnclosingLoop { get; set; }

        public ContinueStatement(Span span) : base(span)
        {
        }
    }
}
