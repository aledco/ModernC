using Compiler.CommandLine;
using Compiler.ErrorHandling;
using Compiler.ParseAbstraction;
using Compiler.TreeWalking.CodeGeneration.VirtualMachine;
using Compiler.TreeWalking.TypeCheck;
using Compiler.VirtualMachine;

/*
 * TODO:
 * - arrays
 * - byte strings
 * - pointers
 * - structs/unions/enums
 * - make the identifier of a function call an expression (might need to make a callableExpression production)
 * - lambda expressions
 * - if expressions
 * - global variables / statements
 * - bitwise operators
 * - char and char strings
 * - input num should read num chars from stdin
 * - file inclusion
 * - add checks to make sure every code path has a return
 * - better command line args
 * - repl using interpreter
 * - add code underlining to error messages
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
            switch (args.Mode)
            {
                case Mode.Interpret:
                    ErrorHandler.Interpreting = true;
                    Interpret(args);
                    break;
                case Mode.Compile:
                    Compile(args);
                    break;
                case Mode.Execute:
                    Execute(args);
                    break;
            }
        }

        private static void Interpret(Args args)
        {
            var reader = args.GetReader();
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

        private static void Compile(Args args) 
        {
            var reader = args.GetReader();
            var input = reader.Read();
            var tree = Parser.Parse(input);
            TopLevelTypeChecker.Walk(tree);
            LocalTypeChecker.Walk(tree);
            var instructions = CodeGenerator.Walk(tree);
            var asm = Machine.ToCode(instructions);
            File.WriteAllText(args.OutputFileName, asm);
        }

        private static void Execute(Args args)
        {
            var reader = args.GetReader();
            var input = reader.Read();
            var tree = Parser.Parse(input);
            TopLevelTypeChecker.Walk(tree);
            LocalTypeChecker.Walk(tree);
            var instructions = CodeGenerator.Walk(tree);
            Machine.Run(instructions, Console.In, Console.Out);
        }
    }
}
