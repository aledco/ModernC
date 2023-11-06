namespace Compiler.Models.Tree
{
    internal abstract class AbstractSyntaxTree
    {
        public Span Span { get; }

        protected AbstractSyntaxTree(Span span) 
        {
            Span = span;
        }
    }
}
