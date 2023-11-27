using Compiler.CommandLine;
using Compiler.Input;
using Compiler.ParseAbstraction;
using Compiler.TreeWalking.CodeGeneration.VirtualMachine;
using Compiler.TreeWalking.TypeCheck;
using Compiler.VirtualMachine;

/*
 * TODO:
 * - Add break and continue
 * - make ok return 0, exit code exits program with error code, add println.
 * - make the identifier of a function call an expression (might need to make a callableExpression production)
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
        private static void Main(string[] sargs)
        {
            var args = new Args(sargs);
            var reader = args.GetReader();
            switch (args.Mode)
            {
                case Mode.Interpret:
                    Interpret(reader);
                    break;
                case Mode.Compile:
                    Compile(reader);
                    break;
                case Mode.Execute:
                    Execute(reader);
                    break;
            }
        }

        private static void Interpret(IReader reader)
        {
            while (true)
            {
                var input = reader.Read();
                var tree = Parser.Parse(input);
                TopLevelTypeChecker.Walk(tree);
                LocalTypeChecker.Walk(tree);
                var instructions = CodeGenerator.Walk(tree);
                //Console.WriteLine(Machine.ToCode(instructions));
                Machine.Run(instructions, Console.In, Console.Out);
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private static void Compile(IReader reader) 
        {
            var input = reader.Read();
            var tree = Parser.Parse(input);
            TopLevelTypeChecker.Walk(tree);
            LocalTypeChecker.Walk(tree);
            var instructions = CodeGenerator.Walk(tree);
            var asm = Machine.ToCode(instructions);
            File.WriteAllText("a.out", asm); // TODO cmd arg for out file
        }

        private static void Execute(IReader reader)
        {
            var input = reader.Read();
            var tree = Parser.Parse(input);
            TopLevelTypeChecker.Walk(tree);
            LocalTypeChecker.Walk(tree);
            var instructions = CodeGenerator.Walk(tree);
            Machine.Run(instructions, Console.In, Console.Out);
        }
    }
}
