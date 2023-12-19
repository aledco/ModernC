using Compiler.Context;
using Compiler.ErrorHandling;
using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The for statement.
    /// </summary>
    public class ForStatement : LoopingStatement
    {
        /// <summary>
        /// Gets the initial statement.
        /// </summary>
        public Statement InitialStatement { get; }

        /// <summary>
        /// Gets the test expression.
        /// </summary>
        public Expression Expression { get; }

        /// <summary>
        /// Gets the update expression.
        /// </summary>
        public Statement UpdateStatement { get; }

        /// <summary>
        /// Gets the body of the loop.
        /// </summary>
        public CompoundStatement Body { get; }

        /// <summary>
        /// Gets or sets the scope of the loop.
        /// </summary>
        public Scope? Scope { get; set; }

        /// <summary>
        /// Initializes a new instance of a <see cref="ForStatement"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="initialStatement">The initial statement.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="updateStatement">The update statement.</param>
        /// <param name="body">The body of the loop.</param>
        public ForStatement(
            Span span, 
            Statement initialStatement, 
            Expression expression, 
            Statement updateStatement, 
            CompoundStatement body) : base(span)
        {
            InitialStatement = initialStatement;
            Expression = expression;
            UpdateStatement = updateStatement;
            Body = body;
        }

        public override string GetLoopLabel()
        {
            return $"for_loop_{LabelId}";
        }

        public override string GetExitLabel()
        {
            return $"for_exit_{LabelId}";
        }

        public override bool AllPathsReturn()
        {
            return false;
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            context.EnclosingLoops.Push(this);
            context.Scope = Scope = new Scope(context.Scope);
            InitialStatement.CheckLocalSemantics(context);
            var expressionType = Expression.CheckLocalSemantics(context);
            if (expressionType is not BoolType)
            {
                ErrorHandler.Throw("For loop expression must be of type boolean", this);
            }

            UpdateStatement.CheckLocalSemantics(context);
            Body.CheckLocalSemantics(context);
            context.EnclosingLoops.Pop();
            return SemanticType.NoType;
        }
    }
}
