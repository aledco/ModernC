namespace VirtualMachine.Instructions
{
    public class Negate : IInstruction
    {
        private readonly string _dst;
        private readonly string _src;

        public Negate(string dst, string src)
        {
            _dst = dst;
            _src = src;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextReader inStream, TextWriter outStream)
        {
            registers[_dst] = -registers[_src];
        }

        public string ToCode()
        {
            return $"neg {_dst} {_src}";
        }
    }
}
