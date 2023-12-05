namespace Compiler.Models.NameResolution.Types
{
    public class StructType : UserDefinedType
    {
        public IList<(SemanticType Type, string Value)> FieldTypes;

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
