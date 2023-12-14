using Compiler.Models.Context;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    public class Parameter : AbstractSyntaxTree
    {
        public TypeNode Type { get; }
        public IdNode Id { get; }

        public Parameter(Span span, TypeNode type, IdNode id) : base(span)
        {
            this.Type = type;
            this.Id = id;
        }

        public override SemanticType GlobalTypeCheck(GlobalTypeCheckContext context)
        {
            var type = Type.ToSemanticType();
            context.Scope!.AddSymbol(Id, type);
            Id.GlobalTypeCheck(context);
            return type;
        }
    }
}
