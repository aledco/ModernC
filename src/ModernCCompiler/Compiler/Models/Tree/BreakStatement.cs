using Compiler.Context;
using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The break statement.
    /// </summary>
    public class BreakStatement : Statement
    {
        /// <summary>
        /// Gets or sets the enclosing loop of the break statement.
        /// </summary>
        public LoopingStatement? EnclosingLoop { get; private set; }

        /// <summary>
        /// Initializes a new instance of a <see cref="BreakStatement"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        public BreakStatement(Span span) : base(span)
        {
        }

        public override bool AllPathsReturn()
        {
            return false;
        }

        public override SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context)
        {
            return GlobalSemanticCheckContext.StatementNotValidGlobally(this);
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            if (context.EnclosingLoops.TryPeek(out var loop))
            {
                EnclosingLoop = loop;
            }
            else
            {
                ErrorHandler.Throw("Break statements can only be used inside a loop", this);
            }

            return SemanticType.NoType;
        }
    }
}
