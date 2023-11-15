using Compiler.Input;
using Compiler.ParseAbstraction;
using Compiler.TreeWalking.CodeGeneration.VirtualMachine;
using Compiler.TreeWalking.TypeCheck;
using Compiler.VirtualMachine;

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
            TopLevelTypeChecker.Walk(tree);
            LocalTypeChecker.Walk(tree);
            var instructions = CodeGenerator.Walk(tree);
            //Console.WriteLine(Machine.ToCode(instructions));
            Machine.Run(instructions, Console.Out);

            // TODO generate intermediate code or (LLVM)

            // TODO generate actual assembly or interpret intermediate code

            // TODO assemble and link
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
