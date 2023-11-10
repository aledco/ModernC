namespace Compiler.x86
{
    public class Operand
    {
        public string? Register1 { get; }
        public string? Register2 { get; }
        public string? VariableName { get; }
        public bool Dereference { get; };
        public int? Offset { get; }
        public int? Multiplier { get; }

        private readonly string _repr;

        public Operand(string register, bool dereference = false)
        {
            Register1 = register;
            Dereference = dereference;
            if (dereference)
            {
                _repr = $"[{register}]";
            }
            else
            {
                _repr = register;
            }
        }

        public Operand(string register1, string register2)
        {
            Register1 = register1;
            Register2 = register2;
            Dereference = true;
            _repr = $"[{register1}+{register2}]";
        }

        public Operand(int multiplier, string register)
        {
            Multiplier = multiplier;
            Register1 = register;
            Dereference = true;
            _repr = $"[{multiplier}*{register}]";
        }

        public Operand(int multiplier, string register1, string register2)
        {
            Multiplier = multiplier;
            Register1 = register1;
            Register2 = register2;
            Dereference = true;
            _repr = $"[{multiplier}*{register1}+{register2}]";
        }

        public Operand(string register1, int multiplier, string register2)
        {
            Register1 = register1; 
            Multiplier = multiplier;
            Register2 = register2;
            Dereference = true;
            _repr = $"[{register1}+{multiplier}*{register2}]";
        }
    }
}
