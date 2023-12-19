using Compiler.Context;
using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The do while statement.
    /// </summary>
    public class DoWhileStatement : LoopingStatement
    {
        /// <summary>
        /// Gets the body of the loop.
        /// </summary>
        public CompoundStatement Body { get; }

        /// <summary>
        /// Gets the test expression.
        /// </summary>
        public Expression Expression { get; }
        
        /// <summary>
        /// Initializes a new instance of a <see cref="DoWhileStatement"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="body">The body of the loop.</param>
        /// <param name="expression">The test expression.</param>
        public DoWhileStatement(Span span, CompoundStatement body, Expression expression) : base(span)
        {
            Body = body;
            Expression = expression;     
        }

        public override string GetLoopLabel()
        {
            return $"do_while_loop_{LabelId}";
        }

        public override string GetExitLabel()
        {
            return $"do_while_exit_{LabelId}";
        }

        public override bool AllPathsReturn()
        {
            return Body.AllPathsReturn();
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            context.EnclosingLoops.Push(this);
            Body.CheckLocalSemantics(context);
            var expressionType = Expression.CheckLocalSemantics(context);
            if (expressionType is not BoolType)
            {
                ErrorHandler.Throw("Do while loop expression must be of type boolean", this);
            }

            context.EnclosingLoops.Pop();
            return SemanticType.NoType;
        }
    }
}
