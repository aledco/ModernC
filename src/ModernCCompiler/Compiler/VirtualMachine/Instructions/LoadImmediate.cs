namespace Compiler.VirtualMachine.Instructions
{
    public class LoadImmediate : IInstruction
    {
        private readonly string _dst;
        private readonly int _val;

        public LoadImmediate(string dst, int val)
        {
            _dst = dst;
            _val = val;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextWriter outStream)
        {
            registers[_dst] = _val;
        }

        public string ToCode()
        {
            return $"li {_dst} {_val}";
        }
    }
}
