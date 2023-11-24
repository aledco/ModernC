using Compiler.Models.Tree;

namespace Compiler.ErrorHandling
{
    public static class ErrorHandler
    {
        public static bool Testing { get; set; } = false;

        public static void Throw(string message, AbstractSyntaxTree node)
        {
            if (Testing)
            {
                throw new Exception($"{message}\n\tAt {node.Span}");
            }
            else
            {
                Console.Error.WriteLine(message);
                Console.Error.WriteLine($"\tAt {node.Span}");
                Environment.Exit(1);
            }
        }
    }
}
