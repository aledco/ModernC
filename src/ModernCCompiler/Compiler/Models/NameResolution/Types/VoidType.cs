namespace Compiler.Models.NameResolution.Types
{
    /// <summary>
    /// The void type.
    /// </summary>
    public class VoidType : SemanticType
    {
        public override int GetSizeInBytes()
        {
            throw new NotImplementedException();
        }

        public override int GetSizeInWords()
        {
            throw new NotImplementedException();
        }

        public override bool TypeEquals(SemanticType other)
        {
            return other is VoidType;
        }
    }
}
