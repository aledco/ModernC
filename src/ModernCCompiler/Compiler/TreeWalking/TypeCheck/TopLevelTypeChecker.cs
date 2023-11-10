using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Tree;

namespace Compiler.TreeWalking.TypeCheck
{
    /// <summary>
    /// Does the first pass of name resolution, filling the global and function scopes.
    /// This allows function to be defined in any order but still be visable.
    /// </summary>
    public class TopLevelTypeChecker : IWalker
    {

        public static void Walk(ProgramRoot program)
        {
            VisitProgramRoot(program, new Scope());
        }

        private static void VisitProgramRoot(ProgramRoot program, Scope scope)
        {
            program.GlobalScope = scope;
            foreach (var functionDefinition in program.FunctionDefinitions)
            {
                VisitFunctionDefinition(functionDefinition, scope);
            }
        }

        private static void VisitFunctionDefinition(FunctionDefinition functionDefinition, Scope scope)
        {
            functionDefinition.FunctionScope = new Scope(scope);
            var returnType = functionDefinition.ReturnType.ToSemanticType();
            var parameterTypes = VisitParameterList(functionDefinition.ParameterList, functionDefinition.FunctionScope);
            scope.Add(functionDefinition.Id, new FunctionType(returnType, parameterTypes));
            VisitIdNode(functionDefinition.Id, scope);
        }

        private static IEnumerable<SemanticType> VisitParameterList(ParameterList parameterList, Scope scope)
        {
            var parameterTypes = new List<SemanticType>();
            foreach (var parameter in parameterList.Parameters)
            {
                var type = parameter.Type.ToSemanticType();
                scope.Add(parameter.Id, type);
                VisitIdNode(parameter.Id, scope);
                parameterTypes.Add(type);
            }

            return parameterTypes;
        }

        private static void VisitIdNode(IdNode id, Scope scope)
        {
            id.Symbol = scope.Lookup(id);
        }
    }
}
