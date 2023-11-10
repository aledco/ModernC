namespace Compiler.VirtualMachine.Instructions
{
    public class Label : IInstruction
    {
        public string LabelName { get; }

        public Label(string label) 
        { 
            LabelName = label;
        }

        public void Execute(Memory memory, Registry registry, Dictionary<string, int> labels)
        {
        }

        public string ToCode()
        {
            return $"{LabelName}:";
        }
    }
}
