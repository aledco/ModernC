namespace VirtualMachine
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
                [FramePointer] = Memory.GetProgramStackPointer(),
                [StackPointer] = Memory.GetProgramStackPointer(),
                [ReturnAddress] = 0,
                [Temporary] = 0
            };
        }

        public int this[string register]
        {
            get 
            {
                if (!_registers.TryGetValue(register, out int value))
                {
                    value = 0;
                    _registers[register] = value;
                }

                return value;
            }
            set => _registers[register] = value;
        }

    }
}
