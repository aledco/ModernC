using Compiler.Context;
using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Operators;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The increment statement.
    /// </summary>
    public class IncrementStatement : Statement
    {
        /// <summary>
        /// Gets the left hand side of the statement.
        /// </summary>
        public Expression Left { get; }

        /// <summary>
        /// Gets the operator.
        /// </summary>
        public IncrementOperator Operator { get; }

        /// <summary>
        /// Gets the register used for code generation.
        /// </summary>
        public string IncrementRegister { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of a <see cref="IncrementStatement"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="left">The left hand side of the expression.</param>
        /// <param name="op">The operator.</param>
        public IncrementStatement(Span span, Expression left, IncrementOperator op) : base(span)
        {
            Left = left;
            Operator = op;
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
            var leftType = Left.CheckLocalSemantics(context);
            if (leftType is not IntegralType)
            {
                ErrorHandler.Throw("Increment statements cannot be used on non integral types", this);
            }

            return SemanticType.NoType;
        }
    }
}
