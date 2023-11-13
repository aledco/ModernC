namespace Compiler.VirtualMachine.Instructions
{
    public class Store : IInstruction
    {
        private readonly string _addr;
        private readonly string _src;
        private readonly int _offset;

        public Store(string addr, string src, int offset = 0)
        {
            _addr = addr;
            _src = src;
            _offset = offset;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels)
        {
            memory[registers[_addr] + _offset] = registers[_src];
        }

        public string ToCode()
        {
            return $"st {_addr} {_src}";
        }
    }
}
