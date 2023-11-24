using System.Text.Json.Serialization;

namespace Compiler.Models.Tree
{
    [JsonDerivedType(typeof(PrintStatement))]
    [JsonDerivedType(typeof(VariableDefinitionStatement))]
    [JsonDerivedType(typeof(AssignmentStatement))]
    [JsonDerivedType(typeof(VariableDefinitionAndAssignmentStatement))]
    [JsonDerivedType(typeof(CallStatement))]
    [JsonDerivedType(typeof(IfStatement))]
    [JsonDerivedType(typeof(WhileStatement))]
    [JsonDerivedType(typeof(ForStatement))]
    [JsonDerivedType(typeof(ReturnStatement))]
    [JsonDerivedType(typeof(CompoundStatement))]
    public abstract class Statement : AbstractSyntaxTree
    {
        protected Statement(Span span) : base(span)
        {
        }
    }
}
