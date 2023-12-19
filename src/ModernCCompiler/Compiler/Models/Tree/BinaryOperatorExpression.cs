using Compiler.Context;
using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Operators;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The binary operator expression.
    /// </summary>
    public class BinaryOperatorExpression : Expression
    {
        /// <summary>
        /// Gets the left operand.
        /// </summary>
        public Expression LeftOperand { get; }

        /// <summary>
        /// Gets the binary operator.
        /// </summary>
        public BinaryOperator Operator { get; }

        /// <summary>
        /// Gets the right operand.
        /// </summary>
        public Expression RightOperand { get; }

        /// <summary>
        /// Initializes a new instance of a <see cref="BinaryOperatorExpression"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="op">The operator.</param>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        public BinaryOperatorExpression(Span span, BinaryOperator op, Expression left, Expression right) : base(span)
        {
            Operator = op;
            LeftOperand = left;
            RightOperand = right;
        }

        public override Expression Copy(Span span)
        {
            return new BinaryOperatorExpression(span, Operator, LeftOperand, RightOperand);
        }

        public override SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context)
        {
            return GlobalSemanticCheckContext.ExpressionNotValidGlobaly(this);
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            var leftType = LeftOperand.CheckLocalSemantics(context);
            var rightType = RightOperand.CheckLocalSemantics(context);
            switch (Operator)
            {
                case BinaryOperator.EqualTo:
                case BinaryOperator.NotEqualTo:
                    if (!leftType.TypeEquals(rightType))
                    {
                        ErrorHandler.Throw("Binary operand types must match", this);
                    }

                    Type = new BoolType();
                    break;
                case BinaryOperator.LessThan:
                case BinaryOperator.LessThanEqualTo:
                case BinaryOperator.GreaterThan:
                case BinaryOperator.GreaterThanEqualTo:
                    if (!NumericTypesMatch(leftType, rightType))
                    {
                        ErrorHandler.Throw("Operator is only valid for numeric types.", this);
                    }

                    Type = new BoolType();
                    break;
                case BinaryOperator.Plus:
                case BinaryOperator.Minus:
                    if (!NumericTypesMatch(leftType, rightType) && !PointerTypesMatch())
                    {
                        ErrorHandler.Throw("Operands do not have valid types.", this);
                    }

                    Type = leftType;
                    break;
                case BinaryOperator.Times:
                case BinaryOperator.DividedBy:
                case BinaryOperator.Modulo:
                    if (!NumericTypesMatch(leftType, rightType))
                    {
                        ErrorHandler.Throw("Operator is only valid for numeric types.", this);
                    }

                    Type = leftType;
                    break;
                case BinaryOperator.And:
                case BinaryOperator.Or:
                    if (leftType is not BoolType || rightType is not BoolType)
                    {
                        ErrorHandler.Throw("Operator is only valid for boolean types", this);
                    }

                    Type = leftType;
                    break;
                default:
                    throw new NotImplementedException();
            }

            return Type!;
        }

        /// <summary>
        /// Checks if two numeric types match.
        /// </summary>
        /// <param name="t1">The first type.</param>
        /// <param name="t2">The second type.</param>
        /// <returns>True if they match.</returns>
        private static bool NumericTypesMatch(SemanticType t1, SemanticType t2)
        {
            if (t1 is IntegralType && t2 is IntegralType)
            {
                return true;
            }
            else if (t1 is RealType && t2 is RealType)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if two pointer types match.
        /// </summary>
        /// <returns>True if they match.</returns>
        static bool PointerTypesMatch()
        {
            //if (t1 is PointerType && t2 is IntegralType) 
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return false; // TODO allow pointer math?
        }
    }
}
