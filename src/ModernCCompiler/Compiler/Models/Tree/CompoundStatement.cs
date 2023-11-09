using Compiler.Models.NameResolution;

namespace Compiler.Models.Tree
{
    public class CompoundStatement : Statement
    {
        public IList<Statement> Statements { get; }

        public Scope? LocalScope { get; set; }

        public CompoundStatement(Span span, IList<Statement> statements) 
            : base(span)
        {
            Statements = statements;
        }
    }
}
