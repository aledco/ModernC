namespace Compiler.Models.Tree
{
    /// <summary>
    /// The complex literal expression.
    /// </summary>
    public abstract class ComplexLiteralExpression : Expression
    {
        /// <summary>
        /// Intitializes a new instance of a <see cref="ComplexLiteralExpression"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        protected ComplexLiteralExpression(Span span) : base(span)
        {
        }
    }
}
