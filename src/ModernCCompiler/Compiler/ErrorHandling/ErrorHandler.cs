using Compiler.Models;
using Compiler.Models.Tree;

namespace Compiler.ErrorHandling
{
    /// <summary>
    /// Handles semantic errors in the source code.
    /// </summary>
    public static class ErrorHandler
    {
        /// <summary>
        /// Gets or sets a value indicating whether exceptions should be thrown.
        /// </summary>
        public static bool ThrowExceptions { get; set; } = false;

        /// <summary>
        /// Gets the failed to exit exception.
        /// </summary>
        public static Exception FailedToExit { get; } = new Exception("ErrorHandler failed to exit the application");

        /// <summary>
        /// Throws a semantic error.
        /// </summary>
        /// <param name="message">The message to show the user.</param>
        /// <param name="node">The ast node the error occured on.</param>
        /// <exception cref="Exception"></exception>
        public static void Throw(string message, AbstractSyntaxTree node)
        {
            Throw(message, node.Span);
        }

        /// <summary>
        /// Throws a semantic error.
        /// </summary>
        /// <param name="message">The message to show the user.</param>
        /// <param name="span">The span of the ast node the expception occured at.</param>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Throws a semantic error.
        /// </summary>
        /// <param name="message">The message to show the user.</param>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Throws a parse error.
        /// </summary>
        /// <exception cref="Exception"></exception>
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
