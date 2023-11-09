using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Tree;
using System.Diagnostics;

namespace Compiler.TreeWalking
{
    /// <summary>
    /// Does the first pass of name resolution, filling the global and function scopes.
    /// This allows function to be defined in any order but still be visable.
    /// </summary>
    public class TopLevelTypeChecker : IWalker
    {
        public void Walk(ProgramRoot program)
        {
            VisitProgramRoot(program);
        }

        private void VisitProgramRoot(ProgramRoot program)
        {
            program.GlobalScope = new Scope();
            foreach (var functionDefinition in program.FunctionDefinitions)
            {
                VisitFunctionDefinition(functionDefinition, program.GlobalScope);
            }
        }

        private void VisitFunctionDefinition(FunctionDefinition functionDefinition, Scope scope)
        {
            functionDefinition.FunctionScope = new Scope(scope);
            var returnType = functionDefinition.ReturnType.ToSemanticType();
            var parameterTypes = VisitParameterList(functionDefinition.ParameterList, functionDefinition.FunctionScope);
            scope.Add(functionDefinition.Id, new FunctionType(returnType, parameterTypes));
            VisitIdNode(functionDefinition.Id, scope);
        }

        private IEnumerable<SemanticType> VisitParameterList(ParameterList parameterList, Scope functionScope)
        {
            var parameterTypes = new List<SemanticType>();
            foreach (var parameter in parameterList.Parameters)
            {
                var type = parameter.Type.ToSemanticType();
                functionScope.Add(parameter.Id, type);
                VisitIdNode(parameter.Id, functionScope);
                parameterTypes.Add(type);
            }

            return parameterTypes;
        }

        private void VisitIdNode(IdNode id, Scope scope)
        {
            id.Symbol = scope.Lookup(id);
        }
    }
}
