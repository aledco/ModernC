namespace Compiler.Models.Tree
{
    public class DoWhileStatement : LoopingStatement
    {
        public CompoundStatement Body { get; }

        public Expression Expression { get; }
        
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
    }
}
