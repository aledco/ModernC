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

        public static bool operator ==(FunctionType type, SemanticType otherType)
        {
            if (otherType is FunctionType other && 
                type.ReturnType == other.ReturnType && 
                type.Parameters.Count() == other.Parameters.Count()) 
            {
                return type.Parameters.Zip(other.Parameters).All(t => t.First == t.Second);
            }

            return false;
        }

        public static bool operator !=(FunctionType type, SemanticType other)
        {
            return !(type == other);
        }

        public override bool Equals(object? obj)
        {
            return obj is SemanticType type && this == type;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
