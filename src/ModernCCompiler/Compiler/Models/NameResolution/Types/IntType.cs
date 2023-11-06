namespace Compiler.Models.NameResolution.Types
{
    public class IntType : SemanticType
    {
        public override bool Equals(object? obj)
        {
            return obj is IntType;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
