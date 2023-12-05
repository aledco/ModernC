namespace VirtualMachine.Instructions
{
    public class PrintInt : IInstruction
    {
        private readonly string _src;

        public PrintInt(string src) 
        {
            _src = src;
        }
        
        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextReader inStream, TextWriter outStream)
        {
            outStream.Write(registers[_src]);
        }

        public string ToCode()
        {
            return $"pint {_src}";
        }
    }
}
