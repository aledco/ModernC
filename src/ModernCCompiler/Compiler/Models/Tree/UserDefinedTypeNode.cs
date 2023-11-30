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

        public override UserDefinedType ToSemanticType()
        {
            return SymbolTable.LookupType(this);
        }
    }
}
