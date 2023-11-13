﻿using Compiler.Models.NameResolution;

namespace Compiler.Models.Tree
{
    public class FunctionDefinition : AbstractSyntaxTree
    {
        public TypeNode ReturnType { get; }
        public IdNode Id { get; }
        public ParameterList ParameterList { get; }
        public CompoundStatement Body { get; }

        public Scope? FunctionScope { get; set; }

        public int Size { get; set; }
        public List<string> RegisterPool { get; set; }

        public FunctionDefinition(Span span, TypeNode returnType, IdNode id, ParameterList parameterList, CompoundStatement body) : base(span)
        {
            ReturnType = returnType;
            Id = id;
            ParameterList = parameterList;
            Body = body;
            RegisterPool = new List<string>();
        }
    }
}
