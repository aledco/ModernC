namespace Compiler.VirtualMachine.Instructions
{
    public class Call : IInstruction
    {
        private readonly string _label;

        public Call(string label) 
        { 
            _label = label;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels)
        {
            registers[Registers.ReturnAddress] = registers[Registers.ProgramCounter];
            registers[Registers.ProgramCounter] = labels[_label];
        }

        public string ToCode()
        {
            return $"call {_label}";
        }
    }
}
