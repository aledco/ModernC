namespace Compiler.Models.NameResolution.Types
{
    public class UserDefinedType : SemanticType
    {
        public string Value { get; }

        public UserDefinedType(string value) 
        { 
            Value = value;
        }

        public override int GetSizeInBytes()
        {
            return SymbolTable.LookupType(this).GetSizeInBytes();
        }

        public override int GetSizeInWords()
        {
            return SymbolTable.LookupType(this).GetSizeInWords();
        }

        public override bool TypeEquals(SemanticType other)
        {
            return other is UserDefinedType otherType && Value == otherType.Value;
        }
    }
}
