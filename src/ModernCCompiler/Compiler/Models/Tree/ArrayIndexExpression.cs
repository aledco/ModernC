using Compiler.Context;
using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Operators;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The array index expression.
    /// </summary>
    public class ArrayIndexExpression : TailedExpression
    {
        /// <summary>
        /// Gets or sets the array expression.
        /// </summary>
        public Expression Array { get; private set; }

        /// <summary>
        /// Gets the index expression.
        /// </summary>
        public Expression Index { get; }

        /// <summary>
        /// Initializes a new instance of an <see cref="ArrayIndexExpression"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="array">The array expression.</param>
        /// <param name="index">The index expression.</param>
        public ArrayIndexExpression(Span span, Expression array, Expression index) : base(span, array)
        {
            Array = array;
            Index = index;
        }

        /// <summary>
        /// Auto dereferences the array expression.
        /// </summary>
        public void AutoDereference()
        {
            // add dereference expressions until the concrete type is recovered. for auto dereferencing.
            for (var type = Left.Type; type is PointerType pointerType; type = pointerType.UnderlyingType)
            {
                Left = new UnaryOperatorExpression(Span, UnaryOperator.Dereference, Left);
            }

            Array = Left;
        }

        public override Expression Copy(Span span)
        {
            return new ArrayIndexExpression(span, Array, Index);
        }

        public override SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context)
        {
            return GlobalSemanticCheckContext.ExpressionNotValidGlobaly(this);
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            var type = Array.CheckLocalSemantics(context);
            switch (type)
            {
                case ArrayType t:
                    if (t.Length == null && t.LengthParameterName == null)
                    {
                        ErrorHandler.Throw("Length of array is unkown", this);
                    }
                    else if (t.LengthParameterName != null && t.LengthParameterSymbol == null)
                    {
                        t.LengthParameterSymbol = context.Scope?.LookupSymbol(t.LengthParameterName, Span);
                    }

                    var indexType = Index.CheckLocalSemantics(context);
                    if (indexType is not IntegralType)
                    {
                        ErrorHandler.Throw("Index expression must be an integer type", this);
                    }
                    
                    return Type = t.ElementType;
                case PointerType p when p.BaseType is ArrayType:
                    AutoDereference();
                    return CheckLocalSemantics(context);
                default:
                    ErrorHandler.Throw("Expression cannot be indexed like an array", this);
                    throw new Exception("Error handler did not stop execution");
            }
        }
    }
}
