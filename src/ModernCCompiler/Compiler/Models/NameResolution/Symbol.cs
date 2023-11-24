using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Tree;
using System.Text.Json.Serialization;

namespace Compiler.Models.Symbols
{
    public class Symbol
    {
        public string Name { get; }
        public Scope EnclosingScope { get; }
        public SemanticType Type { get; }
        public bool IsGlobal { get => !EnclosingScope.HasParent(); }

        [JsonIgnore]
        public FunctionDefinition? EnclosingFunction { get; set; }

        public int Offset { get; set; }

        public Symbol(string name, Scope enclosingScope, SemanticType type)
        {
            Name = name;
            EnclosingScope = enclosingScope;
            Type = type;
        }
    }
}
