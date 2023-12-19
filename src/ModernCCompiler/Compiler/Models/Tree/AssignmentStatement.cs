using Compiler.Context;
using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Operators;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The assignment statement.
    /// </summary>
    public class AssignmentStatement : Statement
    {
        /// <summary>
        /// Gets the left hand side expression.
        /// </summary>
        public Expression Left { get; }

        /// <summary>
        /// Gets the assignment operator.
        /// </summary>
        public AssignmentOperator Operator { get; }

        /// <summary>
        /// Gets the right hand side expression.
        /// </summary>
        public Expression Right { get; }

        /// <summary>
        /// Initializes a new instance of an <see cref="AssignmentStatement"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="left">The left hand side expression.</param>
        /// <param name="op">The operator.</param>
        /// <param name="right">The right hand side expression.</param>
        public AssignmentStatement(Span span, Expression left, AssignmentOperator op, Expression right) : base(span)
        {
            Operator = op;
            Left = left;
            Right = right;
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
            var rightType = Right.CheckLocalSemantics(context);
            if (rightType.IsComplex)
            {
                ErrorHandler.Throw("Complex types cannot be reassigned.");
            }

            var leftType = Left.CheckLocalSemantics(context);
            if (!leftType.TypeEquals(rightType))
            {
                ErrorHandler.Throw("Variable assignment must have matching types.", this);
            }

            return SemanticType.NoType;
        }
    }
}
