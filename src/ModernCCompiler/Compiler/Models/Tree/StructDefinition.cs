using Compiler.Context;
using Compiler.ErrorHandling;
using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The struct definition.
    /// </summary>
    public class StructDefinition : Definition
    {
        /// <summary>
        /// Gets the struct definitions fields.
        /// </summary>
        public IList<StructFieldDefinition> Fields { get; }

        /// <summary>
        /// Instantiates a new instance of a <see cref="StructDefinition"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="type">The type.</param>
        /// <param name="fields">The fields.</param>
        public StructDefinition(Span span, StructTypeNode type, IList<StructFieldDefinition> fields) : base(span, type)
        {
            Type = type;
            Fields = fields;
        }

        public override SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context)
        {
            SymbolTable.AddType(Type, this);
            return Type.ToSemanticTypeSafe();
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            var type = Type.ToSemanticType();
            if (IsCircular(type))
            {
                ErrorHandler.Throw("Structs cannot be circular, consider using a pointer instead", this);
            }

            foreach (var field in Fields)
            {
                field.CheckLocalSemantics(context);
            }

            return type;
        }

        /// <summary>
        /// Determines if a struct definition is circular.
        /// </summary>
        /// <param name="typeToCheck">The type to check.</param>
        /// <returns>True if circular.</returns>
        private bool IsCircular(SemanticType typeToCheck)
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
    }
}
