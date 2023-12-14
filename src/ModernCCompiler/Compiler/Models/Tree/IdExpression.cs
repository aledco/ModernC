using Compiler.Models.Context;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    public class IdExpression : Expression
    {
        public IdNode Id { get; }

        public IdExpression(Span span, IdNode id) : base(span)
        {
            Id = id;
        }

        public override Expression Copy(Span span)
        {
            return new IdExpression(span, Id);
        }

        public override SemanticType GlobalTypeCheck(GlobalTypeCheckContext context)
        {
            Type = Id.GlobalTypeCheck(context);
            return Type;
        }
    }
}
