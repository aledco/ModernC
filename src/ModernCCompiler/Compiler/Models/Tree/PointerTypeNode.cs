using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The pointer type node.
    /// </summary>
    public class PointerTypeNode : TypeNode
    {
        /// <summary>
        /// Gets the underlying type.
        /// </summary>
        public TypeNode UnderlyingType { get; }

        /// <summary>
        /// Gets the base type.
        /// </summary>
        public TypeNode BaseType
        {
            get
            {
                return UnderlyingType switch
                {
                    PointerTypeNode p => p.BaseType,
                    _ => UnderlyingType
                };
            }
        }

        /// <summary>
        /// Instantiates a new instance of a <see cref="PointerTypeNode"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="underlyingType">The underlying type.</param>
        public PointerTypeNode(Span span, TypeNode underlyingType) : base(span)
        {
            UnderlyingType = underlyingType;
        }

        public override SemanticType ToSemanticType()
        {
            return new PointerType(UnderlyingType.ToSemanticType());
        }

        public override SemanticType ToSemanticTypeSafe()
        {
            return new PointerType(UnderlyingType.ToSemanticTypeSafe());
        }
    }
}
