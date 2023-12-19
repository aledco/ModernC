using Compiler.Context;
using Compiler.ErrorHandling;
using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Operators;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The field access expression.
    /// </summary>
    public class FieldAccessExpression : TailedExpression
    {
        /// <summary>
        /// Gets the identifier of the field.
        /// </summary>
        public IdNode Id { get; }

        /// <summary>
        /// Gets or sets the offset used for code generation.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Initializes a new instance of a <see cref="FieldAccessExpression"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="left">The left hand side of the expression.</param>
        /// <param name="id">The identifier.</param>
        public FieldAccessExpression(Span span, Expression left, IdNode id) : base(span, left)
        {
            Id = id;
        }

        /// <summary>
        /// Auto dereferences the left hand side of the expression.
        /// </summary>
        public void AutoDereference() // TODO make this a method on expression that returns a new dereferenced expression.
        {
            for (var type = Left.Type; type is PointerType pointerType; type = pointerType.UnderlyingType)
            {
                Left = new UnaryOperatorExpression(Span, UnaryOperator.Dereference, Left);
            }
        }

        public override Expression Copy(Span span)
        {
            return new FieldAccessExpression(span, Left, Id);
        }

        public override SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context)
        {
            return GlobalSemanticCheckContext.ExpressionNotValidGlobaly(this);
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            var type = Left.CheckLocalSemantics(context);
            if (type is UserDefinedType userDefinedType)
            {
                type = SymbolTable.LookupType(userDefinedType, Span);
            }

            switch (type)
            {
                case StructType t:
                    Type = t.FieldTypes.Where(t => t.Value == Id.Value).Select(t => t.Type).FirstOrDefault();
                    if (Type == null)
                    {
                        ErrorHandler.Throw("Field does not exist", this);
                    }

                    return Type!;
                case PointerType p when p.BaseType is StructType:
                    AutoDereference();
                    return CheckLocalSemantics(context);
                default:
                    ErrorHandler.Throw("Field access expression is not valid for this type", this);
                    throw ErrorHandler.FailedToExit;
            }
        }
    }
}
