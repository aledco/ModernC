using Compiler.Context;
using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The while statement.
    /// </summary>
    public class WhileStatement : LoopingStatement
    {
        /// <summary>
        /// Gets the test expression.
        /// </summary>
        public Expression Expression { get; }

        /// <summary>
        /// Gets the body of the loop.
        /// </summary>
        public CompoundStatement Body { get; }

        /// <summary>
        /// Instantiates a new instance of a <see cref="WhileStatement"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="body">The body.</param>
        public WhileStatement(Span span, Expression expression, CompoundStatement body) : base(span)
        {
            Expression = expression;
            Body = body;
        }

        public override string GetLoopLabel()
        {
            return $"while_loop_{LabelId}";
        }

        public override string GetExitLabel()
        {
            return $"while_exit_{LabelId}";
        }

        public override bool AllPathsReturn()
        {
            return false;
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            context.EnclosingLoops.Push(this);
            var expressionType = Expression.CheckLocalSemantics(context);
            if (expressionType is not BoolType)
            {
                ErrorHandler.Throw("While loop expression must be of type boolean", this);
            }

            Body.CheckLocalSemantics(context);
            context.EnclosingLoops.Pop();
            return SemanticType.NoType;
        }
    }
}
