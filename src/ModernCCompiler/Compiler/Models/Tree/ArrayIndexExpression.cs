using Compiler.Models.NameResolution.Types;
using Compiler.Models.Operators;

namespace Compiler.Models.Tree
{
    public class ArrayIndexExpression : TailedExpression
    {
        public Expression Array { get; private set; }
        public Expression Index { get; }

        public ArrayIndexExpression(Span span, Expression array, Expression index) : base(span, array)
        {
            Array = array;
            Index = index;
        }

        public override Expression Copy(Span span)
        {
            return new ArrayIndexExpression(span, Array, Index);
        }

        public void AutoDereference()
        {
            // add dereference expressions until the concrete type is recovered. for auto dereferencing.
            for (var type = Left.Type; type is PointerType pointerType; type = pointerType.UnderlyingType)
            {
                Left = new UnaryOperatorExpression(Span, UnaryOperator.Dereference, Left);
            }

            Array = Left;
        }
    }
}
