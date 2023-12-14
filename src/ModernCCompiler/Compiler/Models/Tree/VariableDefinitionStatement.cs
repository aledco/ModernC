using Compiler.ErrorHandling;
using Compiler.Models.Context;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    public class VariableDefinitionStatement : Statement
    {
        public TypeNode Type { get; }
        public IdNode Id { get; }

        public VariableDefinitionStatement(Span span, TypeNode type, IdNode id) : base(span)
        {
            Type = type;
            Id = id;
        }

        public override bool AllPathsReturn()
        {
            return false;
        }

        public override SemanticType GlobalTypeCheck(GlobalTypeCheckContext context)
        {
            var type = Type.ToSemanticType();
            if (type.IsParameterized)
            {
                ErrorHandler.Throw("Type can only be used in function parameters");
            }
            else if (type is PointerType)
            {
                ErrorHandler.Throw("Pointers cannot be global", this);
            }
            else if (type is ArrayType arrayType && !arrayType.Length.HasValue)
            {
                ErrorHandler.Throw("Arrays must be declared with a size", this);
            }

            context.Scope!.AddSymbol(Id, type);
            Id.GlobalTypeCheck(context);

            return type;
        }
    }
}
