namespace Compiler.Models.Tree
{
    public class IfStatement : Statement
    {
        public Expression IfExpression { get; }
        public CompoundStatement IfBody { get; }
        public IList<Expression> ElifExpressions { get; }
        public IList<CompoundStatement> ElifBodies {get;}
        public CompoundStatement? ElseBody { get; }

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
    }
}
