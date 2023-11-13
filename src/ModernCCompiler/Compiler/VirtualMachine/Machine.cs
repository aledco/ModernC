using Compiler.VirtualMachine.Instructions;
using System.Text;

namespace Compiler.VirtualMachine
{
    public static class Machine
    {
        public static void Run(IList<IInstruction> instructions)
        {
            var memory = new Memory();
            var registers = new Registers();
            var labels = new Dictionary<string, int>();
            for (var i = 0; i < instructions.Count; i++)
            {
                if (instructions[i] is Label label)
                {
                    labels[label.LabelName] = i;
                }
            }

            while (registers[Registers.ProgramCounter] < instructions.Count) 
            {
                instructions[registers[Registers.ProgramCounter]].Execute(memory, registers, labels);
                registers[Registers.ProgramCounter]++;
            }
        }

        public static string ToCode(IList<IInstruction> instructions)
        {
            var code = new StringBuilder();
            foreach (var instruction in instructions) 
            {
                code.AppendLine(instruction.ToCode());
            }

            return code.ToString();
        }
    }
}
