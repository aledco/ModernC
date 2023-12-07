using Compiler.Models.NameResolution.Types;
using Compiler.Models.Operators;

namespace Compiler.Models.Tree
{
    public abstract class TailedExpression : Expression
    {
        public Expression Left { get; protected set; }

        protected TailedExpression(Span span, Expression left) : base(span)
        {
            Left = left;
        }

        public SemanticType? GetOperatingType()
        {
            return Left switch
            {
                IdExpression e => e.Id.Symbol?.Type,
                FieldAccessExpression e => e.Type,
                UnaryOperatorExpression e => e.Type,
                TailedExpression e => e.GetOperatingType(),
                _ => throw new NotImplementedException()
            };
        }
    }
}
