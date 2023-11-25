namespace Compiler.VirtualMachine.Instructions
{
    public class GreaterThanEqual : IInstruction
    {
        private readonly string _dst;
        private readonly string _left;
        private readonly string _right;

        public GreaterThanEqual(string dst, string left, string right)
        {
            _dst = dst;
            _left = left;
            _right = right;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextWriter outStream)
        {
            registers[_dst] = registers[_left] >= registers[_right] ? 1 : 0;
        }

        public string ToCode()
        {
            return $"gte {_dst} {_left} {_right}";
        }
    }
}
