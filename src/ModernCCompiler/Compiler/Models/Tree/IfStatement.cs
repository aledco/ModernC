using Compiler.Context;
using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The if statement.
    /// </summary>
    public class IfStatement : Statement
    {
        /// <summary>
        /// Gets the if expression.
        /// </summary>
        public Expression IfExpression { get; }

        /// <summary>
        /// Gets the if body.
        /// </summary>
        public CompoundStatement IfBody { get; }

        /// <summary>
        /// Gets the elif expressions.
        /// </summary>
        public IList<Expression> ElifExpressions { get; }

        /// <summary>
        /// Gets the elif bodies.
        /// </summary>
        public IList<CompoundStatement> ElifBodies {get;}

        /// <summary>
        /// Gets the else body.
        /// </summary>
        public CompoundStatement? ElseBody { get; }

        /// <summary>
        /// Initializes a new instance of a <see cref="IfStatement"/>.S
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="ifExpression">The if expression.</param>
        /// <param name="ifBody">The if body.</param>
        /// <param name="elifExpressions">The elif expressions.</param>
        /// <param name="elifBodies">The elif bodies.</param>
        /// <param name="elseBody">The else body.</param>
        public IfStatement(
            Span span, 
            Expression ifExpression, 
            CompoundStatement ifBody,
            IList<Expression> elifExpressions,
            IList<CompoundStatement> elifBodies,
            CompoundStatement? elseBody) : base(span)
        {
            IfExpression = ifExpression;
            IfBody = ifBody;
            ElifExpressions = elifExpressions;
            ElifBodies = elifBodies;
            ElseBody = elseBody;
        }

        public override bool AllPathsReturn()
        {
            return
                IfBody.AllPathsReturn() 
                && ElifBodies.All(b  => b.AllPathsReturn()) 
                && (ElseBody != null && ElseBody.AllPathsReturn());
        }

        public override SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context)
        {
            return GlobalSemanticCheckContext.StatementNotValidGlobally(this);
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            var ifExpressionType = IfExpression.CheckLocalSemantics(context);
            if (ifExpressionType is not BoolType)
            {
                ErrorHandler.Throw("If expression must be of type boolean", this);
            }

            IfBody.CheckLocalSemantics(context);

            foreach (var e in ElifExpressions)
            {
                var elifExpressionType = e.CheckLocalSemantics(context);
                if (elifExpressionType is not BoolType)
                {
                    ErrorHandler.Throw("If expression must be of type boolean", this);
                }
            }

            foreach (var b in ElifBodies)
            {
                b.CheckLocalSemantics(context);
            }

            ElseBody?.CheckLocalSemantics(context);
            return SemanticType.NoType;
        }
    }
}
