using Compiler.Models.Symbols;

namespace Compiler.Models.Tree
{
    public class IdNode : AbstractSyntaxTree
    {
        public string Value { get; }

        public Symbol? Symbol { get; set; }

        public IdNode(Span span, string value) : base(span)
        {
            Value = value;
        }
    }
}
