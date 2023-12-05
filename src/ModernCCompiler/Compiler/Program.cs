using Compiler.CommandLine;
using Compiler.ErrorHandling;
using Compiler.ParseAbstraction;
using Compiler.TreeWalking.CodeGeneration.VirtualMachine;
using Compiler.TreeWalking.TypeCheck;
using Compiler.Utils;
using Compiler.VirtualMachine;

/*
 * TODO:
 * - make full program tests
 * - disallow variable definitions without initialization?
 * - then type aliases, then pointers, then arrays and strings, then unions
 * - <- as move operator and allow complex types to be reassigned.
 * - consider having := as assignment
 * - enforce some kind of order to global entities
 * - implement arrays by the spec below
 * - implement arrays as a struct that hold it's size --or-- have a construct similar to generics that allows to a placeholder in the type
 *   that holds the arrays length to be used in code later
 * - rewrite type system 
 *      - more complex (i8-128 u8-128 f32-128)
 *      - byte and char are aliases for u8
 *      - uchar? alias for u16
 *          - come up with better name
 *      - make functions use func and -> return syntax, change type to have return last
 * - set up CI for git?
 * - rewrite param list and arg list like array literal
 * - move virtual machine to it's own project
 * - byte strings
 * - add a cast expression (int x = cast 1.2 -> int)?
 * - add type modifiers (const, static, dynamic, etc.)
 * - decide what the convention of nameing will be (snake case, pascal case, etc)
 * - decide if shadowing should be possible inside a scope
 * - add multiple dispatch (allow functions with the same names but different parameter types)
 * - add type functions that are associated to types (int.parseFloat)
 * - enums, switch statements and expressions
 * - lambda expressions
 * - add variadic / keyword parameters
 * - if expressions
 * - bitwise operators
 * - char and char strings
 * - input num should read num chars from stdin
 * - write a preprocessor for dealing with C style code (possibly macros)
 * - file inclusion
 *      - import statements import ModernC code (compiled or source)
 *      - include statements use the preprocessor to include compiled C code
 * - module system
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
 * - write specification
 * 
 * SPEC:
 * - Arrays are pass by value. Reassigning an array or passing it to / returning it from a function deep copies the entire array
 * - Arrays are not pointers like in C.
 * - Arrays will be implemented as a struct overtop the underlying an array that holds it's size
 * - Strings are smimilar to arrays
 * - Complex types have automatic dereferencing, for example, you can call a pointer to a function, or index a pointer to a pointer to an array
 * - Cannot return pointers, must use an out parameter (unless dynamic)
 * - Will have a dynamic pointer which means it points to memory on the heap
 * 
 * Move Semantics:
 * - complex types (arrays, structs) will be copied when returned or [asssed into functions
 * - for now, these types cannot be reassigned, maybe a move instruction will be implemented for that
 * - actually, maybe a move instruction should be used for functions too
 * - places that need to worry about it are
 *      - call expression
 *      - return statement
 * - values that require move semantics return an adrress through RValue
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
            ErrorHandler.ThrowExceptions = true;
            var reader = args.GetReader();
            while (true)
            {
                try
                {
                    var input = reader.Read();
                    var tree = Parser.Parse(input);
                    GlobalTypeChecker.Walk(tree);
                    LocalTypeChecker.Walk(tree);
                    var instructions = CodeGenerator.Walk(tree);
                    //Console.WriteLine(Machine.ToCode(instructions));
                    Machine.Run(instructions, Console.In, Console.Out);
                    Console.WriteLine();
                    Console.WriteLine();
                }
                catch (Exception ex) 
                { 
                    Console.Error.WriteLine(ex);
                }
                finally
                {
                    Globals.Clear();
                }
            }
        }

        private static void Compile(Args args) 
        {
            var reader = args.GetReader();
            var input = reader.Read();
            var tree = Parser.Parse(input);
            GlobalTypeChecker.Walk(tree);
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
            GlobalTypeChecker.Walk(tree);
            LocalTypeChecker.Walk(tree);
            var instructions = CodeGenerator.Walk(tree);
            Machine.Run(instructions, Console.In, Console.Out);
        }
    }
}
