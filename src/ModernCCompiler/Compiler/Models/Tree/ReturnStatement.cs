using System.Text.Json.Serialization;

namespace Compiler.Models.Tree
{
    public class ReturnStatement : Statement
    {
        public Expression? Expression { get; }

        [JsonIgnore]
        public FunctionDefinition? EnclosingFunction { get; set; }

        public ReturnStatement(Span span, Expression? expression) : base(span)
        {
            Expression = expression;
        }

        public override bool AllPathsReturn()
        {
            return true;
        }
    }
}
