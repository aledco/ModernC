using Compiler.Models.Context;
using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    public class StructDefinition : Definition
    {
        public IList<StructFieldDefinition> Fields { get; }

        public StructDefinition(Span span, StructTypeNode type, IList<StructFieldDefinition> fields) : base(span, type)
        {
            Type = type;
            Fields = fields;
        }

        public bool IsCircular()
        {
            return IsCircular(Type.ToSemanticType());
        }

        public bool IsCircular(SemanticType typeToCheck)
        {
            foreach (var field in Fields)
            {
                if (field.Type is UserDefinedTypeNode userDefinedTypeNode)
                {
                    var type = SymbolTable.LookupType(userDefinedTypeNode);
                    if (type.TypeEquals(typeToCheck))
                    {
                        return true;
                    }
                    
                    if (type is StructType)
                    {
                        var definition = SymbolTable.LookupDefinition(userDefinedTypeNode) as StructDefinition;
                        if (definition!.IsCircular(typeToCheck))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public override SemanticType GlobalTypeCheck(GlobalTypeCheckContext context)
        {
            SymbolTable.AddType(Type, this);
            return Type.ToSemanticType();
        }
    }
}
