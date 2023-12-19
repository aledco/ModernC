using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Tree;

namespace Compiler.Context
{
    /// <summary>
    /// The global semantic check context.
    /// </summary>
    public class GlobalSemanticCheckContext : SemanticCheckContext
    {
        /// <summary>
        /// Instantiates a new instance of a <see cref="GlobalSemanticCheckContext"/>.
        /// </summary>
        public GlobalSemanticCheckContext() : base()
        {
        }

        /// <summary>
        /// Called when a statement is not valid globally.
        /// </summary>
        /// <param name="s">The statement.</param>
        /// <returns></returns>
        public static SemanticType StatementNotValidGlobally(Statement s)
        {
            ErrorHandler.Throw("Statement cannot be made globally", s);
            throw ErrorHandler.FailedToExit;
        }

        /// <summary>
        /// Called when an expression is not valid globally.
        /// </summary>
        /// <param name="e">The expression.</param>
        /// <returns></returns>
        public static SemanticType ExpressionNotValidGlobaly(Expression e)
        {
            ErrorHandler.Throw("Expression cannot be made globally", e);
            throw ErrorHandler.FailedToExit;
        }
    }
}
