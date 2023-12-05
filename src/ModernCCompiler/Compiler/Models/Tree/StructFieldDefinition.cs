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

        public StructLiteralField CreateDefaultLiteralField(Span span)
        {
            if (DefaultExpression == null) 
            {
                throw new Exception("DefaultExpression was null");
            }

            return new StructLiteralField(span, new IdNode(span, Id.Value), DefaultExpression.Copy(span));
        }
    }
}
