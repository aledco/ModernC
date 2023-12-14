using Compiler.Models.NameResolution.Types;
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
    [JsonDerivedType(typeof(FieldCallExpression))]
    public abstract class Expression : AbstractSyntaxTree
    {
        /// <summary>
        /// Gets or sets the type of the expression.
        /// </summary>
        public SemanticType? Type { get; set; } // TODO make protexted set

        /// <summary>
        /// Gets or sets the register used for code generation.
        /// </summary>
        public string Register { get; set; }

        /// <summary>
        /// Initializes a new instance of an <see cref="Expression"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        protected Expression(Span span) : base(span)
        {
            Register = string.Empty;
        }

        /// <summary>
        /// Copies the expression.
        /// </summary>
        /// <param name="span">The span of the new expression.</param>
        /// <returns>The copied expression.</returns>
        public abstract Expression Copy(Span span);
    }
}
