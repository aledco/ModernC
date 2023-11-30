using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Tree;

namespace Compiler.Models.NameResolution
{
    public static class SymbolTable
    {
        private static readonly Dictionary<string, (UserDefinedType Type, Definition Definition)> _typeTable = new();
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

        public static UserDefinedType LookupType(UserDefinedTypeNode typeNode)
        {
            if (!_typeTable.ContainsKey(typeNode.Id.Value))
            {
                ErrorHandler.Throw("Type is not defined", typeNode);
            }

            return _typeTable[typeNode.Id.Value].Type;
        }

        public static Definition LookupDefinition(UserDefinedTypeNode typeNode)
        {
            if (!_typeTable.ContainsKey(typeNode.Id.Value))
            {
                ErrorHandler.Throw("Type is not defined", typeNode);
            }

            return _typeTable[typeNode.Id.Value].Definition;
        }

        public static Definition LookupDefinition(UserDefinedType type)
        {
            if (!_typeTable.ContainsKey(type.Value))
            {
                throw new Exception($"Symbol table did not have type {type.Value}");
            }

            return _typeTable[type.Value].Definition;
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
