using static Compiler.Utils.FloatConvert;

namespace Compiler.VirtualMachine.Instructions
{
    public class LessThanEqualFloat : IInstruction
    {
        private readonly string _dst;
        private readonly string _left;
        private readonly string _right;

        public LessThanEqualFloat(string dst, string left, string right)
        {
            _dst = dst;
            _left = left;
            _right = right;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextReader inStream, TextWriter outStream)
        {
            registers[_dst] = ToFloat(registers[_left]) <= ToFloat(registers[_right]) ? 1 : 0;
        }

        public string ToCode()
        {
            return $"lte {_dst} {_left} {_right}";
        }
    }
}
