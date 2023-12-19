using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    public class FunctionTypeNode : TypeNode
    {
        /// <summary>
        /// Gets the return type.
        /// </summary>
        public TypeNode ReturnType { get; }

        /// <summary>
        /// Gets the parameter types.
        /// </summary>
        public IList<TypeNode> ParameterTypes { get; }
        
        /// <summary>
        /// Initializes a new instance of a <see cref="FunctionTypeNode"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="types">The types.</param>
        /// <exception cref="Exception"></exception>
        public FunctionTypeNode(Span span, IList<TypeNode> types) : base(span)
        {
            ReturnType = types.Last();
            types.RemoveAt(types.Count - 1);
            ParameterTypes = types;
        }

        public override SemanticType ToSemanticType()
        {
            return new FunctionType(ReturnType.ToSemanticType(),
                                    ParameterTypes.Select(p => p.ToSemanticType()).ToList());
        }

        public override SemanticType ToSemanticTypeSafe()
        {
            return new FunctionType(ReturnType.ToSemanticTypeSafe(),
                                    ParameterTypes.Select(p => p.ToSemanticTypeSafe()).ToList());
        }
    }
}
