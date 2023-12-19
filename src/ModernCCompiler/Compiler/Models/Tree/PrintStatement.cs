using Compiler.Context;
using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The print statement.
    /// </summary>
    public class PrintStatement : Statement
    {
        /// <summary>
        /// Gets the expression.
        /// </summary>
        public Expression Expression { get; set; }

        /// <summary>
        /// Instantiates a new instance of a <see cref="PrintStatement"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="expression">The expression.</param>
        public PrintStatement(Span span, Expression expression) : base(span)
        {
            Expression = expression;
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
            if (Expression is ComplexLiteralExpression)
            {
                ErrorHandler.Throw("Printing complex literals is not supported, store in a variable then print the variable", this);
            }

            Expression.CheckLocalSemantics(context);
            return SemanticType.NoType;
        }
    }
}
