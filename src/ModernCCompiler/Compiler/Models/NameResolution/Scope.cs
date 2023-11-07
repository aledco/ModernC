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
                throw new AlreadyDefinedException(id); // TODO need to get the span in here
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

                throw new NotDefinedException(id);
            }

            return _table[id.Value];
        }

        private class AlreadyDefinedException : Exception
        {
            public AlreadyDefinedException(IdNode id) : base($"{id.Value} has already been defined: {id.Span}")
            {
            }
        }

        private class NotDefinedException : Exception
        {
            public NotDefinedException(IdNode id) : base($"{id.Value} has not been defined: {id.Span}")
            {
            }
        }
    }
}
