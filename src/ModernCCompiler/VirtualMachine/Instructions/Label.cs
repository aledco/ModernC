namespace VirtualMachine.Instructions
{
    public class Label : IInstruction
    {
        public string LabelName { get; }

        public Label(string label) 
        { 
            LabelName = label;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextReader inStream, TextWriter outStream)
        {
        }

        public string ToCode()
        {
            return $"{LabelName}:";
        }
    }
}
