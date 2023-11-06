namespace Compiler.Models.Tree
{
    public abstract class AbstractSyntaxTree
    {
        public Span Span { get; }

        protected AbstractSyntaxTree(Span span) 
        {
            Span = span;
        }
    }
}
