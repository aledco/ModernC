namespace VirtualMachine.Instructions
{
    public class DeclareGlobal : IInstruction
    {
        public string LabelName { get; }
        public int Size { get; }

        public DeclareGlobal(string label, int size)
        {
            LabelName = label;
            Size = size;
        }
           
        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextReader inStream, TextWriter outStream)
        {
        }

        public string ToCode()
        {
            return $"declare {LabelName} {Size}";
        }
    }
}
