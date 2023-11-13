using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.VirtualMachine.Instructions
{
    public class Load : IInstruction
    {
        private readonly string _dst;
        private readonly string _addr;
        private readonly int _offset;

        public Load(string dst, string addr, int offset = 0) 
        { 
            _dst = dst;
            _addr = addr;
            _offset = offset;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels)
        {
            registers[_dst] = memory[registers[_addr] + _offset];
        }

        public string ToCode()
        {
            return $"ld {_dst} {_addr}";
        }
    }
}
