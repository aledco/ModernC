namespace Compiler.Models.NameResolution.Types
{
    public class FloatType : RealType
    {
        public override bool Equals(object? obj)
        {
            return obj is FloatType;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
