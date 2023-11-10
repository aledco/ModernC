namespace Compiler.VirtualMachine.Instructions
{
    public class Jump : IInstruction
    {
        private readonly string _label;

        public Jump(string label)
        {
            _label = label;
        }

        public void Execute(Memory memory, Registry registry, Dictionary<string, int> labels)
        {
            registry.Registers[Registry.ProgramCounter] = labels[_label];
        }

        public string ToCode()
        {
            return $"j {_label}";
        }
    }
}
