namespace Compiler.VirtualMachine.Instructions
{
    public class Read : IInstruction
    {
        private readonly string _dst;

        public Read(string dst)
        {
            _dst = dst;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextReader inStream, TextWriter outStream)
        {
            var b = inStream.Read();
            registers[_dst] = b == -1 ? '\0' : b;
        }

        public string ToCode()
        {
            return $"read {_dst}";
        }
    }
}
