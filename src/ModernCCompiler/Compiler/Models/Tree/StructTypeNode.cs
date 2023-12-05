using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    public class StructTypeNode : UserDefinedTypeNode
    {
        public IList<StructFieldDefinition> FieldTypes { get; }

        public StructTypeNode(Span span, IdNode id, IList<StructFieldDefinition> fieldTypes) : base(span, id)
        {
            FieldTypes = fieldTypes;
        }

        public override UserDefinedType ToSemanticType()
        {
            return new StructType(Id.Value, FieldTypes.Select(t => (t.Type.ToSemanticType(), t.Id.Value)).ToList());
        }
    }
}
