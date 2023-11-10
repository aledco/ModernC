using Compiler.VirtualMachine.Instructions;
using System.Text;

namespace Compiler.VirtualMachine
{
    public static class Machine
    {
        public static void Run(IList<IInstruction> instructions)
        {
            var memory = new Memory();
            var registry = new Registry();
            var labels = new Dictionary<string, int>();
            for (var i = 0; i < instructions.Count; i++)
            {
                if (instructions[i] is Label label)
                {
                    labels[label.LabelName] = i;
                }
            }

            foreach(var instruction in instructions)
            {
                instruction.Execute(memory, registry, labels);
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
