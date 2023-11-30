namespace Compiler.Models.Tree
{
    public class StructFieldDefinition : AbstractSyntaxTree
    {
        public TypeNode Type { get; }
        public IdNode Id { get; }
        public Expression? DefaultExpression { get; }

        public int Offset { get; set; }

        public StructFieldDefinition(Span span, TypeNode type, IdNode id, Expression? expression) : base(span)
        {
            Type = type;
            Id = id;
            DefaultExpression = expression;
        }
    }
}
