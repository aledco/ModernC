namespace Compiler.Models.NameResolution.Types
{
    public class ArrayType : SemanticType
    {
        public SemanticType ElementType { get; }
        public int Length { get; }

        public ArrayType(SemanticType elementType, int length) 
        { 
            ElementType = elementType;
            Length = length;
        }

        public override int GetSizeInBytes()
        {
            return ElementType.GetSizeInBytes() * Length;
        }

        public override int GetSizeInWords()
        {
            return ElementType.GetSizeInWords() * Length;
        }

        public override bool TypeEquals(SemanticType other)
        {
            return other is ArrayType otherType &&
                ElementType.TypeEquals(otherType.ElementType) &&
                Length == otherType.Length;
        }
    }
}
