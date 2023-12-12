using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    public class UserDefinedTypeNode : TypeNode
    {
        public IdNode Id { get; }

        public UserDefinedTypeNode(Span span, IdNode id) : base(span)
        {
            Id = id;
        }

        public override SemanticType ToSemanticType()
        {
            if (SymbolTable.TryLookupType(this, out var type))
            {
                return type;
            }

            return new UserDefinedType(Id.Value);
        }
    }
}
