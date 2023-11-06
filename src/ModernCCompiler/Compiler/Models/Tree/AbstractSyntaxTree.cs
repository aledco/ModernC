namespace Compiler.Models.Tree
{
    public abstract class AbstractSyntaxTree
    {
        public Span Span { get; }
        public string NodeType { get; } // for debugging

        protected AbstractSyntaxTree(Span span) 
        {
            Span = span;
            NodeType = this.GetType().Name;
        }
    }
}
