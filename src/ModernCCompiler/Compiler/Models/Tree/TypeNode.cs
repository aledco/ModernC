using Compiler.Context;
using Compiler.Models.NameResolution.Types;
using System.Text.Json.Serialization;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The type node base class.
    /// </summary>
    [JsonDerivedType(typeof(VoidTypeNode))]
    [JsonDerivedType(typeof(IntTypeNode))]
    [JsonDerivedType(typeof(ByteTypeNode))]
    [JsonDerivedType(typeof(FloatTypeNode))]
    [JsonDerivedType(typeof(BoolTypeNode))]
    [JsonDerivedType(typeof(FunctionTypeNode))]
    [JsonDerivedType(typeof(ArrayTypeNode))]
    [JsonDerivedType(typeof(UserDefinedTypeNode))]
    [JsonDerivedType(typeof(StructTypeNode))]
    [JsonDerivedType(typeof(PointerTypeNode))]
    [JsonDerivedType(typeof(ParameterizedArrayTypeNode))]
    public abstract class TypeNode : AbstractSyntaxTree
    {
        /// <summary>
        /// Instantiates a new instance of a <see cref="TypeNode"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        protected TypeNode(Span span) : base(span)
        {
        }

        public override SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context)
        {
            throw new NotImplementedException();
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts the type node to a semantic type.
        /// </summary>
        /// <returns>The semantic type.</returns>
        public abstract SemanticType ToSemanticType();

        /// <summary>
        /// Converts the type node to a semantic type safely (without throwing type not defined errors).
        /// </summary>
        /// <returns>The semantic type.</returns>
        public abstract SemanticType ToSemanticTypeSafe();
    }
}