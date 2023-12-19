using Compiler.Context;
using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Operators;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The unary operator expression.
    /// </summary>
    public class UnaryOperatorExpression : Expression
    {
        /// <summary>
        /// Gets the unary operator.
        /// </summary>
        public UnaryOperator Operator { get; }

        /// <summary>
        /// Gets the operand.
        /// </summary>
        public Expression Operand { get; }

        /// <summary>
        /// Instantiates a new instance of an <see cref="UnaryOperatorExpression"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="op">The operator.</param>
        /// <param name="operand">The operand.</param>
        public UnaryOperatorExpression(Span span, UnaryOperator op, Expression operand) : base(span)
        {
            Operator = op;
            Operand = operand;
        }

        public override Expression Copy(Span span)
        {
            return new UnaryOperatorExpression(span, Operator, Operand);
        }

        public override SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context)
        {
            var type = Operand.CheckGlobalSemantics(context);
            switch (Operator)
            {
                case UnaryOperator.Minus:
                    if (type is not NumberType)
                    {
                        ErrorHandler.Throw("Operator is only valid for numeric types", this);
                    }

                    return Type = type;
                case UnaryOperator.Not:
                    if (type is not BoolType)
                    {
                        ErrorHandler.Throw("Operator is only valid for boolean types", this);
                    }

                    return Type = type;
                case UnaryOperator.AddressOf:
                case UnaryOperator.Dereference:
                    ErrorHandler.Throw("Unary operator cannot be used globally", this);
                    throw ErrorHandler.FailedToExit;
                default:
                    throw new NotImplementedException();
            }
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            var type = Operand.CheckLocalSemantics(context);
            switch (Operator)
            {
                case UnaryOperator.Minus:
                    if (type is not NumberType)
                    {
                        ErrorHandler.Throw("Operator is only valid for numeric types", this);
                    }

                    return Type = type;
                case UnaryOperator.Not:
                    if (type is not BoolType)
                    {
                        ErrorHandler.Throw("Operator is only valid for boolean types", this);
                    }

                    return Type = type;
                case UnaryOperator.AddressOf:
                    if (type is FunctionType)
                    {
                        ErrorHandler.Throw("Cannot take the address of a function", this);
                    }

                    return Type = new PointerType(type);
                case UnaryOperator.Dereference:
                    if (type is PointerType pointerType)
                    {
                        return Type = pointerType.UnderlyingType;
                    }

                    ErrorHandler.Throw("Operator is only valid for pointer types");
                    throw ErrorHandler.FailedToExit;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
