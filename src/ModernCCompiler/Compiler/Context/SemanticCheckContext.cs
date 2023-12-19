using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Context
{
    /// <summary>
    /// The base semantic check context.
    /// </summary>
    public abstract class SemanticCheckContext
    {
        /// <summary>
        /// Gets or sets the scope.
        /// </summary>
        public Scope Scope { get; set; }

        /// <summary>
        /// Gets or sets the type of the left hand side of an assignment.
        /// </summary>
        public SemanticType? AssignmentLeftHandSideType { get; set; }

        /// <summary>
        /// Instantiates a new instance of a <see cref="SemanticCheckContext"/>.
        /// </summary>
        public SemanticCheckContext()
        {
            Scope = SymbolTable.GlobalScope;
        }
    }
}
