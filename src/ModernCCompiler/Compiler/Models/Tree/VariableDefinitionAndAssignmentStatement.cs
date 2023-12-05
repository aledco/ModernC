using Compiler.Models.Operators;

namespace Compiler.Models.Tree
{
    public class VariableDefinitionAndAssignmentStatement : Statement
    {
        public TypeNode Type { get; }
        public IdNode Id { get; }
        public AssignmentOperator Operator { get; }
        public Expression Expression { get; }

        public VariableDefinitionAndAssignmentStatement(Span span, TypeNode type, IdNode id, Expression expression) : base(span)
        {
            Type = type;
            Id = id;
            Expression = expression;
        }

        public override bool AllPathsReturn()
        {
            return false;
        }
    }
}
