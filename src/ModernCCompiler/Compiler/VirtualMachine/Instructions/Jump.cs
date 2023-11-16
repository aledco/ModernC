namespace Compiler.VirtualMachine.Instructions
{
    public class Jump : IInstruction
    {
        private readonly string _label;

        public Jump(string label)
        {
            _label = label;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextWriter outStream)
        {
            registers[Registers.ProgramCounter] = labels[_label];
        }

        public string ToCode()
        {
            return $"j {_label}";
        }
    }
}
