using Compiler.Models.NameResolution.Types;
using System.Text.Json.Serialization;

namespace Compiler.Models.Tree
{
    [JsonDerivedType(typeof(VoidTypeNode))]
    [JsonDerivedType(typeof(IntTypeNode))]
    [JsonDerivedType(typeof(BoolTypeNode))]
    public abstract class TypeNode : AbstractSyntaxTree
    {
        protected TypeNode(Span span) : base(span)
        {
        }

        public SemanticType ToSemanticType()
        {
            return this switch
            {
                VoidTypeNode => new VoidType(),
                IntTypeNode => new IntType(),
                BoolTypeNode => new BoolType(),
                var x => throw new Exception($"{x} is an invalid type: {Span}"),
            };
        }
    }
}
