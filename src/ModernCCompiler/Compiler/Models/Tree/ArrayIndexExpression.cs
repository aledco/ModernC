using Compiler.ErrorHandling;
using Compiler.Models.Context;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Operators;

namespace Compiler.Models.Tree
{
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

        public override SemanticType GlobalTypeCheck(GlobalTypeCheckContext context)
        {
            ErrorHandler.Throw("Expression cannot be made globally", this);
            throw ErrorHandler.FailedToExit;
        }
    }
}
