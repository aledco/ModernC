using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Symbols;
using Compiler.Models.Tree;

namespace Compiler.Models.NameResolution
{
    /// <summary>
    /// The scope.
    /// </summary>
    public class Scope
    {
        /// <summary>
        /// The symbol table.
        /// </summary>
        private readonly Dictionary<string, Symbol> _symbolTable = new();

        /// <summary>
        /// The parent scope.
        /// </summary>
        private readonly Scope? _parent;

        /// <summary>
        /// Gets a value indicating whether the scope has a parent.
        /// </summary>
        public bool HasParent { get => _parent != null; }

        /// <summary>
        /// Instantiates a new instance of a <see cref="Scope"/>.
        /// </summary>
        public Scope()
        {
            _parent = null;
        }

        /// <summary>
        /// Instantiates a new instance of a <see cref="Scope"/>.
        /// </summary>
        /// <param name="parent">The parent scope.</param>
        public Scope(Scope? parent)
        {
            _parent = parent;
        }

        /// <summary>
        /// Adds a symbol to the scope.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="type">The type.</param>
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

        /// <summary>
        /// Looks up a symbol in the scope.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The symbol.</returns>
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

        /// <summary>
        /// Looks up a symbol in the scope.
        /// </summary>
        /// <param name="name">The name of the identifier.</param>
        /// <param name="span">The span.</param>
        /// <returns>The symbol.</returns>
        public Symbol LookupSymbol(string name, Span? span = null)
        {
            if (!_symbolTable.ContainsKey(name))
            {
                if (_parent != null)
                {
                    return _parent.LookupSymbol(name);
                }

                ErrorHandler.Throw("Identifier is not defined", span);
            }

            return _symbolTable[name];
        }

        /// <summary>
        /// Checks if a symbol exists in the scope.
        /// </summary>
        /// <param name="name">The name of the identifier.</param>
        /// <returns>True if the symbol exists.</returns>
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
    }
}
