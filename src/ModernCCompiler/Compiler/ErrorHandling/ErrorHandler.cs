using Compiler.Models;
using Compiler.Models.Tree;

namespace Compiler.ErrorHandling
{
    public static class ErrorHandler
    {
        public static bool ThrowExceptions { get; set; } = false;
        public static Exception FailedToExit { get; } = new Exception("ErrorHandler failed to exit the application");

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

        public static void Throw(string message, Span? span)
        {
            Console.Error.WriteLine(message);
            if (span != null)
            {
                Console.Error.WriteLine($"\tAt {span}");
            }
           
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
