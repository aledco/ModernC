using Compiler.Models.NameResolution.Types;
using Compiler.Models.Operators;

namespace Compiler.Models.Tree
{
    public class FieldCallExpression : CallExpression
    {
        public FieldAccessExpression FieldFunction { get; }
        public FieldCallExpression(Span span, FieldAccessExpression expression, IList<Expression> args) : base(span, expression, args)
        {
            FieldFunction = expression;
        }

        public override Expression Copy(Span span)
        {
            return new FieldCallExpression(Span, FieldFunction, Arguments);
        }

        public void AutoReference()
        {
            var type = Left.Type;
            if (type is UserDefinedType)
            {
                Left = new UnaryOperatorExpression(Span, UnaryOperator.AddressOf, Left);
            }
            else
            {
                while (type is PointerType pointerType && pointerType.UnderlyingType is not UserDefinedType)
                {
                    Left = new UnaryOperatorExpression(Span, UnaryOperator.Dereference, Left);
                    type = pointerType.UnderlyingType;
                }
            }
        }
    }
}
