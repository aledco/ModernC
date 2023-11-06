namespace Compiler.Models.Tree
{
    public abstract class Statement : AbstractSyntaxTree
    {
        protected Statement(Span span) : base(span)
        {
        }
    }
}
