namespace VirtualMachine.Instructions
{
    public class LoadLabel : IInstruction
    {
        private readonly string _dst;
        private readonly string _label;

        public LoadLabel(string dst, string label) 
        {
            _dst = dst;
            _label = label;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextReader inStream, TextWriter outStream)
        {
            registers[_dst] = labels[_label];
        }

        public string ToCode()
        {
            return $"ll {_dst} {_label}";
        }
    }
}
