using Compiler.Input;
using Compiler.ParseAbstraction;
using Compiler.TreeWalking;

/*
 * TODO:
 * - Add a test project, test parsing, test tree walking, etc
 * - Make GitHub repo for project
 */
namespace Compiler
{
    internal class Program
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

            // TODO generate intermediate code

            // TODO generate actual assembly or interpret intermediate code

            // TODO assemble and link
        }

        private static IEnumerable<IWalker> GetWalkers()
        {
            return new IWalker[]
            {
                new TopLevelTypeChecker()
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
