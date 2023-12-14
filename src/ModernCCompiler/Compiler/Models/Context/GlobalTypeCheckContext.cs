using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Context
{
    public class GlobalTypeCheckContext
    {
        public Scope? Scope { get; set; }
        public SemanticType? VariableAssignmentType { get; set; }
    }
}
