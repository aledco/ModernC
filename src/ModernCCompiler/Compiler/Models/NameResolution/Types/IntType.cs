namespace Compiler.Models.NameResolution.Types
{
    /// <summary>
    /// The int type.
    /// </summary>
    public class IntType : IntegralType
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
            return other is NumberType;
        }
    }
}
