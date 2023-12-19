using Compiler.Context;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The looping statement.
    /// </summary>
    public abstract class LoopingStatement : Statement
    {
        private int? _labelId = null;

        /// <summary>
        /// Gets or sets the label id.
        /// </summary>
        public int LabelId { protected get => _labelId!.Value; set => _labelId = value; }

        /// <summary>
        /// Initializes a new instance of a <see cref="LoopingStatement"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        protected LoopingStatement(Span span) : base(span)
        {
        }

        public override SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context)
        {
            return GlobalSemanticCheckContext.StatementNotValidGlobally(this);
        }

        /// <summary>
        /// Gets the loop label.
        /// </summary>
        /// <returns>The loop label.</returns>
        public abstract string GetLoopLabel();

        /// <summary>
        /// Gets the loop exit label.
        /// </summary>
        /// <returns>The exit label.</returns>
        public abstract string GetExitLabel();
    }
}
