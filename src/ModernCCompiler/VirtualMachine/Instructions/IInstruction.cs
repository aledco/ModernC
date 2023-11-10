namespace VirtualMachine.Instructions
{
    public interface IInstruction
    {
        void Execute(List<int> memory, Dictionary<string, int> registers, List<string> labels);

        string ToCode();
    }
}
