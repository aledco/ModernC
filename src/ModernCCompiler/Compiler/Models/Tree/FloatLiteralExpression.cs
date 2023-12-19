using Compiler.Context;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The float literal expression.
    /// </summary>
    public class FloatLiteralExpression : Expression
    {
        /// <summary>
        /// Gets the value of the float literal.
        /// </summary>
        public float Value { get; }

        /// <summary>
        /// Initializes a new instance of a <see cref="FloatLiteralExpression"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="value">The value of the literal.</param>
        public FloatLiteralExpression(Span span, float value) : base(span)
        {
            Value = value;
            Type = new FloatType();
        }

        public override Expression Copy(Span span)
        {
            return new FloatLiteralExpression(span, Value);
        }

        public override SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context)
        {
            return Type!;
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            return Type!;
        }
    }
}
