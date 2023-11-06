using Compiler.Models.Symbols;

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

        public override string ToString()
        {
            var functionDefinitions = "[";
            foreach (var functionDefinition in FunctionDefinitions)
            {
                functionDefinitions += functionDefinition.ToString() + ", ";
            }


            functionDefinitions += "]";
            return $"ProgramRoot(Span={Span}, FunctionDefinitions={functionDefinitions})";
        }
    }
}
