using Compiler.Context;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The byte literal expression.
    /// </summary>
    public class ByteLiteralExpression : Expression
    {
        /// <summary>
        /// Gets the value of the byte literal.
        /// </summary>
        public byte Value { get; }

        /// <summary>
        /// Initializes a new instance of a <see cref="ByteLiteralExpression"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="value">The value of the literal.</param>
        public ByteLiteralExpression(Span span, byte value) : base(span)
        {
            Value = value;
            Type = new ByteType();
        }

        public override Expression Copy(Span span)
        {
            return new ByteLiteralExpression(span, Value);
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
