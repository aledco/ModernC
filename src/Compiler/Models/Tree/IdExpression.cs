using Compiler.Models.Symbols;

namespace Compiler.Models.Tree
{
    internal class IdExpression : Expression
    {
        public IdNode Id { get; }

        public IdExpression(Span span, IdNode id) : base(span)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"IdExpression(Span={Span}, Id={Id})";
        }
    }
}
