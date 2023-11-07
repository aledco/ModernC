using Compiler.Input;
using Compiler.ParseAbstraction;
using Compiler.TreeWalking;

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
            var walkers = GetWalkers();
            foreach (var walker in walkers)
            {
                walker.Walk(tree);
            }

            // TODO generate intermediate code or (LLVM)

            // TODO generate actual assembly or interpret intermediate code

            // TODO assemble and link
        }

        private static IEnumerable<IWalker> GetWalkers()
        {
            return new IWalker[]
            {
                new TopLevelTypeChecker(),
                new LocalTypeChecker(),
                // TODO calculate offsets and assign registers
                // TODO generate LLVM code
            };
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
