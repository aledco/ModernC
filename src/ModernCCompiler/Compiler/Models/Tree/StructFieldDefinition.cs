using Compiler.Context;
using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The struct field definition.
    /// </summary>
    public class StructFieldDefinition : AbstractSyntaxTree
    {
        /// <summary>
        /// Gets the type.
        /// </summary>
        public TypeNode Type { get; }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public IdNode Id { get; }

        /// <summary>
        /// Gets the default expression.
        /// </summary>
        public Expression? DefaultExpression { get; }

        /// <summary>
        /// Gets or sets the offset for code generation.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Initializes a new instance of a <see cref="StructFieldDefinition"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="type">The type.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="expression">The default expression.</param>
        public StructFieldDefinition(Span span, TypeNode type, IdNode id, Expression? expression) : base(span)
        {
            Type = type;
            Id = id;
            DefaultExpression = expression;
        }

        /// <summary>
        /// Creates a struct literal field for this field definition.
        /// </summary>
        /// <param name="span">The span of the struct literal.</param>
        /// <returns>The struct literal field.</returns>
        /// <exception cref="Exception"></exception>
        public StructLiteralField CreateDefaultLiteralField(Span span)
        {
            return new StructLiteralField(span, new IdNode(span, Id.Value), DefaultExpression!.Copy(span));
        }

        public override SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context)
        {
            throw new NotImplementedException();
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            var type = Type.ToSemanticType();
            if (type is ArrayType arrayType && !arrayType.Length.HasValue)
            {
                ErrorHandler.Throw("Array length must be known in struct definition");
            }

            if (DefaultExpression != null)
            {
                context.AssignmentLeftHandSideType = type;
                var expressionType = DefaultExpression.CheckLocalSemantics(context);
                if (!type.TypeEquals(expressionType))
                {
                    ErrorHandler.Throw("Default expression type must match", this);
                }
            }

            return type;
        }
    }
}
