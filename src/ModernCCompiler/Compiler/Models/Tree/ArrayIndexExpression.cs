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
    }
}
