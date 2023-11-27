using static Compiler.Utils.FloatConvert;

namespace Compiler.VirtualMachine.Instructions
{
    public class NegateFloat : IInstruction
    {
        private readonly string _dst;
        private readonly string _src;

        public NegateFloat(string dst, string src)
        {
            _dst = dst;
            _src = src;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextReader inStream, TextWriter outStream)
        {
            registers[_dst] = ToInt(-ToFloat(registers[_src]));
        }

        public string ToCode()
        {
            return $"negf {_dst} {_src}";
        }
    }
}
