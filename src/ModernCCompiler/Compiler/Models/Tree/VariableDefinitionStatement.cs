using static Antlr4.Runtime.Atn.SemanticContext;

namespace Compiler.Models.Tree
{
    public class VariableDefinitionStatement : Statement
    {
        public TypeNode Type { get; }
        public IdNode Id { get; }

        public VariableDefinitionStatement(Span span, TypeNode type, IdNode id) : base(span)
        {
            Type = type;
            Id = id;
        }
    }
}
