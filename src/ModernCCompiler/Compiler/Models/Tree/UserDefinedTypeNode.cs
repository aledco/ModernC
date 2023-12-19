using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The user defined type node.
    /// </summary>
    public class UserDefinedTypeNode : TypeNode
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public IdNode Id { get; }

        /// <summary>
        /// Instantiates a new instance of an <see cref="UserDefinedTypeNode"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="id">The identifier.</param>
        public UserDefinedTypeNode(Span span, IdNode id) : base(span)
        {
            Id = id;
        }

        public override SemanticType ToSemanticType()
        {
            return SymbolTable.LookupType(this);
        }

        public override SemanticType ToSemanticTypeSafe()
        {
            if (SymbolTable.TryLookupType(this, out var type))
            {
                return type;
            }

            return new UserDefinedType(Id.Value);
        }
    }
}
