using Compiler.Context;
using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The compound statement.
    /// </summary>
    public class CompoundStatement : Statement
    {
        /// <summary>
        /// The list of sub statements.
        /// </summary>
        public IList<Statement> Statements { get; }

        /// <summary>
        /// The scope of the compound statement.
        /// </summary>
        public Scope? LocalScope { get; set; }

        /// <summary>
        /// Initializes a new instance of a <see cref="CompoundStatement"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="statements">The list of statements.</param>
        public CompoundStatement(Span span, IList<Statement> statements) 
            : base(span)
        {
            Statements = statements;
        }

        public override bool AllPathsReturn()
        {
            return Statements.Any(s => s.AllPathsReturn());
        }

        public override SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context)
        {
            return GlobalSemanticCheckContext.StatementNotValidGlobally(this);
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            LocalScope = new Scope(context.Scope);
            foreach (var statement in Statements)
            {
                context.Scope = LocalScope;
                statement.CheckLocalSemantics(context);
            }

            return SemanticType.NoType;
        }
    }
}
