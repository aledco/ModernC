namespace Compiler.VirtualMachine.Instructions
{
    public class CallIndirect : IInstruction
    {
        private readonly string _dst;

        public CallIndirect(string dst)
        {
            _dst = dst;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextReader inStream, TextWriter outStream)
        {
            registers[Registers.ReturnAddress] = registers[Registers.ProgramCounter];
            registers[Registers.ProgramCounter] = registers[_dst];
        }

        public string ToCode()
        {
            return $"calli {_dst}";
        }
    }
}
