using static Antlr4.Runtime.Atn.SemanticContext;

namespace Compiler.Models.Tree
{
    internal class VariableDefinitionStatement : Statement
    {
        public TypeNode Type { get; }
        public IdNode Id { get; }

        public VariableDefinitionStatement(Span span, TypeNode type, IdNode id) : base(span)
        {
            Type = type;
            Id = id;
        }

        public override string ToString()
        {
            return $"VariableDefinition(Span={Span}, Type={Type}, Id={Id})";
        }
    }
}
