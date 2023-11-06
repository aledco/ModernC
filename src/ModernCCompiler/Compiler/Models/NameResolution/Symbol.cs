using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Symbols
{
    public class Symbol
    {
        public string Name { get; }
        public Scope EnclosingScope { get; }
        public SemanticType Type { get; }

        public Symbol(string name, Scope enclosingScope, SemanticType type)
        {
            Name = name;
            EnclosingScope = enclosingScope;
            Type = type;
        }
    }
}
