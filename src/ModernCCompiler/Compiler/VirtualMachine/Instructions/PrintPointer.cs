namespace Compiler.VirtualMachine.Instructions
{
    public class PrintPointer : IInstruction
    {
        private readonly string _src;

        public PrintPointer(string src)
        {
            _src = src;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextWriter outStream)
        {
            outStream.Write($"@{registers[_src]}");
        }

        public string ToCode()
        {
            return $"pptr {_src}";
        }
    }
}
