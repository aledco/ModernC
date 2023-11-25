using Compiler.Input;
using Compiler.ParseAbstraction;
using Compiler.TreeWalking.CodeGeneration.VirtualMachine;
using Compiler.TreeWalking.TypeCheck;
using Compiler.VirtualMachine;

/*
 * TODO:
 * - finalize interaction between float and int types
 * - read byte statement
 * - make ok return 0, exit code exits program with error code, add println.
 * - make function calls expressions
 * - arrays
 * - byte strings
 * - pointers
 * - structs/unions/enums
 * - lambda expressions
 * - if expressions
 * - global variables / statements
 * - bitwise operators
 * - char and char strings
 * - input num should read num chars from stdin
 * - file inclusion
 * - better command line args
 * - repl using interpreter
 * - comment code
 * - optimization unit
 * - smarter callee saved registers
 * - casting
 * - compile to llvm or x86 or C
 * - std library / link with C
 * - switch/goto
 */
namespace Compiler
{
    public class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                var reader = GetReader(args);
                var input = reader.Read();
                var tree = Parser.Parse(input);
                TopLevelTypeChecker.Walk(tree);
                LocalTypeChecker.Walk(tree);
                var instructions = CodeGenerator.Walk(tree);
                //Console.WriteLine(Machine.ToCode(instructions));
                Machine.Run(instructions, Console.Out);
                Console.WriteLine();
                Console.WriteLine();
            }
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
