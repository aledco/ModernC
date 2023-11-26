namespace Compiler.VirtualMachine.Instructions
{
    public class PrintByte : IInstruction
    {
        private readonly string _src;

        public PrintByte(string src)
        {
            _src = src;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextReader inStream, TextWriter outStream)
        {
            outStream.Write(Convert.ToChar(registers[_src]));
        }

        public string ToCode()
        {
            return $"pbyte {_src}";
        }
    }
}
