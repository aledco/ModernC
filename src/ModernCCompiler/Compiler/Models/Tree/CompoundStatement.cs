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

        public override bool AllPathsReturn()
        {
            return Statements.Any(s => s.AllPathsReturn()); // all code paths return if any of the sub statements return.
            // TODO drop any statements after a statement that returns?
        }
    }
}
