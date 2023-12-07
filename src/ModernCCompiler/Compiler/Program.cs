using Compiler.Config;
using Compiler.ErrorHandling;
using Compiler.Input;
using Compiler.ParseAbstraction;
using Compiler.TreeWalking.CodeGeneration.VirtualMachine;
using Compiler.TreeWalking.TypeCheck;
using VirtualMachine;

/*
 * TODO:
 * - things to decide:
 *      - need to define an ordering for global statements / definitions
 *          - statements and definitions may need to be processed in order
 *      - pointer math
 *      - semi colons or commas for structs?
 * 
 * - code maintenence:
 *      - add code underlining to error messages and better error messages
 *      - comment code
 *      - make full program tests
 *      - git CI
 * 
 * - structures to implement:
 *      - type aliases
 *      - arrays
 *      - byte strings
 *      - char type and char strings
 *      - unions
 *      - enums
 *      - dynamic pointers that point to memory on the heap (can be returned from functions)
 * 
 * - expressions to implement:
 *      - if expressions
 *      - lambda expressions
 *      - cast expression
 *      - switch expressions
 *      - input expression should read a string from stdin
 *      - allow comparisons on both sides, for example 0 <= x <= 10.
 *
 * - statements to implement:
 *      - switch statement
 *      - additional looping constructs
 *              - loop 10 { } loops 10 times
 *              - loop { } loops forever
 *      - disallow variable definitions without initialization?
 *              
 * - types to implement:
 *      - rewrite type system 
 *          - more complex (i8-128 u8-128 f32-128)
 *          - byte and char are aliases for u8
 *      - uchar? alias for u16
 *          - come up with better name
 *          
 * - others to implement:
 *      - move semantics (<- as operator / assignement)
 *      - type modifiers (const, static, dynamic, etc.)
 *      - variadic / keyword parameters
 *      - struct functions
 *      - type functions that are associated to types (int.parseFloat)
 *      - multiple dispatch (allow functions with the same names but different parameter types)
 *      - bitwise operators
 *      - preprocessor for macros?
 *      - interfaces? then iterators and toString etc can be supported for structs
 *      - prologue file that is added to every ast by compiler with useful definitions and functions
 *      - file inclusion
 *             - import statements import ModernC code (compiled or source)
 *             - include statements use the preprocessor to include compiled C code
 *      - module system
 *      - optimization unit
 *      - build system (like cargo)
 *      - smarter callee saved registers and Sethi-Ullman register allocation
 *      - compile to llvm or x86 or C
 *      - std library / link with C
 *      - write specification
 */
namespace Compiler
{
    public class Program
    {
        /// <summary>
        /// Entry point of the compiler.
        /// </summary>
        /// <param name="args">The arguments from the command line.</param>
        private static void Main(string[] args)
        {
            Configuration.Initialize(args);
            switch (Configuration.Mode)
            {
                case Mode.Interpret:
                    Interpret();
                    break;
                case Mode.Compile:
                    Compile();
                    break;
                case Mode.Execute:
                    Execute();
                    break;
            }
        }

        /// <summary>
        /// Runs the interpreter.
        /// </summary>
        private static void Interpret()
        {
            ErrorHandler.ThrowExceptions = true;
            var reader = new ConsoleReader();
            while (true)
            {
                var printException = false;
                try
                {
                    var input = reader.Read(out var compile, out printException);
                    var tree = Parser.Parse(input);
                    GlobalTypeChecker.Walk(tree);
                    LocalTypeChecker.Walk(tree);
                    var instructions = CodeGenerator.Walk(tree);
                    if (compile)
                    {
                        Console.WriteLine(Machine.ToCode(instructions));
                    }
                    else
                    {
                        Machine.Run(instructions, Console.In, Console.Out);
                    }
                }
                catch (Exception ex)
                {
                    if (printException)
                    {
                        Console.Error.WriteLine(ex);
                    }
                }
                finally
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    GlobalManager.Clear();
                }
            }
        }

        /// <summary>
        /// Compiles the source code and saves the compiled code to a file.
        /// </summary>
        private static void Compile() 
        {
            var reader = new FileReader(Configuration.FileName);
            var input = reader.Read();
            var tree = Parser.Parse(input);
            GlobalTypeChecker.Walk(tree);
            LocalTypeChecker.Walk(tree);
            var instructions = CodeGenerator.Walk(tree);
            var asm = Machine.ToCode(instructions);
            File.WriteAllText(Configuration.OutputFileName, asm);
        }

        /// <summary>
        /// Compiles the source code and executes it in the VM.
        /// </summary>
        private static void Execute()
        {
            var reader = new FileReader(Configuration.FileName);
            var input = reader.Read();
            var tree = Parser.Parse(input);
            GlobalTypeChecker.Walk(tree);
            LocalTypeChecker.Walk(tree);
            var instructions = CodeGenerator.Walk(tree);
            Machine.Run(instructions, Console.In, Console.Out);
        }
    }
}
