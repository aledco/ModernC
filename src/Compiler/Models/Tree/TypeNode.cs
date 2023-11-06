using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    internal abstract class TypeNode : AbstractSyntaxTree
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
