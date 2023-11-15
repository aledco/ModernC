namespace Compiler.VirtualMachine.Instructions
{
    public class JumpIndirect : IInstruction
    {
        private readonly string _src;

        public JumpIndirect(string src)
        {
            _src = src;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextWriter outStream)
        {
            registers[Registers.ProgramCounter] = registers[_src];
        }

        public string ToCode()
        {
            return $"ji {_src}";
        }
    }
}
