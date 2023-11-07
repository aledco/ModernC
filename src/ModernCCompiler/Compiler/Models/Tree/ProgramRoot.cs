using Compiler.Models.NameResolution;

namespace Compiler.Models.Tree
{
    public class ProgramRoot : AbstractSyntaxTree
    {
        public IEnumerable<FunctionDefinition> FunctionDefinitions { get; }
        public Scope? GlobalScope { get; set; }

        public ProgramRoot(Span span, IEnumerable<FunctionDefinition> functionDefinitions) : base(span)
        {
            FunctionDefinitions = functionDefinitions;
        }
    }
}
