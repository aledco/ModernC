using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Symbols;
using Compiler.Models.Tree;

namespace Compiler.Models.NameResolution
{
    public class Scope
    {
        private readonly Dictionary<string, Symbol> _table = new();
        private readonly Scope? _parent;

        public Scope()
        {
            _parent = null;
        }

        public Scope(Scope? parent)
        {
            _parent = parent;
        }

        public void Add(IdNode id, SemanticType type)
        {
            if (_table.ContainsKey(id.Value))
            {
                ErrorHandler.Throw("Identifier is already defined", id);
            }

            _table[id.Value] = new Symbol(id.Value, this, type);
        }

        public Symbol Lookup(IdNode id)
        {
            if (!_table.ContainsKey(id.Value))
            {
                if (_parent != null)
                {
                    return _parent.Lookup(id);
                }

                ErrorHandler.Throw("Identifier is not defined", id);
            }

            return _table[id.Value];
        }

        public FunctionDefinition LookupFunction(IdNode id)
        {
            if (_parent != null) 
            {
                return _parent.LookupFunction(id);
            }

            var symbol = _table[id.Value];
            if (symbol.EnclosingFunction == null)
            {
                throw new Exception("EnclosingFunction was null");
            }

            return symbol.EnclosingFunction;
        }

        public bool HasParent()
        {
            return _parent != null;
        }
    }
}
