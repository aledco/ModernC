using Compiler.Input;
using Compiler.Models.Tree;
using Compiler.ParseAbstraction;
using Compiler.TreeWalking.TypeCheck;

/*
 * TODO:
 * - Add better error handling
 */
namespace Compiler
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var reader = GetReader(args);
            var input = reader.Read();
            var tree = Parser.Parse(input);
            Annotate(tree);

            // TODO generate intermediate code or (LLVM)

            // TODO generate actual assembly or interpret intermediate code

            // TODO assemble and link
        }

        private static void Annotate(ProgramRoot tree)
        {
            TopLevelTypeChecker.Walk(tree);
            LocalTypeChecker.Walk(tree);
            // TODO add additional walkers
        }

        private static IReader GetReader(string[] args)
        {
            if (args.Length == 0)
            {
                return new ConsoleReader();
            }
            else
            {
                // TODO read command line args better
                var path = args[0];
                return new FileReader(path);
            }
        }
    }
}
