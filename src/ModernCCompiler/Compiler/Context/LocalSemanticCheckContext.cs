using Compiler.Models.Tree;

namespace Compiler.Context
{
    /// <summary>
    /// The local semantic check context.
    /// </summary>
    public class LocalSemanticCheckContext : SemanticCheckContext
    {
        /// <summary>
        /// Gets or sets the enclosing function.
        /// </summary>
        public FunctionDefinition? EnclosingFunction { get; set; }

        /// <summary>
        /// Gets or sets the stack of enclosing loops.
        /// </summary>
        public Stack<LoopingStatement> EnclosingLoops { get; set; }

        /// <summary>
        /// Gets or sets the r-value function.
        /// </summary>
        public FunctionDefinition? RValueFunction { get; set; }

        /// <summary>
        /// Instantiates a new instance of a <see cref="LocalSemanticCheckContext"/>.
        /// </summary>
        public LocalSemanticCheckContext() : base()
        {
            EnclosingLoops = new();
        }
    }
}
