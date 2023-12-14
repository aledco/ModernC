using Compiler.ErrorHandling;
using Compiler.Models.Context;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    public class ArrayLiteralExpression : ComplexLiteralExpression
    {
        /// <summary>
        /// Gets the array literal elements.
        /// </summary>
        public IList<ArrayLiteralElement> Elements { get; }

        /// <summary>
        /// Gets or sets the offset used for code generation.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Initializes a new instance of an <see cref="ArrayLiteralExpression"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="elements">The array literal elements.</param>
        public ArrayLiteralExpression(Span span, IList<ArrayLiteralElement> elements) : base(span)
        {
            Elements = elements;
        }

        public override Expression Copy(Span span)
        {
            return new ArrayLiteralExpression(span, Elements);
        }

        public override SemanticType GlobalTypeCheck(GlobalTypeCheckContext context)
        {
            var elementTypes = Elements
                .Select(e => e.GlobalTypeCheck(context))
                .ToList();

            if (!elementTypes.TrueForAll(e => e.TypeEquals(elementTypes.First())))
            {
                ErrorHandler.Throw("Array literal elements must all be the same type", this);
            }

            Type = new ArrayType(elementTypes.First(), elementTypes.Count);
            return Type;
        }
    }
}
