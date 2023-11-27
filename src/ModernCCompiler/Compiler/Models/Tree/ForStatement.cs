namespace Compiler.Models.Tree
{
    public class ForStatement : LoopStatement
    {
        public Statement InitialStatement { get; }
        public Expression Expression { get; }
        public Statement UpdateStatement { get; }
        public CompoundStatement Body { get; }

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
    }
}
