namespace Compiler.Models.Tree
{
    public class StructDefinition : Definition
    {
        public IList<StructFieldDefinition> Fields { get; }

        public StructDefinition(Span span, StructTypeNode type, IList<StructFieldDefinition> fields) : base(span, type)
        {
            Type = type;
            Fields = fields;
        }
    }
}
