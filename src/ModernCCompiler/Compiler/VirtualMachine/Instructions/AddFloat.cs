﻿using static Compiler.Utils.FloatConvert;

namespace Compiler.VirtualMachine.Instructions
{
    public class AddFloat : IInstruction
    {
        private readonly string _dst;
        private readonly string _left;
        private readonly string _right;

        public AddFloat(string dst, string left, string right)
        {
            _dst = dst;
            _left = left;
            _right = right;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextWriter outStream)
        {
            registers[_dst] = ToInt(ToFloat(registers[_left]) + ToFloat(registers[_right]));
        }

        public string ToCode()
        {
            return $"addf {_dst} {_left} {_right}";
        }
    }
}