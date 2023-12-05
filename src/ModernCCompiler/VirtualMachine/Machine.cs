using System.Text;
using VirtualMachine.Instructions;

namespace VirtualMachine
{
    public static class Machine
    {
        public static void Run(IList<IInstruction> instructions, TextReader inStream, TextWriter outStream)
        {
            var memory = new Memory();
            var registers = new Registers();
            var labels = new Dictionary<string, int>();

            var dataOffset = Memory.GetDataPointer();
            for (var i = 0; i < instructions.Count; i++)
            {
                if (instructions[i] is Label label)
                {
                    if (labels.ContainsKey(label.LabelName))
                    {
                        throw new Exception($"Label has already been defined: {label.LabelName}");
                    }

                    labels[label.LabelName] = i;
                }
                else if (instructions[i] is DeclareGlobal declaration)
                {
                    if (labels.ContainsKey(declaration.LabelName))
                    {
                        throw new Exception($"Label has already been defined: {declaration.LabelName}");
                    }

                    labels[declaration.LabelName] = dataOffset;
                    dataOffset += declaration.Size;
                }
            }

            while (registers[Registers.ProgramCounter] < instructions.Count) 
            {
                instructions[registers[Registers.ProgramCounter]].Execute(memory,
                                                                          registers,
                                                                          labels,
                                                                          inStream,
                                                                          outStream);
                registers[Registers.ProgramCounter]++;
            }
        }

        public static string ToCode(IList<IInstruction> instructions)
        {
            var code = new StringBuilder();

            foreach (var instruction in instructions) 
            {
                if (instruction is Label or DeclareGlobal) 
                {
                    code.AppendLine(instruction.ToCode());
                }
                else
                {
                    code.AppendLine($"    {instruction.ToCode()}");
                }
            }

            return code.ToString();
        }
    }
}
