using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Symbols;
using Compiler.Models.Tree;

namespace Compiler.Models.NameResolution
{
    public class Scope
    {
        private readonly Dictionary<string, Symbol> _symbolTable = new();
        private readonly Scope? _parent;

        public Scope()
        {
            _parent = null;
        }

        public Scope(Scope? parent)
        {
            _parent = parent;
        }

        public void AddSymbol(IdNode id, SemanticType type)
        {
            if (_symbolTable.ContainsKey(id.Value))
            {
                ErrorHandler.Throw("Identifier is already defined", id);
            }
            else if (SymbolTable.TypeExists(id.Value))
            {
                ErrorHandler.Throw("Type cannot be redefined as identifier", id);
            }

            _symbolTable[id.Value] = new Symbol(id.Value, this, type);
        }

        public Symbol LookupSymbol(IdNode id)
        {
            if (!_symbolTable.ContainsKey(id.Value))
            {
                if (_parent != null)
                {
                    return _parent.LookupSymbol(id);
                }

                ErrorHandler.Throw("Identifier is not defined", id);
            }

            return _symbolTable[id.Value];
        }

        public bool SymbolExists(string name)
        {
            if (!_symbolTable.ContainsKey(name))
            {
                if (_parent == null)
                {
                    return false;
                }

                return _parent.SymbolExists(name);
            }

            return true;
        }

        public bool HasParent()
        {
            return _parent != null;
        }
    }
}
