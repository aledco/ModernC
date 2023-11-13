namespace Compiler.VirtualMachine.Instructions
{
    public interface IInstruction
    {
        void Execute(Memory memory, Registers registers, Dictionary<string, int> labels);

        string ToCode();
    }
}
