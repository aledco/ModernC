namespace Compiler.VirtualMachine.Instructions
{
    public interface IInstruction
    {
        void Execute(Memory memory, Registry registers, Dictionary<string, int> labels);

        string ToCode();
    }
}
