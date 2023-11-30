namespace Compiler.Models.Tree
{
    public abstract class Definition : AbstractSyntaxTree
    {
        public UserDefinedTypeNode Type { get; set; }

        public Definition(Span span, UserDefinedTypeNode type) : base(span)
        {
            Type = type;
        }
    }
}
