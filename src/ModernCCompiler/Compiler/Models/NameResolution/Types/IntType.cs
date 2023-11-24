namespace Compiler.Models.NameResolution.Types
{
    public class IntType : NumberType
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
