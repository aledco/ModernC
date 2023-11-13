using System;

namespace Compiler.VirtualMachine
{
    public class Registers
    {
        public static string ProgramCounter { get; } = "PC";
        public static string FramePointer { get; } = "FP";
        public static string StackPointer { get; } = "SP";
        public static string ReturnAddress { get; } = "RA";
        public static string Temporary { get; } = "t1";

        public readonly Dictionary<string, int> _registers;

        public Registers() 
        {
            _registers = new()
            {
                [ProgramCounter] = 0,
                [FramePointer] = 0,
                [StackPointer] = 0,
                [ReturnAddress] = 0,
            };
        }

        public int this[string register]
        {
            get => _registers[register];
            set => _registers[register] = value;
        }

    }
}
