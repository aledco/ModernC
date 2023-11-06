namespace Compiler.Models.Tree
{
    internal class VariableDefinitionAndAssignmentStatement : Statement
    {
        public TypeNode Type { get; }
        public IdNode Id { get; }
        public Expression Expression { get; }

        public VariableDefinitionAndAssignmentStatement(Span span, TypeNode type, IdNode id, Expression expression) : base(span)
        {
            Type = type;
            Id = id;
            Expression = expression;
        }

        public override string ToString()
        {
            return $"VariableDefinitionAndAssignmentStatement(Span={Span}, Type={Type}, Id={Id}, Expression={Expression})";
        }
    }
}
