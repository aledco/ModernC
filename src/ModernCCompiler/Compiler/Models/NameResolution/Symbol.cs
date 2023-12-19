using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Tree;
using System.Text.Json.Serialization;

namespace Compiler.Models.Symbols
{
    /// <summary>
    /// The symbol.
    /// </summary>
    public class Symbol
    {
        /// <summary>
        /// Gets the name of the identifier.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the enclosing scope.
        /// </summary>
        public Scope EnclosingScope { get; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        public SemanticType Type { get; }

        /// <summary>
        /// Gets a value indicating whether the symbol is global.
        /// </summary>
        public bool IsGlobal { get => !EnclosingScope.HasParent; }

        /// <summary>
        /// Gets or sets a value indicating whether the sybol is a defined global function.
        /// </summary>
        public bool IsDefinedGlobalFunction { get; set; }

        /// <summary>
        /// Gets or sets the enclosing function.
        /// </summary>
        [JsonIgnore]
        public FunctionDefinition? EnclosingFunction { get; set; }

        /// <summary>
        /// Gets or sets the offset used for code generation.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Instantiates a new instance of a <see cref="Symbol"/>.
        /// </summary>
        /// <param name="name">The name of the identifier.</param>
        /// <param name="enclosingScope">The enclosing scope.</param>
        /// <param name="type">The type.</param>
        public Symbol(string name, Scope enclosingScope, SemanticType type)
        {
            Name = name;
            EnclosingScope = enclosingScope;
            Type = type;
        }
    }
}
