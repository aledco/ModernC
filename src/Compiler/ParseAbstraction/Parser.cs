using Antlr4.Runtime;
using Compiler.Models.Tree;

namespace Compiler.ParseAbstraction
{
    internal class Parser
    {
        /// <summary>
        /// Parses the input and returns an abstract syntax tree.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The abstract syntax tree.</returns>
        /// <exception cref="Exception">Parse error.</exception>
        public static ProgramRoot Parse(string input)
        {
            // Lex
            AntlrInputStream inputStream = new AntlrInputStream(input);
            ModernCLexer speakLexer = new ModernCLexer(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(speakLexer);

            // Parse
            ModernCParser modernCParser = new ModernCParser(commonTokenStream);
            ModernCParser.ProgramContext programContext = modernCParser.program();

            // Abstract
            ParseAbstractionVisitor visitor = new ParseAbstractionVisitor();
            var tree = visitor.Visit(programContext);
            if (tree is ProgramRoot program)
            {
                Console.WriteLine(program);
            }

            throw new Exception($"Tried to parse {tree.GetType()} as program");
        }
    }
}
