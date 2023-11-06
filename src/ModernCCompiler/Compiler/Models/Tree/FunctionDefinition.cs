using Compiler.Models.Symbols;

namespace Compiler.Models.Tree
{
    public class FunctionDefinition : AbstractSyntaxTree
    {
        public TypeNode ReturnType { get; }
        public IdNode Id { get; }
        public ParameterList ParameterList { get; }
        public CompoundStatement Body { get; }

        public Scope? FunctionScope { get; set; }

        public FunctionDefinition(Span span, TypeNode returnType, IdNode id, ParameterList parameterList, CompoundStatement body) : base(span)
        {
            ReturnType = returnType;
            Id = id;
            ParameterList = parameterList;
            Body = body;
        }
    }
}
