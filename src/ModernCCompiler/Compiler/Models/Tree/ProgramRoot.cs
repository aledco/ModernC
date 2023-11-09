using Compiler.Models.NameResolution;

namespace Compiler.Models.Tree
{
    public class ProgramRoot : AbstractSyntaxTree
    {
        public IList<FunctionDefinition> FunctionDefinitions { get; }
        public Scope? GlobalScope { get; set; }

        public ProgramRoot(Span span, IList<FunctionDefinition> functionDefinitions) : base(span)
        {
            FunctionDefinitions = functionDefinitions;
        }
    }
}
