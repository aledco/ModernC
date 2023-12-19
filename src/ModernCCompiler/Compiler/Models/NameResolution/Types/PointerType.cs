namespace Compiler.Models.NameResolution.Types
{
    /// <summary>
    /// The pointer ty[e.
    /// </summary>
    public class PointerType : SemanticType
    {
        /// <summary>
        /// Gets the underlying type.
        /// </summary>
        public SemanticType UnderlyingType { get; }

        public override SemanticType BaseType 
        {
            get
            {
                return UnderlyingType switch
                {
                    PointerType p => p.BaseType,
                    _ => UnderlyingType
                };
            }
        }

        /// <summary>
        /// Instantiates a new instance of a <see cref="PointerType"/>.
        /// </summary>
        /// <param name="underlyingType">The underlying type.</param>
        public PointerType(SemanticType underlyingType)
        {
            UnderlyingType = underlyingType;
        }

        public override int GetSizeInBytes()
        {
            return 4;
        }

        public override int GetSizeInWords()
        {
            return 1;
        }

        public override bool TypeEquals(SemanticType other)
        {
            return other is PointerType otherType && otherType.UnderlyingType.TypeEquals(UnderlyingType);
        }
    }
}
