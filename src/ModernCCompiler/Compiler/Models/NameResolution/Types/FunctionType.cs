namespace Compiler.Models.NameResolution.Types
{
    public class FunctionType : SemanticType
    {
        public SemanticType ReturnType { get; }
        public IList<SemanticType> Parameters { get; }

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
