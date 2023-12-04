namespace Compiler.Models.NameResolution.Types
{
    public abstract class SemanticType
    {
        /// <summary>
        /// Gets the size of the type in bytes.
        /// </summary>
        /// <returns>The size.</returns>
        public abstract int GetSizeInBytes();

        /// <summary>
        /// Gets the size of the type in words.
        /// </summary>
        /// <returns>The size.</returns>
        public abstract int GetSizeInWords();

        /// <summary>
        /// Checks if a type is equal to this one.
        /// </summary>
        /// <param name="other">The other type</param>
        /// <returns>True if equal.</returns>
        public abstract bool TypeEquals(SemanticType other);

        public bool IsComplex
        {
            get
            {
                return this is not VoidType && GetSizeInWords() > 1;
            }
        }
    }
}
