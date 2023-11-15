namespace Compiler.VirtualMachine.Instructions
{
    public class Not : IInstruction
    {
        private readonly string _dst;
        private readonly string _src;

        public Not(string dst, string src)
        {
            _dst = dst;
            _src = src;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextWriter outStream)
        {
            registers[_dst] = 1 - registers[_src];
        }

        public string ToCode()
        {
            return $"not {_dst} {_src}";
        }
    }
}
