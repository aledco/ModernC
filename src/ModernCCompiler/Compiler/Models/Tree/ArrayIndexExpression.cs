namespace Compiler.Models.Tree
{
    public class ArrayIndexExpression : TailedExpression
    {
        public Expression Array { get; }
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
    }
}
