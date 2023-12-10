using Compiler.Models.Symbols;

namespace Compiler.Models.NameResolution.Types
{
    public class ArrayType : SemanticType
    {
        public SemanticType ElementType { get; }
        public int? Length { get; }
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

        public override bool IsFunctionParameterOnly { get => Length == null; }

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
                throw new Exception("Length was null");
            }

            return ElementType.GetSizeInBytes() * Length.Value;
        }

        public override int GetSizeInWords()
        {
            if (!Length.HasValue)
            {
                throw new Exception("Length was null");
            }

            return ElementType.GetSizeInWords() * Length.Value;
        }

        public override bool TypeEquals(SemanticType other)
        {
            return other is ArrayType otherType &&
                ElementType.TypeEquals(otherType.ElementType) &&
                (!Length.HasValue || !otherType.Length.HasValue || Length == otherType.Length);
        }
    }
}
