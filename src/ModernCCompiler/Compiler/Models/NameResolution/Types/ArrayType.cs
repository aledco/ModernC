using Compiler.ErrorHandling;
using Compiler.Models.Symbols;

namespace Compiler.Models.NameResolution.Types
{
    public class ArrayType : SemanticType
    {
        public SemanticType ElementType { get; }
        public int? Length { get; set; }
        public string? LengthParameterName { get; }
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
