using Compiler.Context;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The bool literal expression.
    /// </summary>
    public class BoolLiteralExpression : Expression
    {
        /// <summary>
        /// Gets the value of the bool literal.
        /// </summary>
        public bool Value { get; } 

        /// <summary>
        /// Initializes a new instance of a <see cref="BoolLiteralExpression"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="value">The value of the literal.</param>
        public BoolLiteralExpression(Span span, bool value) : base(span)
        {
            Value = value;
            Type = new BoolType();
        }

        public override Expression Copy(Span span)
        {
            return new BoolLiteralExpression(span, Value);
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
