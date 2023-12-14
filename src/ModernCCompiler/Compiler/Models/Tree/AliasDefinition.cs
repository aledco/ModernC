using Compiler.Models.Context;
using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    public class AliasDefinition : Definition
    {
        /// <summary>
        /// Gets the aliased type.
        /// </summary>
        public TypeNode AliasedType { get; }

        /// <summary>
        /// Initializes a new instance of an <see cref="AliasDefinition"/>
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="type">The new user defined type.</param>
        /// <param name="aliasedType">The type to be aliased.</param>
        public AliasDefinition(Span span, UserDefinedTypeNode type, TypeNode aliasedType) : base(span, type)
        {
            AliasedType = aliasedType;
        }

        public override SemanticType GlobalTypeCheck(GlobalTypeCheckContext context)
        {
            var aliasedType = AliasedType.ToSemanticType();
            SymbolTable.AddType(Type, aliasedType);
            return aliasedType;
        }
    }
}
