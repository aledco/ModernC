using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Tree;

namespace Compiler.TreeWalking.TypeCheck
{
    /// <summary>
    /// Does the first pass of name resolution, filling the global and function scopes.
    /// This allows function to be defined in any order but still be visable.
    /// </summary>
    public static class TopLevelTypeChecker
    {
        private class Context
        {
            public Scope? Scope { get; set; }
            public FunctionDefinition? EnclosingFunction { get; set; }
        }

        public static void Walk(ProgramRoot program)
        {
            var context = new Context
            {
                Scope = new Scope()
            };
            VisitProgramRoot(program, context);
        }

        private static void VisitProgramRoot(ProgramRoot program, Context context)
        {
            program.GlobalScope = context.Scope;
            foreach (var functionDefinition in program.FunctionDefinitions)
            {
                VisitFunctionDefinition(functionDefinition, context);
            }
        }

        private static void VisitFunctionDefinition(FunctionDefinition functionDefinition, Context context)
        {
            var globalScope = context.Scope;

            functionDefinition.FunctionScope = new Scope(context.Scope);
            context.Scope = functionDefinition.FunctionScope;
            context.EnclosingFunction = functionDefinition;

            var returnType = functionDefinition.ReturnType.ToSemanticType();
            var parameterTypes = VisitParameterList(functionDefinition.ParameterList, context);

            globalScope?.Add(functionDefinition.Id, new FunctionType(returnType, parameterTypes));
            context.Scope = globalScope;
            VisitIdNode(functionDefinition.Id, context);
        }

        private static IList<SemanticType> VisitParameterList(ParameterList parameterList, Context context)
        {
            var parameterTypes = new List<SemanticType>();
            foreach (var parameter in parameterList.Parameters)
            {
                var type = parameter.Type.ToSemanticType();
                context.Scope?.Add(parameter.Id, type);
                VisitIdNode(parameter.Id, context);
                parameterTypes.Add(type);
            }

            return parameterTypes;
        }

        private static void VisitIdNode(IdNode id, Context context)
        {
            id.Symbol = context.Scope?.Lookup(id);
            if (id.Symbol != null) 
            {
                id.Symbol.EnclosingFunction = context.EnclosingFunction;
            }
        }
    }
}
