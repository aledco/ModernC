using Compiler.Models.NameResolution.Types;
using Compiler.Models.Operators;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Compiler.Models.Tree
{
    [JsonDerivedType(typeof(BinaryOperatorExpression))]
    [JsonDerivedType(typeof(UnaryOperatorExpression))]
    [JsonDerivedType(typeof(StructLiteralExpression))]
    [JsonDerivedType(typeof(ArrayLiteralExpression))]
    [JsonDerivedType(typeof(IntLiteralExpression))]
    [JsonDerivedType(typeof(ByteLiteralExpression))]
    [JsonDerivedType(typeof(FloatLiteralExpression))]
    [JsonDerivedType(typeof(BoolLiteralExpression))]
    [JsonDerivedType(typeof(IdExpression))]
    [JsonDerivedType(typeof(CallExpression))]
    [JsonDerivedType(typeof(ArrayIndexExpression))]
    [JsonDerivedType(typeof(FieldAccessExpression))]
    public abstract class Expression : AbstractSyntaxTree
    {
        public SemanticType? Type { get; set; }
        public string Register { get; set; }

        protected Expression(Span span) : base(span)
        {
            Register = string.Empty;
        }

        public abstract Expression Copy(Span span);
    }
}
