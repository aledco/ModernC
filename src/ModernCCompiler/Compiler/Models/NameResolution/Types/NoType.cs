namespace Compiler.Models.NameResolution.Types
{
    public class NoType : SemanticType
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
            throw new NotImplementedException();
        }
    }
}
