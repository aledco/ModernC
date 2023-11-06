namespace Compiler.Models.NameResolution.Types
{
    internal class BoolType : SemanticType
    {
        public override bool Equals(object? obj)
        {
            return obj is VoidType;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
