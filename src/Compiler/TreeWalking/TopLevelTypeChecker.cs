using Compiler.Models.NameResolution.Types;
using Compiler.Models.Symbols;
using Compiler.Models.Tree;

namespace Compiler.TreeWalking
{
    /// <summary>
    /// Does the first pass of name resolution, filling the global and function scopes.
    /// This allows function to be defined in any order but still be visable.
    /// </summary>
    internal class TopLevelTypeChecker : IWalker
    {
        public void Walk(ProgramRoot program)
        {
            VisitProgramRoot(program);
        }

        private static void VisitProgramRoot(ProgramRoot program)
        {
            program.GlobalScope = new Scope();
            foreach (var functionDefinition in program.FunctionDefinitions)
            {
                VisitFunctionDefinition(functionDefinition, program.GlobalScope);
            }
        }

        private static void VisitFunctionDefinition(FunctionDefinition functionDefinition, Scope scope)
        {
            functionDefinition.FunctionScope = new Scope();
            var returnType = functionDefinition.ReturnType.ToSemanticType();
            var parameterTypes = VisitParameterList(functionDefinition.ParameterList, functionDefinition.FunctionScope);
            scope.Add(functionDefinition.Id, new FunctionType(returnType, parameterTypes));
            VisitIdNode(functionDefinition.Id, scope);
        }

        private static IEnumerable<SemanticType> VisitParameterList(ParameterList parameterList, Scope functionScope)
        {
            var parameterTypes = new List<SemanticType>();
            foreach (var parameter in parameterList)
            {
                var type = parameter.Type.ToSemanticType();
                functionScope.Add(parameter.Id, type);
                VisitIdNode(parameter.Id, functionScope);
                parameterTypes.Add(type);
            }

            return parameterTypes;
        }

        private static void VisitIdNode(IdNode id, Scope scope)
        {
            id.Symbol = scope.Get(id);
        }
    }
}
