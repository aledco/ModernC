using Compiler.Models.Symbols;

namespace Compiler.Models.Tree
{
    internal class CompoundStatement : Statement
    {
        public IEnumerable<Statement> Statements { get; }

        public Scope? LocalScope { get; set; }

        public CompoundStatement(Span span, IEnumerable<Statement> statements) 
            : base(span)
        {
            Statements = statements;
        }

        public override string ToString()
        {
            var statements = "[";
            foreach (var statement in Statements)
            {
                statements += statement.ToString() + ", ";
            }

            statements += "]";

            return $"CompoundStatement(Span={Span}, Statements={statements}, LocalScope={LocalScope})";
        }
    }
}
