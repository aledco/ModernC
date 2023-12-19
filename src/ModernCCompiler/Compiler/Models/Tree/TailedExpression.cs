using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The tailed expression.
    /// </summary>
    public abstract class TailedExpression : Expression
    {
        /// <summary>
        /// The left hand side of a tailed expression.
        /// </summary>
        public Expression Left { get; protected set; }

        /// <summary>
        /// Instantiates a new instance of a <see cref="TailedExpression"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="left">The left hand side of the expression.</param>
        protected TailedExpression(Span span, Expression left) : base(span)
        {
            Left = left;
        }

        /// <summary>
        /// Gets the type that this tailed expression operates on.
        /// </summary>
        /// <returns>The operating type.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public SemanticType? GetOperatingType()
        {
            return Left switch
            {
                IdExpression e => e.Id.Symbol?.Type.BaseType,
                FieldAccessExpression e => e.Type?.BaseType,
                UnaryOperatorExpression e => e.Type?.BaseType,
                TailedExpression e => e.GetOperatingType()?.BaseType,
                _ => throw new NotImplementedException()
            };
        }
    }
}
