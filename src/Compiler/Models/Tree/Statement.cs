namespace Compiler.Models.Tree
{
    internal abstract class Statement : AbstractSyntaxTree
    {
        protected Statement(Span span) : base(span)
        {
        }
    }
}
