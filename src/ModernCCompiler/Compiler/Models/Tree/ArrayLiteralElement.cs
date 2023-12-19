using Compiler.Context;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The array literal element.
    /// </summary>
    public class ArrayLiteralElement : AbstractSyntaxTree
    {
        /// <summary>
        /// Gets the array literal expression.
        /// </summary>
        public Expression Expression { get; }

        /// <summary>
        /// Gets or sets the offset used for code generation.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Initializes a new instance of an <see cref="ArrayLiteralElement"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="expression">The expression.</param>
        public ArrayLiteralElement(Span span, Expression expression) : base(span)
        {
            Expression = expression;
        }

        public override SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context)
        {
            return Expression.CheckGlobalSemantics(context);
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            return Expression.CheckLocalSemantics(context);
        }
    }
}
