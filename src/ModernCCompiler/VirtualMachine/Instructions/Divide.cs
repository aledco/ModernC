namespace VirtualMachine.Instructions
{
    public class Divide : IInstruction
    {
        private readonly string _dst;
        private readonly string _left;
        private readonly string _right;

        public Divide(string dst, string left, string right)
        {
            _dst = dst;
            _left = left;
            _right = right;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextReader inStream, TextWriter outStream)
        {
            registers[_dst] = registers[_left] / registers[_right];
        }

        public string ToCode()
        {
            return $"div {_dst} {_left} {_right}";
        }
    }
}
