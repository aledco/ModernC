namespace Compiler.Models.NameResolution.Types
{
    public class ByteType : IntegralType
    {
        public override int GetSizeInBytes()
        {
            return 1;
        }

        public override int GetSizeInWords()
        {
            return 1;
        }

        public override bool TypeEquals(SemanticType other)
        {
            return other is NumberType;
        }
    }
}
