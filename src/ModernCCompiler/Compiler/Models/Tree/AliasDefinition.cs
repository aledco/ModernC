namespace Compiler.Models.Tree
{
    public class AliasDefinition : Definition
    {
        public TypeNode AliasedType { get; }
        public AliasDefinition(Span span, UserDefinedTypeNode type, TypeNode aliasedType) : base(span, type)
        {
            AliasedType = aliasedType;
        }
    }
}
