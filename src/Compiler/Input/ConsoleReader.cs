using System.Text;

namespace Compiler.Input
{
    internal class ConsoleReader : IReader
    {
        public string Read()
        {
            string? input;
            var text = new StringBuilder();
            Console.WriteLine("Enter Program");

            // type exit to send EOF
            while ((input = Console.ReadLine()) != "exit")
            {
                text.AppendLine(input);
            }

            return text.ToString();
        }
    }
}
