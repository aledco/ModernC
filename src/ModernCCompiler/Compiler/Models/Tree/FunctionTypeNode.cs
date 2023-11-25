﻿using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    public class FunctionTypeNode : TypeNode
    {
        public TypeNode ReturnType { get; }
        public IList<TypeNode> ParameterTypes { get; }
        
        public FunctionTypeNode(Span span, IList<TypeNode> types) : base(span)
        {
            if (!types.Any())
            {
                throw new Exception("Type list was empty");
            }

            ReturnType = types.First();
            types.RemoveAt(0);
            ParameterTypes = types;
        }

        public override SemanticType ToSemanticType()
        {
            return new FunctionType(ReturnType.ToSemanticType(),
                                    ParameterTypes.Select(p => p.ToSemanticType()).ToList());
        }
    }
}
