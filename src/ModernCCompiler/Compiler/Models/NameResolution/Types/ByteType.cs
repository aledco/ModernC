namespace Compiler.Models.NameResolution.Types
{
    /// <summary>
    /// The byte type.
    /// </summary>
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
