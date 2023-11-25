namespace Compiler.VirtualMachine.Instructions
{
    public class PrintBool : IInstruction
    {
        private readonly string _src;

        public PrintBool(string src)
        {
            _src = src;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextWriter outStream)
        {
            outStream.Write(registers[_src] == 0 ? "false" : "true");
        }

        public string ToCode()
        {
            return $"pbool {_src}";
        }
    }
}
