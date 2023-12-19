using Compiler.Context;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The print line statement.
    /// </summary>
    public class PrintLineStatement : Statement
    {
        /// <summary>
        /// Gets the print expression.
        /// </summary>
        public PrintStatement PrintExpression { get; }

        /// <summary>
        /// Gets the print line statement.
        /// </summary>
        public PrintStatement PrintLine { get; }

        public PrintLineStatement(Span span, Expression expression) : base(span)
        {
            PrintExpression = new PrintStatement(span, expression);
            PrintLine = new PrintStatement(span, new ByteLiteralExpression(span, Convert.ToByte('\n')));
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
            PrintExpression.CheckLocalSemantics(context);
            PrintLine.CheckLocalSemantics(context);
            return SemanticType.NoType;
        }
    }
}
