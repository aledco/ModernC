using System.Text.Json.Serialization;

namespace Compiler.Models.Tree
{
    [JsonDerivedType(typeof(PrintStatement))]
    [JsonDerivedType(typeof(PrintLineStatement))]
    [JsonDerivedType(typeof(VariableDefinitionStatement))]
    [JsonDerivedType(typeof(AssignmentStatement))]
    [JsonDerivedType(typeof(IncrementStatement))]
    [JsonDerivedType(typeof(VariableDefinitionAndAssignmentStatement))]
    [JsonDerivedType(typeof(CallStatement))]
    [JsonDerivedType(typeof(IfStatement))]
    [JsonDerivedType(typeof(WhileStatement))]
    [JsonDerivedType(typeof(DoWhileStatement))]
    [JsonDerivedType(typeof(ForStatement))]
    [JsonDerivedType(typeof(ReturnStatement))]
    [JsonDerivedType(typeof(BreakStatement))]
    [JsonDerivedType(typeof(ContinueStatement))]
    [JsonDerivedType(typeof(ExitStatement))]
    [JsonDerivedType(typeof(CompoundStatement))]
    public abstract class Statement : AbstractSyntaxTree
    {
        protected Statement(Span span) : base(span)
        {
        }
    }
}
