using Compiler.Models.NameResolution.Types;
using System.Text.Json.Serialization;

namespace Compiler.Models.Tree
{
    [JsonDerivedType(typeof(VoidTypeNode))]
    [JsonDerivedType(typeof(IntTypeNode))]
    [JsonDerivedType(typeof(ByteTypeNode))]
    [JsonDerivedType(typeof(FloatTypeNode))]
    [JsonDerivedType(typeof(BoolTypeNode))]
    [JsonDerivedType(typeof(FunctionTypeNode))]
    public abstract class TypeNode : AbstractSyntaxTree
    {
        protected TypeNode(Span span) : base(span)
        {
        }

        public abstract SemanticType ToSemanticType();
    }
}
