using Compiler.ErrorHandling;
using Compiler.Models.Symbols;

namespace Compiler.Models.NameResolution.Types
{
    /// <summary>
    /// The array type.
    /// </summary>
    public class ArrayType : SemanticType
    {
        /// <summary>
        /// Gets the element type.
        /// </summary>
        public SemanticType ElementType { get; }

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        public int? Length { get; set; }

        /// <summary>
        /// Gets the length parameter name.
        /// </summary>
        public string? LengthParameterName { get; }

        /// <summary>
        /// Gets or sets the length parameter symbol.
        /// </summary>
        public Symbol? LengthParameterSymbol { get; set; }

        public override SemanticType BaseType
        {
            get
            {
                return ElementType switch
                {
                    ArrayType t => t.BaseType,
                    _ => ElementType
                };
            }
        }

        public override bool IsParameterized { get => Length == null && LengthParameterName != null; }

        /// <summary>
        /// Instantiates a new instance of an <see cref="ArrayType"/>.
        /// </summary>
        /// <param name="elementType">The element type.</param>
        /// <param name="length">The length.</param>
        /// <param name="parameterName">The parameter name.</param>
        public ArrayType(SemanticType elementType, int? length, string? parameterName = null) 
        { 
            ElementType = elementType;
            Length = length;
            LengthParameterName = parameterName;
        }

        public override int GetSizeInBytes()
        {
            if (!Length.HasValue)
            {
                ErrorHandler.Throw("Array size must be known");
            }

            return ElementType.GetSizeInBytes() * Length!.Value;
        }

        public override int GetSizeInWords()
        {
            if (!Length.HasValue)
            {
                ErrorHandler.Throw("Array size must be known");
            }

            return ElementType.GetSizeInWords() * Length!.Value;
        }

        public override bool TypeEquals(SemanticType other)
        {
            return other is ArrayType otherType &&
                ElementType.TypeEquals(otherType.ElementType) &&
                (!Length.HasValue || !otherType.Length.HasValue || Length == otherType.Length);
        }
    }
}
