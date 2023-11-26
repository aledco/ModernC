using System.Text;

namespace Compiler.Input
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            string? input;
            var text = new StringBuilder();
            Console.WriteLine("-----\n");

            // type exit to send EOF
            while ((input = Console.ReadLine()) != null && (input.Length == 0 || input[0] != 4))
            { // TODO two enters instead?
                text.AppendLine(input);
            }

            return text.ToString();
        }
    }
}
