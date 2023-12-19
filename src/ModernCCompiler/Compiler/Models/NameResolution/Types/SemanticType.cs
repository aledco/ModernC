using System.Text.Json.Serialization;

namespace Compiler.Models.NameResolution.Types
{
    /// <summary>
    /// The semantic type.
    /// </summary>
    public abstract class SemanticType
    {
        /// <summary>
        /// Gets a value indicating whether the type is complex.
        /// </summary>
        public bool IsComplex
        {
            get
            {
                try
                {
                    return this is not VoidType && GetSizeInWords() > 1;
                }
                catch
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Gets the base type.
        /// </summary>
        [JsonIgnore]
        public virtual SemanticType BaseType { get => this; }

        /// <summary>
        /// Gets a value indicating whether the type is parameterized.
        /// </summary>
        public virtual bool IsParameterized { get => false; }

        /// <summary>
        /// Gets the semantic type representing no type.
        /// </summary>
        public static SemanticType NoType { get; } = new NoType();

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
    }
}
