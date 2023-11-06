namespace Compiler.Models.NameResolution.Types
{
    public abstract class SemanticType
    {
        /// <summary>
        /// Two semantic types are equal if their types are equal. This needs to be overridden in complex types
        /// to recursivly test for equality.
        /// </summary>
        /// <param name="type">The first type to compare.</param>
        /// <param name="other">The other type to compare.</param>
        /// <returns>True if they are the same type.</returns>
        public static bool operator ==(SemanticType type, SemanticType other)
        {
            return type.GetType() == other.GetType();
        }

        public static bool operator !=(SemanticType type, SemanticType other)
        {
            return type.GetType() != other.GetType();
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
