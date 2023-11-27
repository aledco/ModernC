namespace Compiler.VirtualMachine.Instructions
{
    public class JumpIfZero : IInstruction
    {
        private readonly string _src;
        private readonly string _label;

        public JumpIfZero(string src, string label) 
        {
            _src = src;
            _label = label;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextReader inStream, TextWriter outStream)
        {
            if (registers[_src] == 0)
            {
                registers[Registers.ProgramCounter] = labels[_label];
            }
        }

        public string ToCode()
        {
            return $"jiz {_src} {_label}";
        }
    }
}
