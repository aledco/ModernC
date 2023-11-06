namespace Compiler.Models.NameResolution.Types
{
    internal class IntType : SemanticType
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
