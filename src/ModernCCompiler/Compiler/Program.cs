using Compiler.Input;
using Compiler.ParseAbstraction;
using Compiler.TreeWalking.CodeGeneration.VirtualMachine;
using Compiler.TreeWalking.TypeCheck;
using Compiler.VirtualMachine;

/*
 * TODO:
 * - finish byte escape sequences
 * - float
 * - read input
 * - make ok return 0, exit code exits program with error code, add println.
 * - arrays
 * - byte strings
 * - pointers
 * - structs/unions/enums
 * - lambda expressions
 * - if expressions
 * - global variables / statements
 * - bitwise operators
 * - char and char strings
 * - file inclusion
 * - better command line args
 * - optimization unit
 * - smarter callee saved registers
 * - casting
 * - compile to llvm or x86
 * - std library / link with C
 * - switch/goto
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
