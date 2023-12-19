using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The parameterized array type node.
    /// </summary>
    public class ParameterizedArrayTypeNode : TypeNode
    {
        /// <summary>
        /// Gets the element type.
        /// </summary>
        public TypeNode ElementType { get; }

        /// <summary>
        /// Gets the parameter.
        /// </summary>
        public IdNode Parameter { get; }

        /// <summary>
        /// Initializes a new instance of a <see cref="ParameterizedArrayTypeNode"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="elementType"></param>
        /// <param name="parameter"></param>
        public ParameterizedArrayTypeNode(Span span, TypeNode elementType, IdNode parameter) : base(span)
        {
            ElementType = elementType;
            Parameter = parameter;
        }

        public override SemanticType ToSemanticType()
        {
            return new ArrayType(ElementType.ToSemanticType(), null, Parameter.Value);
        }

        public override SemanticType ToSemanticTypeSafe()
        {
            return new ArrayType(ElementType.ToSemanticTypeSafe(), null, Parameter.Value);
        }
    }
}
