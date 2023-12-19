using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Tree;
using System.Linq.Expressions;
using System.Reflection;

namespace Compiler.Models.NameResolution
{
    /// <summary>
    /// The symbol table.
    /// </summary>
    public static class SymbolTable
    {
        /// <summary>
        /// The type table.
        /// </summary>
        private static readonly Dictionary<string, (SemanticType Type, Definition? Definition)> _typeTable = new();
        
        /// <summary>
        /// Gets or sets the global scope.
        /// </summary>
        public static Scope GlobalScope { get; private set; } = new Scope();

        /// <summary>
        /// Adds a type to the type table.
        /// </summary>
        /// <param name="typeNode">The type node.</param>
        /// <param name="definition">The definition.</param>
        public static void AddType(UserDefinedTypeNode typeNode, Definition definition)
        {
            if (TypeExists(typeNode.Id.Value))
            {
                ErrorHandler.Throw("Type is already defined", typeNode);
            }
            else if (GlobalScope.SymbolExists(typeNode.Id.Value))
            {
                ErrorHandler.Throw("Identifier cannot be redefined as type", typeNode);
            }

            _typeTable[typeNode.Id.Value] = (typeNode.ToSemanticTypeSafe(), definition);
        }

        /// <summary>
        /// Adds a type to the type table.
        /// </summary>
        /// <param name="typeNode">The type node.</param>
        /// <param name="aliasedType">The aliased type.</param>
        public static void AddType(UserDefinedTypeNode typeNode, SemanticType aliasedType)
        {
            if (TypeExists(typeNode.Id.Value))
            {
                ErrorHandler.Throw("Type is already defined", typeNode);
            }
            else if (GlobalScope.SymbolExists(typeNode.Id.Value))
            {
                ErrorHandler.Throw("Identifier cannot be redefined as type", typeNode);
            }
            else if (aliasedType is UserDefinedType userDefinedType && !TypeExists(userDefinedType.Value))
            {
                ErrorHandler.Throw("Type is not defined", typeNode);
            }

            _typeTable[typeNode.Id.Value] = (aliasedType, null);
        }

        /// <summary>
        /// Looks up a type.
        /// </summary>
        /// <param name="typeNode">The type node.</param>
        /// <returns>The type.</returns>
        public static SemanticType LookupType(UserDefinedTypeNode typeNode)
        {
            if (!_typeTable.ContainsKey(typeNode.Id.Value))
            {
                ErrorHandler.Throw("Type is not defined", typeNode);
            }

            return _typeTable[typeNode.Id.Value].Type;
        }

        /// <summary>
        /// Trys to lookup a type.
        /// </summary>
        /// <param name="typeNode">The type node.</param>
        /// <param name="type">The type out parameter.</param>
        /// <returns>True if the type exists.</returns>
        public static bool TryLookupType(UserDefinedTypeNode typeNode, out SemanticType type)
        {
            if (_typeTable.TryGetValue(typeNode.Id.Value, out (SemanticType Type, Definition? Definition) value))
            {
                type = value.Type;
                return true;
            }

            type = default!;
            return false;
        }

        /// <summary>
        /// Looks up a definition.
        /// </summary>
        /// <param name="typeNode">The type node.</param>
        /// <returns>The definition.</returns>
        /// <exception cref="Exception"></exception>
        public static Definition LookupDefinition(UserDefinedTypeNode typeNode)
        {
            if (!_typeTable.ContainsKey(typeNode.Id.Value))
            {
                ErrorHandler.Throw("Type is not defined", typeNode);
            }

            var definition = _typeTable[typeNode.Id.Value].Definition;
            return definition ?? throw new Exception("Type does not have a definition");
        }

        /// <summary>
        /// Looks up a type.
        /// </summary>
        /// <param name="type">The user defined type.</param>
        /// <param name="span">The span.</param>
        /// <returns>The type.</returns>
        public static SemanticType LookupType(UserDefinedType type, Span? span = null)
        {
            if (_typeTable.TryGetValue(type.Value, out (SemanticType Type, Definition? Definition) value))
            {

                return value.Type;
            }

            ErrorHandler.Throw($"Type {type.Value} is not defined", span);
            throw ErrorHandler.FailedToExit;
        }

        /// <summary>
        /// Looks up a definition.
        /// </summary>
        /// <param name="type">The user defined type.</param>
        /// <param name="span">The span.</param>
        /// <returns>The definition.</returns>
        /// <exception cref="Exception"></exception>
        public static Definition LookupDefinition(UserDefinedType type, Span? span = null)
        {
            if (_typeTable.TryGetValue(type.Value, out (SemanticType Type, Definition? Definition) value))
            {
                var definition = value.Definition;
                return definition ?? throw new Exception("Type does not have a definition");
            }

            ErrorHandler.Throw($"Type {type.Value} is not defined", span);
            throw ErrorHandler.FailedToExit;
        }

        /// <summary>
        /// Looks up a type and definition.
        /// </summary>
        /// <typeparam name="T">The type of the type.</typeparam>
        /// <typeparam name="D">The type of the definition.</typeparam>
        /// <param name="type">The user defined type.</param>
        /// <param name="span">The span.</param>
        /// <returns>The type.</returns>
        public static (T Type, D Definition) LookupTypeAndDefinition<T, D>(UserDefinedType type, Span? span = null) 
            where T : UserDefinedType 
            where D : Definition
        {
            if (!_typeTable.ContainsKey(type.Value))
            {
                ErrorHandler.Throw($"Type {type.Value} is not defined", span);
            }

            var value = _typeTable[type.Value];

            T typeInstance;
            if (value.Type is T t)
            {
                typeInstance = t;
            }
            else
            {
                ErrorHandler.Throw("Types are not compatable", span);
                throw ErrorHandler.FailedToExit;
            }

            D definition;
            if (value.Definition is D d)
            {
                definition = d;
            }
            else
            {
                ErrorHandler.Throw("Types are not compatable", span);
                throw ErrorHandler.FailedToExit;
            }

            return (typeInstance, definition);
        }

        /// <summary>
        /// Checks if a type exists.
        /// </summary>
        /// <param name="name">The name of the type.</param>
        /// <returns>True if the type exists.</returns>
        public static bool TypeExists(string name)
        {
            return _typeTable.ContainsKey(name);
        }

        /// <summary>
        /// Clears the type table.
        /// </summary>
        public static void Clear()
        {
            _typeTable.Clear();
            GlobalScope = new Scope();
        }
    }
}
