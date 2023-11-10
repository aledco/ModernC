namespace VirtualMachine.Instructions
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

        public void Execute(List<int> memory, Dictionary<string, int> registers, List<string> labels)
        {
            registers[_dst] = registers[_src];
        }

        public string ToCode()
        {
            return $"mov {_dst} {_src}";
        }
    }
}
