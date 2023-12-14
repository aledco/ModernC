using Compiler.ErrorHandling;
using Compiler.Models.Context;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Operators;

namespace Compiler.Models.Tree
{
    public class UnaryOperatorExpression : Expression
    {
        public UnaryOperator Operator { get; }
        public Expression Operand { get; }

        public UnaryOperatorExpression(Span span, UnaryOperator op, Expression operand) : base(span)
        {
            Operator = op;
            Operand = operand;
        }

        public override Expression Copy(Span span)
        {
            return new UnaryOperatorExpression(span, Operator, Operand);
        }

        public override SemanticType GlobalTypeCheck(GlobalTypeCheckContext context)
        {
            Type = Operand.GlobalTypeCheck(context);
            switch (Operator)
            {
                case UnaryOperator.Minus:
                    if (Type is not NumberType)
                    {
                        ErrorHandler.Throw("Operator is only valid for numeric types", this);
                    }

                    return Type;
                case UnaryOperator.Not:
                    if (Type is not BoolType)
                    {
                        ErrorHandler.Throw("Operator is only valid for boolean types", this);
                    }

                    return Type;
                case UnaryOperator.AddressOf:
                case UnaryOperator.Dereference:
                    ErrorHandler.Throw("Unary operator cannot be used globally", this);
                    throw ErrorHandler.FailedToExit;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
