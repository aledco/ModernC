namespace Compiler.VirtualMachine.Instructions
{
    public class Move : IInstruction
    {
        private readonly string _dst;
        private readonly string _src;

        public Move(string dst, string src)
        {
            _dst = dst;
            _src = src;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextReader inStream, TextWriter outStream)
        {
            registers[_dst] = registers[_src];
        }

        public string ToCode()
        {
            return $"mov {_dst} {_src}";
        }
    }
}
