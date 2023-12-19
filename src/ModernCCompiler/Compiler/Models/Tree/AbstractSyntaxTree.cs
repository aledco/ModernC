using Compiler.Context;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The base abstract syntax tree node.
    /// </summary>
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
        /// Checks semantics by inferrring the semantic to check from the context passed in.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The type.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public SemanticType CheckSemanticsInferred(SemanticCheckContext context)
        {
            return context switch
            {
                GlobalSemanticCheckContext c => CheckGlobalSemantics(c),
                LocalSemanticCheckContext c => CheckLocalSemantics(c),
                _ => throw new InvalidOperationException()
            };
        }

        /// <summary>
        /// Performs the global type check on an AST node.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The type of the node.</returns>
        public abstract SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context);

        /// <summary>
        /// Performs the local type check on an AST node.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The type of the node.</returns>
        public abstract SemanticType CheckLocalSemantics(LocalSemanticCheckContext context);
    }
}
