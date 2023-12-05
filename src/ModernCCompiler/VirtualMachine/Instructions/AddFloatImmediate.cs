using static VirtualMachine.Utils.FloatConvert;

namespace VirtualMachine.Instructions
{
    public class AddFloatImmediate : IInstruction
    {
        private readonly string _dst;
        private readonly string _src;
        private readonly float _val;

        public AddFloatImmediate(string dst, string src, float val)
        {
            _dst = dst;
            _src = src;
            _val = val;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextReader inStream, TextWriter outStream)
        {
            registers[_dst] = ToInt(ToFloat(registers[_src]) + _val);
        }

        public string ToCode()
        {
            return $"addfi {_dst} {_src} {_val}";
        }
    }
}
