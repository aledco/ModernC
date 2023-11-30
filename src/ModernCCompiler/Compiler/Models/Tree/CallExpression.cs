using System.Text.Json.Serialization;

namespace Compiler.Models.Tree
{
    public class CallExpression : TailedExpression
    {
        public Expression Function { get; }
        public ArgumentList ArgumentList { get; }

        [JsonIgnore]
        public FunctionDefinition? TargetFunction { get; set; }

        public CallExpression(Span span, Expression function, ArgumentList? args) : base(span, function)
        {
            Function = function;
            ArgumentList = args ?? new ArgumentList();
        }
    }
}
