using Compiler.Models.NameResolution.Types;
using Compiler.Models.Operators;

namespace Compiler.Models.Tree
{
    public class FieldAccessExpression : TailedExpression
    {
        public IdNode Id { get; }
        public int Offset { get; set; }

        public FieldAccessExpression(Span span, Expression left, IdNode id) : base(span, left)
        {
            Id = id;
        }

        public override Expression Copy(Span span)
        {
            return new FieldAccessExpression(span, Left, Id);
        }

        public void AutoDereference()
        {
            // add dereference expressions until the concrete type is recovered. for auto dereferencing.
            var type = Left.Type;
            while (type is PointerType pointerType)
            {
                Left = new UnaryOperatorExpression(Span, UnaryOperator.Dereference, Left);
                type = pointerType.UnderlyingType;
            }
        }
    }
}
