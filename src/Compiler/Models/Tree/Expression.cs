using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    public abstract class Expression : AbstractSyntaxTree
    {
        public SemanticType? Type { get; set; }

        protected Expression(Span span) : base(span)
        {
        }
    }
}
