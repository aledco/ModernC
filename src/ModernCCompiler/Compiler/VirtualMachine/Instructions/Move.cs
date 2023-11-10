namespace Compiler.VirtualMachine.Instructions
{
    public class Move : IInstruction
    {
        private readonly string _dst;
        private readonly string _src;

        public Move(string dst, string src)
        {
            _dst = dst;
            _src = src;
        }

        public void Execute(Memory memory, Registry registry, Dictionary<string, int> labels)
        {
            registry.Registers[_dst] = registry.Registers[_src];
        }

        public string ToCode()
        {
            return $"mov {_dst} {_src}";
        }
    }
}
