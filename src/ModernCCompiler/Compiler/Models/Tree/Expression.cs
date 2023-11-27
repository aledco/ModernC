﻿using Compiler.Models.NameResolution.Types;
using System.Text.Json.Serialization;

namespace Compiler.Models.Tree
{
    [JsonDerivedType(typeof(BinaryOperatorExpression))]
    [JsonDerivedType(typeof(UnaryOperatorExpression))]
    [JsonDerivedType(typeof(IntLiteralExpression))]
    [JsonDerivedType(typeof(ByteLiteralExpression))]
    [JsonDerivedType(typeof(FloatLiteralExpression))]
    [JsonDerivedType(typeof(BoolLiteralExpression))]
    [JsonDerivedType(typeof(IdExpression))]
    [JsonDerivedType(typeof(CallExpression))]
    public abstract class Expression : AbstractSyntaxTree
    {
        public SemanticType? Type { get; set; }

        public string Register { get; set; }
        public string? AssignmentRegister { get; set; }

        protected Expression(Span span) : base(span)
        {
            Register = string.Empty;
        }
    }
}
