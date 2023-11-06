namespace Compiler.Models.Tree
{
    public class Parameter : AbstractSyntaxTree
    {
        public TypeNode Type { get; }
        public IdNode Id { get; }

        public Parameter(Span span, TypeNode type, IdNode id) : base(span)
        {
            this.Type = type;
            this.Id = id;
        }
    }
}
