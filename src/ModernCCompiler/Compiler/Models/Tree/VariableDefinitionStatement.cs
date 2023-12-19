using Compiler.Context;
using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The variable definition statement.
    /// </summary>
    public class VariableDefinitionStatement : Statement
    {
        /// <summary>
        /// Gets the type.
        /// </summary>
        public TypeNode Type { get; }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public IdNode Id { get; }

        /// <summary>
        /// Instantiates a new instance of a <see cref="VariableDefinitionStatement"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="type">The type.</param>
        /// <param name="id">The identifier.</param>
        public VariableDefinitionStatement(Span span, TypeNode type, IdNode id) : base(span)
        {
            Type = type;
            Id = id;
        }

        public override bool AllPathsReturn()
        {
            return false;
        }

        public override SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context)
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

            context.Scope.AddSymbol(Id, type);
            Id.CheckGlobalSemantics(context);

            return type;
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            var type = Type.ToSemanticType();
            if (type is ArrayType arrayType && !arrayType.Length.HasValue)
            {
                ErrorHandler.Throw("Arrays must be declared with a size", this);
            }

            context.Scope.AddSymbol(Id, type);
            Id.CheckLocalSemantics(context);
            return SemanticType.NoType;
        }
    }
}
