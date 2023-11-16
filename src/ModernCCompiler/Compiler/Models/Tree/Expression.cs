using Compiler.Models.NameResolution.Types;
using System.Text.Json.Serialization;

namespace Compiler.Models.Tree
{
    [JsonDerivedType(typeof(BinaryOperatorExpression))]
    [JsonDerivedType(typeof(UnaryOperatorExpression))]
    [JsonDerivedType(typeof(IntLiteralExpression))]
    [JsonDerivedType(typeof(BoolLiteralExpression))]
    [JsonDerivedType(typeof(IdExpression))]
    public abstract class Expression : AbstractSyntaxTree
    {
        public SemanticType? Type { get; set; }

        public string Register { get; set; }

        protected Expression(Span span) : base(span)
        {
            Register = string.Empty;
        }
    }
}
