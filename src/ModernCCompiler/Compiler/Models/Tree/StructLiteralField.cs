namespace Compiler.Models.Tree
{
    public class StructLiteralField : AbstractSyntaxTree
    {
        public IdNode Id { get; } 
        public Expression Expression { get; }
        public int Offset { get; set; }

        public StructLiteralField(Span span, IdNode id, Expression expression) : base(span) // TODO might make the idNode just a string value
        {
            Id = id;
            Expression = expression;
        }
    }
}
