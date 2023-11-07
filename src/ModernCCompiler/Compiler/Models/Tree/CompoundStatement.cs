using Compiler.Models.NameResolution;

namespace Compiler.Models.Tree
{
    public class CompoundStatement : Statement
    {
        public IEnumerable<Statement> Statements { get; }

        public Scope? LocalScope { get; set; }

        public CompoundStatement(Span span, IEnumerable<Statement> statements) 
            : base(span)
        {
            Statements = statements;
        }
    }
}
