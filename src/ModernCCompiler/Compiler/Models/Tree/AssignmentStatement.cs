using Compiler.ErrorHandling;
using Compiler.Models.Context;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Operators;

namespace Compiler.Models.Tree
{
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

        public override SemanticType GlobalTypeCheck(GlobalTypeCheckContext context)
        {
            ErrorHandler.Throw("Assignment cannot be made globally", this);
            throw ErrorHandler.FailedToExit;
        }
    }
}
