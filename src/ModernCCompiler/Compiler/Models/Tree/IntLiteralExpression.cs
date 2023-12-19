using Compiler.Context;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The int literal expression.
    /// </summary>
    public class IntLiteralExpression : Expression
    {
        /// <summary>
        /// Gets the value of the literal expression.
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Instantiates a new instance of <see cref="IntLiteralExpression"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="value">The value of the literal.</param>
        public IntLiteralExpression(Span span, int value) : base(span)
        {
            Value = value;
            Type = new IntType();
        }

        public override Expression Copy(Span span)
        {
            return new IntLiteralExpression(span, Value);
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
