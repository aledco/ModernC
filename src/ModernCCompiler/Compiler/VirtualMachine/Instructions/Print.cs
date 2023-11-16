namespace Compiler.VirtualMachine.Instructions
{
    public class Print : IInstruction
    {
        private readonly string _src;

        public Print(string src) 
        {
            _src = src;
        }
        
        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextWriter outStream)
        {
            outStream.WriteLine(registers[_src]);
        }

        public string ToCode()
        {
            return $"p {_src}";
        }
    }
}
