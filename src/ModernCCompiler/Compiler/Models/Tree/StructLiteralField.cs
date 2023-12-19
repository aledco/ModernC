using Compiler.Context;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The struct literal field.
    /// </summary>
    public class StructLiteralField : AbstractSyntaxTree
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public IdNode Id { get; }
        
        /// <summary>
        /// Gets the expression.
        /// </summary>
        public Expression Expression { get; }

        /// <summary>
        /// Gets or sets the offset for code generation.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Initializes a new instance of a <see cref="StructLiteralField"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="expression">The expression.</param>
        public StructLiteralField(Span span, IdNode id, Expression expression) : base(span)
        {
            Id = id;
            Expression = expression;
        }

        public override SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context)
        {
            throw new NotImplementedException();
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            throw new NotImplementedException();
        }
    }
}
