namespace Compiler.VirtualMachine
{
    public class Registry
    {
        public static string ProgramCounter { get; } = "PC";
        public static string FramePointer { get; } = "FP";
        public static string StackPointer { get; } = "SP";
        public static string ReturnAddress { get; } = "RA";

        public Dictionary<string, int> Registers;

        public Registry() 
        {
            Registers = new()
            {
                [ProgramCounter] = 0,
                [FramePointer] = 0,
                [StackPointer] = 0,
                [ReturnAddress] = 0,
            };
        }

    }
}
