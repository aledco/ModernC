namespace Compiler.Models.NameResolution.Types
{
    public class ByteType : IntegralType
    {
        public override bool Equals(object? obj)
        {
            return obj is BoolType;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
