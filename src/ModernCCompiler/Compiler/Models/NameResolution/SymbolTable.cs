using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Tree;
using System;

namespace Compiler.Models.NameResolution
{
    public static class SymbolTable
    {
        private static readonly Dictionary<string, (SemanticType Type, Definition? Definition)> _typeTable = new();
        public static Scope GlobalScope { get; set; } = new Scope();

        public static void AddType(UserDefinedTypeNode typeNode, Definition definition)
        {
            if (GlobalScope == null)
            {
                throw new Exception("GlobalScope was null");
            }

            if (TypeExists(typeNode.Id.Value))
            {
                ErrorHandler.Throw("Type is already defined", typeNode);
            }
            else if (GlobalScope.SymbolExists(typeNode.Id.Value))
            {
                ErrorHandler.Throw("Identifier cannot be redefined as type", typeNode);
            }

            _typeTable[typeNode.Id.Value] = (typeNode.ToSemanticType(), definition);
        }

        public static void AddType(UserDefinedTypeNode typeNode, SemanticType aliasedType)
        {
            if (GlobalScope == null)
            {
                throw new Exception("GlobalScope was null");
            }

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

        public static SemanticType LookupType(UserDefinedTypeNode typeNode)
        {
            if (!_typeTable.ContainsKey(typeNode.Id.Value))
            {
                ErrorHandler.Throw("Type is not defined", typeNode);
            }

            return _typeTable[typeNode.Id.Value].Type;
        }

        public static bool TryLookupType(UserDefinedTypeNode typeNode, out SemanticType type)
        {
            if (!_typeTable.ContainsKey(typeNode.Id.Value))
            {
                type = default!;
                return false;
            }

            type = _typeTable[typeNode.Id.Value].Type;
            return true;
        }

        public static Definition LookupDefinition(UserDefinedTypeNode typeNode)
        {
            if (!_typeTable.ContainsKey(typeNode.Id.Value))
            {
                ErrorHandler.Throw("Type is not defined", typeNode);
            }

            var definition = _typeTable[typeNode.Id.Value].Definition;
            if (definition == null)
            {
                throw new Exception("Type does not have a definition");
            }

            return definition;
        }

        public static bool TryLookupTypeAndDefinition<T, D>(UserDefinedTypeNode typeNode, out T type, out D definition)
        {
            if (!_typeTable.ContainsKey(typeNode.Id.Value))
            {
                ErrorHandler.Throw("Type is not defined", typeNode);
            }

            var value = _typeTable[typeNode.Id.Value];
            if (value.Type is T t && value.Definition is D d)
            {
                type = t;
                definition = d;
                return true;
            }

            type = default!;
            definition = default!;
            return false;
        }

        public static SemanticType LookupType(UserDefinedType type, Span? span = null)
        {
            if (!_typeTable.ContainsKey(type.Value))
            {
                ErrorHandler.Throw($"Type {type.Value} is not defined", span);
                throw ErrorHandler.FailedToExit;
            }

            return _typeTable[type.Value].Type;
        }

        public static Definition LookupDefinition(UserDefinedType type, Span? span = null)
        {
            if (!_typeTable.ContainsKey(type.Value))
            {
                ErrorHandler.Throw($"Type {type.Value} is not defined", span);
                throw ErrorHandler.FailedToExit;
            }
            var definition = _typeTable[type.Value].Definition;
            if (definition == null)
            {
                throw new Exception("Type does not have a definition");
            }

            return definition;
        }

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

        public static bool TypeExists(string name)
        {
            return _typeTable.ContainsKey(name);
        }

        public static void Clear()
        {
            _typeTable.Clear();
            GlobalScope = new Scope();
        }
    }
}
