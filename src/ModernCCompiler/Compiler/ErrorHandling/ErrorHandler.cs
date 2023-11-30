using Compiler.Models.Tree;

namespace Compiler.ErrorHandling
{
    public static class ErrorHandler
    {
        public static bool ThrowExceptions { get; set; } = false;

        public static void Throw(string message, AbstractSyntaxTree node)
        {
            Console.Error.WriteLine(message);
            Console.Error.WriteLine($"\tAt {node.Span}");
            if (ThrowExceptions)
            {
                throw new Exception();
            }
            else
            {
                Environment.Exit(1);
            }
        }

        public static void Throw(string message)
        {
            Console.Error.WriteLine(message);
            if (ThrowExceptions)
            {
                throw new Exception();
            }
            else
            {
                Environment.Exit(1);
            }
        }

        public static void ParseError()
        {
            if (ThrowExceptions)
            {
                throw new Exception();
            }
            else
            {
                Environment.Exit(1);
            }
        }
    }
}
