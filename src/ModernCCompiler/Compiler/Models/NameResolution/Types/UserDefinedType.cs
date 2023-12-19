namespace Compiler.Models.NameResolution.Types
{
    /// <summary>
    /// The user defined type.
    /// </summary>
    public class UserDefinedType : SemanticType
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Instantiates a new instance of an <see cref="UserDefinedType"/>.
        /// </summary>
        /// <param name="value">The value.</param>
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
