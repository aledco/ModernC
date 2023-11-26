namespace Compiler.VirtualMachine.Instructions
{
    public class AddImmediate : IInstruction
    {
        private readonly string _dst;
        private readonly string _src;
        private readonly int _val;

        public AddImmediate(string dst, string src, int val)
        {
            _dst = dst;
            _src = src;
            _val = val;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextReader inStream, TextWriter outStream)
        {
            registers[_dst] = registers[_src] + _val;
        }

        public string ToCode()
        {
            return $"addi {_dst} {_src} {_val}";
        }
    }
}
