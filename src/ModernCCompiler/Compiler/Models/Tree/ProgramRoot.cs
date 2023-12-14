using Compiler.Models.Context;
using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    public class ProgramRoot : AbstractSyntaxTree
    {
        public static string MainFunctionLabel { get; } = "main";
        public static string ExitLabel { get; } = "exit";
        public IList<Statement> GlobalStatements { get; }
        public IList<Definition> Definitions { get; }
        public IList<FunctionDefinition> FunctionDefinitions { get; }
        public Scope? GlobalScope { get; set; }

        public ProgramRoot(Span span,
                           IList<Statement> statements,
                           IList<Definition> definitions,
                           IList<FunctionDefinition> functionDefinitions) : base(span)
        {
            GlobalStatements = statements;
            Definitions = definitions;
            FunctionDefinitions = functionDefinitions;
        }

        public override SemanticType GlobalTypeCheck(GlobalTypeCheckContext context)
        {
            GlobalScope = context.Scope;
            foreach (var definition in Definitions)
            {
                definition.GlobalTypeCheck(context);
            }

            foreach (var statement in GlobalStatements)
            {
                statement.GlobalTypeCheck(context);
            }

            foreach (var functionDefinition in FunctionDefinitions)
            {
                functionDefinition.GlobalTypeCheck(context);
            }

            return SemanticType.NoType;
        }
    }
}
