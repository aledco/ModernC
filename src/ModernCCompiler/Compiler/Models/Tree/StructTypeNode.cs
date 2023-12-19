using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The stuct type node.
    /// </summary>
    public class StructTypeNode : UserDefinedTypeNode
    {
        /// <summary>
        /// Gets the field definitons.
        /// </summary>
        public IList<StructFieldDefinition> Fields { get; } // TODO do this in a better way?

        /// <summary>
        /// Initializes a new instance of a <see cref="StructTypeNode"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="fieldTypes">The fields.</param>
        public StructTypeNode(Span span, IdNode id, IList<StructFieldDefinition> fieldTypes) : base(span, id)
        {
            Fields = fieldTypes;
        }

        public override UserDefinedType ToSemanticType()
        {
            return new StructType(Id.Value, Fields.Select(t => (t.Type.ToSemanticType(), t.Id.Value)).ToList());
        }

        public override UserDefinedType ToSemanticTypeSafe()
        {
            return new StructType(Id.Value, Fields.Select(t => (t.Type.ToSemanticTypeSafe(), t.Id.Value)).ToList());
        }
    }
}
