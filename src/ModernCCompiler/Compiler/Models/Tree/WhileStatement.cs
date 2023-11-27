namespace Compiler.Models.Tree
{
    public class WhileStatement : LoopStatement
    {
        public Expression Expression { get; }
        public CompoundStatement Body { get; }

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
    }
}
