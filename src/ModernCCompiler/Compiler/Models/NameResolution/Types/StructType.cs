namespace Compiler.Models.NameResolution.Types
{
    /// <summary>
    /// The struct type.
    /// </summary>
    public class StructType : UserDefinedType
    {
        /// <summary>
        /// Gets the field types.
        /// </summary>
        public IList<(SemanticType Type, string Value)> FieldTypes { get; }

        /// <summary>
        /// Instantiates a new instance of a <see cref="StructType"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="fieldTypes">The field types.</param>
        public StructType(string value, IList<(SemanticType Type, string Value)> fieldTypes) : base(value)
        {
            FieldTypes = fieldTypes;
        }

        public override int GetSizeInBytes()
        {
            var size = 0;
            foreach (var field in FieldTypes)
            {
                size += field.Type.GetSizeInBytes();
            }

            return size;
        }

        public override int GetSizeInWords()
        {
            var size = 0;
            foreach (var field in FieldTypes)
            {
                size += field.Type.GetSizeInWords();
            }

            return size;
        }
    }
}
