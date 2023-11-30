namespace Compiler.Models.NameResolution.Types
{
    public class FloatType : RealType
    {
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
            return other is RealType;
        }
    }
}
