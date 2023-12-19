namespace Compiler.Models.Tree
{
    /// <summary>
    /// The definition base class.
    /// </summary>
    public abstract class Definition : AbstractSyntaxTree
    {
        /// <summary>
        /// Gets or sets the user defined type of the definition.
        /// </summary>
        public UserDefinedTypeNode Type { get; protected set; }

        /// <summary>
        /// Initializes a new instance of a <see cref="Definition"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="type">The type of the definiton.</param>
        public Definition(Span span, UserDefinedTypeNode type) : base(span)
        {
            Type = type;
        }
    }
}
