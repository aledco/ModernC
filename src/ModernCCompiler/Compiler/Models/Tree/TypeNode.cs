using Compiler.Models.NameResolution.Types;
using System.Text.Json.Serialization;

namespace Compiler.Models.Tree
{
    [JsonDerivedType(typeof(VoidTypeNode))]
    [JsonDerivedType(typeof(IntTypeNode))]
    [JsonDerivedType(typeof(BoolTypeNode))]
    [JsonDerivedType(typeof(FunctionTypeNode))]
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
                FunctionTypeNode t => new FunctionType(t.ReturnType.ToSemanticType(), 
                                                       t.ParameterTypes.Select(p => p.ToSemanticType()).ToList()),
                var x => throw new Exception($"{x} is an invalid type: {Span}"),
            };
        }
    }
}
