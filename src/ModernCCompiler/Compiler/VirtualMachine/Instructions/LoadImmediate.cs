using static Compiler.Utils.FloatConvert;

namespace Compiler.VirtualMachine.Instructions
{
    public class LoadImmediate : IInstruction
    {
        private readonly string _dst;
        private readonly int _val;
        private readonly float? _fval = null;
        private readonly char? _cval = null;

        public LoadImmediate(string dst, int val)
        {
            _dst = dst;
            _val = val;
        }

        public LoadImmediate(string dst, float val)
        {
            _dst = dst;
            _val = ToInt(val);
            _fval = val;
        }

        public LoadImmediate(string dst, char val)
        {
            _dst = dst;
            _val = val;
            _cval = val;
        }

        public void Execute(Memory memory, Registers registers, Dictionary<string, int> labels, TextReader inStream, TextWriter outStream)
        {
            registers[_dst] = _val;
        }

        public string ToCode()
        {
            if (_cval.HasValue)
            {
                return $"li {_dst} '{GetCharRepr(_cval.Value)}'";
                
            }
            else if (_fval.HasValue)
            {
                return $"li {_dst} {_fval}";
            }
            else
            {
                return $"li {_dst} {_val}";
            }
        }

        private static string GetCharRepr(char c)
        {
            return c switch
            {
                '\n' => @"\n",
                _ => c.ToString(),
            };
        }
    }
}
