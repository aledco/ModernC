namespace Compiler.VirtualMachine.Instructions
{
    public class Blank : IInstruction
    {
        public Blank() { }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextReader inStream, TextWriter outStream)
        {
            // do nothing
        }

        public string ToCode()
        {
            return string.Empty;
        }
    }
}
