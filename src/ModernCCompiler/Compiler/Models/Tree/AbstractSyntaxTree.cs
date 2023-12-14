using Compiler.Models.Context;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    public abstract class AbstractSyntaxTree
    {
        /// <summary>
        /// Gets the span of the AST node.
        /// </summary>
        public Span Span { get; }

        /// <summary>
        /// Gets the type of the AST node for debugging.
        /// </summary>
        public string NodeType { get; }

        /// <summary>
        /// Initializes a new instance of an <see cref="AbstractSyntaxTree"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        protected AbstractSyntaxTree(Span span) 
        {
            Span = span;
            NodeType = GetType().Name;
        }

        /// <summary>
        /// Performs the global type check on an AST node.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The type of the node.</returns>
        public abstract SemanticType GlobalTypeCheck(GlobalTypeCheckContext context);
    }
}
