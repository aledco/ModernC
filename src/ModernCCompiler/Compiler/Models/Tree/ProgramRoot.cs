using Compiler.Context;
using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The root of the abstract syntax tree.
    /// </summary>
    public class ProgramRoot : AbstractSyntaxTree
    {
        /// <summary>
        /// Gets the global statements.
        /// </summary>
        public IList<Statement> GlobalStatements { get; }

        /// <summary>
        /// Gets the definitions.
        /// </summary>
        public IList<Definition> Definitions { get; }

        /// <summary>
        /// Gets the function definitions.
        /// </summary>
        public IList<FunctionDefinition> FunctionDefinitions { get; }

        /// <summary>
        /// Gets or sets the global scope.
        /// </summary>
        public Scope? GlobalScope { get; set; }

        /// <summary>
        /// Gets the main function label.
        /// </summary>
        public static string MainFunctionLabel { get; } = "main";

        /// <summary>
        /// Gets the progam exit label.
        /// </summary>
        public static string ExitLabel { get; } = "exit";

        /// <summary>
        /// Instantiates a new instance of a <see cref="ProgramRoot"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="statements">The statements</param>
        /// <param name="definitions">The definitions.</param>
        /// <param name="functionDefinitions">The function definitions.</param>
        public ProgramRoot(Span span,
                           IList<Statement> statements,
                           IList<Definition> definitions,
                           IList<FunctionDefinition> functionDefinitions) : base(span)
        {
            GlobalStatements = statements;
            Definitions = definitions;
            FunctionDefinitions = functionDefinitions;
        }

        /// <summary>
        /// Checks the semantics of the program.
        /// </summary>
        /// <returns>This to allow for call chaining.</returns>
        public ProgramRoot CheckSemantics()
        {
            CheckGlobalSemantics();
            CheckLocalSemantics();
            return this;
        }

        /// <summary>
        /// Checks the global semantics of the program.
        /// </summary>
        public void CheckGlobalSemantics()
        {
            CheckGlobalSemantics(new GlobalSemanticCheckContext());
        }

        /// <summary>
        /// Checks the local semantics of the program.
        /// </summary>
        public void CheckLocalSemantics()
        {
            CheckLocalSemantics(new LocalSemanticCheckContext());
        }

        public override SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context)
        {
            GlobalScope = context.Scope;
            foreach (var definition in Definitions)
            {
                definition.CheckGlobalSemantics(context);
            }

            foreach (var statement in GlobalStatements)
            {
                statement.CheckGlobalSemantics(context);
            }

            foreach (var functionDefinition in FunctionDefinitions)
            {
                functionDefinition.CheckGlobalSemantics(context);
            }

            return SemanticType.NoType;
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            foreach (var definition in Definitions)
            {
                definition.CheckLocalSemantics(context);
            }

            foreach (var functionDefinition in FunctionDefinitions)
            {
                functionDefinition.CheckLocalSemantics(context);
            }

            return SemanticType.NoType;
        }
    }
}
