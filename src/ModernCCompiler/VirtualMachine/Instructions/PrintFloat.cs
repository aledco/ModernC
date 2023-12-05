using static VirtualMachine.Utils.FloatConvert;

namespace VirtualMachine.Instructions
{
    public class PrintFloat : IInstruction
    {
        private readonly string _src;

        public PrintFloat(string src)
        {
            _src = src;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextReader inStream, TextWriter outStream)
        {
            outStream.Write(ToFloat(registers[_src]));
        }

        public string ToCode()
        {
            return $"pfloat {_src}";
        }
    }
}
