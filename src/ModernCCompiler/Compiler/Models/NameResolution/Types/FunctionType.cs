namespace Compiler.Models.NameResolution.Types
{
    /// <summary>
    /// The function type.
    /// </summary>
    public class FunctionType : SemanticType
    {
        /// <summary>
        /// Gets the return type.
        /// </summary>
        public SemanticType ReturnType { get; }

        /// <summary>
        /// Gets the parameter types.
        /// </summary>
        public IList<SemanticType> Parameters { get; }

        /// <summary>
        /// Instantiates a new instance of a <see cref="FunctionType"/>.
        /// </summary>
        /// <param name="returnType">The return type.</param>
        /// <param name="parameters">The parameters.</param>
        public FunctionType(SemanticType returnType, IList<SemanticType> parameters)
        {
            ReturnType = returnType;
            Parameters = parameters;
        }

        public override int GetSizeInBytes()
        {
            return 4;
        }

        public override int GetSizeInWords()
        {
            return 1;
        }

        public override bool TypeEquals(SemanticType other)
        {
            if (other is FunctionType otherType &&
                ReturnType.TypeEquals(otherType.ReturnType) &&
                Parameters.Count == otherType.Parameters.Count)
            {
                return Parameters.Zip(otherType.Parameters).All(t => t.First.TypeEquals(t.Second));
            }

            return false;
        }
    }
}
