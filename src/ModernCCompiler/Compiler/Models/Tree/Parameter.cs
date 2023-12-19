using Compiler.Context;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The parameter.
    /// </summary>
    public class Parameter : AbstractSyntaxTree
    {
        /// <summary>
        /// Gets the type.
        /// </summary>
        public TypeNode Type { get; }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public IdNode Id { get; }

        /// <summary>
        /// Initializes a new instance of a <see cref="Parameter"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="type">The type of the parameter.</param>
        /// <param name="id">The identifier.</param>
        public Parameter(Span span, TypeNode type, IdNode id) : base(span)
        {
            Type = type;
            Id = id;
        }

        public override SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context)
        {
            var type = Type.ToSemanticType();
            context.Scope.AddSymbol(Id, type);
            Id.CheckGlobalSemantics(context);
            return type;
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            throw new NotImplementedException();
        }
    }
}
