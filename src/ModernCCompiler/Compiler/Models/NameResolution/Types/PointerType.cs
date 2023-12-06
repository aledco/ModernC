﻿namespace Compiler.Models.NameResolution.Types
{
    public class PointerType : SemanticType
    {
        public SemanticType UnderlyingType { get; }
        public PointerType(SemanticType underlyingType)
        {
            UnderlyingType = underlyingType;
        }

        public override int GetSizeInBytes()
        {
            return 4;
        }

        public override int GetSizeInWords()
        {
            return 1;
        }

        public override bool TypeEquals(SemanticType other)
        {
            return other is PointerType otherType && otherType.UnderlyingType.TypeEquals(UnderlyingType);
        }
    }
}