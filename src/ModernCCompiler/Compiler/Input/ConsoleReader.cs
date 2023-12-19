using System.Text;

namespace Compiler.Input
{
    /// <summary>
    /// The console reader.
    /// </summary>
    public class ConsoleReader
    {
        private readonly char _eof = Convert.ToChar(4);

        /// <summary>
        /// Reads input from the console.
        /// </summary>
        /// <param name="compile">If true then print compiled code.</param>
        /// <param name="printException">If true then print exceptions.</param>
        /// <returns></returns>
        public string Read(out bool compile, out bool printException)
        {
            compile = false;
            printException = false;

            var text = new StringBuilder();
            Console.WriteLine("-----");
            Console.Write("options [-c | -e]: ");
            var input = Console.ReadLine();
            if (input != null)
            {
                var options = input.Replace("options: ", "").Split();
                if (options.Contains("-c"))
                {
                    compile = true;
                }

                if (options.Contains("-e"))
                {
                    printException = true;
                }
            }

            Console.WriteLine("-----\n");

            while ((input = Console.ReadLine()) != null && (input.Length == 0 || input[0] != _eof))
            {
                text.AppendLine(input);
            }
            
            return text.ToString();
        }
    }
}
