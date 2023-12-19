using System.Text.Json.Serialization;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The statement base class.
    /// </summary>
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
        /// <summary>
        /// Initializes a new instance of a <see cref="Statement"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        protected Statement(Span span) : base(span)
        {
        }

        /// <summary>
        /// Checks if all code paths return.
        /// </summary>
        /// <returns>True if all code paths return.</returns>
        public abstract bool AllPathsReturn();
    }
}
