using System.Text.Json.Serialization;

namespace Compiler.Models.Tree
{
    [JsonDerivedType(typeof(PrintStatement))]
    [JsonDerivedType(typeof(VariableDefinitionStatement))]
    [JsonDerivedType(typeof(AssignmentStatement))]
    [JsonDerivedType(typeof(VariableDefinitionAndAssignmentStatement))]
    [JsonDerivedType(typeof(ReturnStatement))]
    public abstract class Statement : AbstractSyntaxTree
    {
        protected Statement(Span span) : base(span)
        {
        }
    }
}
