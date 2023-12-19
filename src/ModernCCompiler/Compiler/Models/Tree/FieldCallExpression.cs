using Compiler.Context;
using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Operators;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The field call expression.
    /// </summary>
    public class FieldCallExpression : CallExpression
    {
        /// <summary>
        /// Gets the function expression.
        /// </summary>
        public FieldAccessExpression FieldFunction { get; }

        /// <summary>
        /// Initializes a new instance of a <see cref="FieldCallExpression"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="expression">The function expression.</param>
        /// <param name="args">The arguments.</param>
        public FieldCallExpression(Span span, FieldAccessExpression expression, IList<Expression> args) : base(span, expression, args)
        {
            FieldFunction = expression;
        }

        public override Expression Copy(Span span)
        {
            return new FieldCallExpression(Span, FieldFunction, Arguments);
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            var type = FieldFunction.CheckLocalSemantics(context);
            if (type is FunctionType functionType)
            {
                var argTypes = Arguments
                    .Select(a => a.CheckLocalSemantics(context))
                    .ToList();

                // insert data structure if applicable
                var firstParameterType = functionType.Parameters.First();
                var dataType = FieldFunction.Left.Type!;
                if (firstParameterType is PointerType parameterPointerType && parameterPointerType.UnderlyingType is UserDefinedType)
                {
                    if (!parameterPointerType.UnderlyingType.TypeEquals(dataType))
                    {
                        ErrorHandler.Throw("The first parameter of a field function call must be a pointer to the outer data structure", this);
                    }
                }
                else
                {
                    ErrorHandler.Throw("The first parameter of a field function call must be a pointer to the outer data structure", this);
                }

                // auto reference the data expression
                var dataExpression = FieldFunction.Left.Copy(Span);
                if (dataType is UserDefinedType)
                {
                    dataExpression = new UnaryOperatorExpression(Span, UnaryOperator.AddressOf, dataExpression);
                }
                else
                {
                    if (dataType is not PointerType)
                    {
                        throw new Exception("Data type was not user defined type or pointer type");
                    }

                    while (dataType is PointerType pointerType && pointerType.UnderlyingType is not UserDefinedType)
                    {
                        dataExpression = new UnaryOperatorExpression(Span, UnaryOperator.Dereference, dataExpression);
                        dataType = pointerType.UnderlyingType;
                    }
                }

                Arguments.Insert(0, dataExpression);
                argTypes.Insert(0, dataExpression.CheckLocalSemantics(context));
                ProcessParameterizedArguments(context, functionType, argTypes);
                if (argTypes.Count != functionType.Parameters.Count)
                {
                    ErrorHandler.Throw("Function was called with an incorrect number of arguments.", this);
                }

                for (var i = 0; i < argTypes.Count; i++)
                {
                    if (!argTypes[i].TypeEquals(functionType.Parameters[i]))
                    {
                        ErrorHandler.Throw($"Function was called with incorrect types.", this);
                    }
                }

                Type = functionType.ReturnType;
                return Type;
            }

            ErrorHandler.Throw($"Field cannot be called like a function.", this);
            throw ErrorHandler.FailedToExit;
        }
    }
}
