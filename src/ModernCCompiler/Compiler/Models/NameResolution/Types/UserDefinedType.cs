namespace Compiler.Models.NameResolution.Types
{
    public abstract class UserDefinedType : SemanticType
    {
        public string Value { get; }

        public UserDefinedType(string value) 
        { 
            Value = value;
        }

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
            return other is UserDefinedType otherType && Value == otherType.Value;
        }
    }
}
