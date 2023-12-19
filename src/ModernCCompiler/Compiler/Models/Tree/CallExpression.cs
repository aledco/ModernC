using Compiler.Context;
using Compiler.ErrorHandling;
using Compiler.Models.NameResolution.Types;
using System.ComponentModel.DataAnnotations;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The call expression.
    /// </summary>
    public class CallExpression : TailedExpression
    {
        /// <summary>
        /// Gets the function expression.
        /// </summary>
        public Expression Function { get; }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        public IList<Expression> Arguments { get; }

        /// <summary>
        /// Gets or sets a value indicating whether to ignore the return value.
        /// </summary>
        public bool IgnoreReturn { get; set; } = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="CallExpression"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="function">The function expression.</param>
        /// <param name="args">The arguments.</param>
        public CallExpression(Span span, Expression function, IList<Expression> args) : base(span, function)
        {
            Function = function;
            Arguments = args;
        }

        public override Expression Copy(Span span)
        {
            return new CallExpression(span, Function, Arguments);
        }

        public override SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context)
        {
            return GlobalSemanticCheckContext.ExpressionNotValidGlobaly(this);
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            var type = Function.CheckLocalSemantics(context);
            if (type is FunctionType functionType)
            {
                var argTypes = Arguments
                    .Select(a => a.CheckLocalSemantics(context))
                    .ToList();
                ProcessParameterizedArguments(context, functionType, argTypes);
                if (argTypes.Count != functionType.Parameters.Count)
                {
                    ErrorHandler.Throw($"Function was called with an incorrect number of arguments.", this);
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

            ErrorHandler.Throw($"Expression cannot be called like a function.", this);
            throw ErrorHandler.FailedToExit;
        }

        /// <summary>
        /// Processes the parameterized arguments.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="functionType">The function types.</param>
        /// <param name="argTypes">The argument types.</param>
        protected void ProcessParameterizedArguments(LocalSemanticCheckContext context, FunctionType functionType, List<SemanticType> argTypes)
        {
            var previousCount = argTypes.Count;
            for (int i = 0; i < previousCount; i++)
            {
                var type = argTypes[i];
                if (type is not PointerType) continue;

                var parameterType = functionType.Parameters[i];
                var loop = true;
                while (loop)
                {
                    switch (type)
                    {
                        case PointerType pointerType when pointerType.BaseType is ArrayType arrayType
                                                       && parameterType is PointerType parameterPointerType
                                                       && parameterPointerType.BaseType is ArrayType parameterArrayType:
                            CheckArrayTypes(context, argTypes, arrayType, parameterArrayType);
                            type = arrayType;
                            parameterType = parameterArrayType;
                            break;
                        //case ArrayType outerArrayType when outerArrayType.ElementType is ArrayType arrayType
                        //                                && parameterType is ArrayType parameterOuterArrayType
                        //                                && parameterOuterArrayType.ElementType is ArrayType parameterArrayType:
                        //    CheckArrayTypes(e, context, argTypes, arrayType, parameterArrayType);
                        //    type = arrayType;
                        //    parameterType = parameterArrayType;
                        //    break;
                        // TODO uncomment for multidimensional parmeterization
                        default:
                            loop = false;
                            break;
                    }
                }
            }
        }
        
        /// <summary>
        /// Checks the array types.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="argTypes">The argument types.</param>
        /// <param name="arrayType">The array type.</param>
        /// <param name="parameterArrayType">The parameter array type.</param>
        private void CheckArrayTypes(LocalSemanticCheckContext context, List<SemanticType> argTypes, ArrayType arrayType, ArrayType parameterArrayType)
        {
            if (!arrayType.Length.HasValue && parameterArrayType.Length.HasValue)
            {
                ErrorHandler.Throw("Cannot pass a paramiterized array as an array with known size", this);
            }

            if (!parameterArrayType.Length.HasValue)
            {
                if (!arrayType.Length.HasValue && arrayType.LengthParameterName == null)
                {
                    ErrorHandler.Throw("Array length is not known", this);
                }

                else if (arrayType.Length.HasValue)
                {
                    var newArgument = new IntLiteralExpression(Span, arrayType.Length.Value);
                    Arguments.Add(newArgument!);
                    argTypes.Add(newArgument.CheckLocalSemantics(context));
                }
                else if (arrayType.LengthParameterName != null)
                {
                    var id = new IdNode(Span, arrayType.LengthParameterName);
                    arrayType.LengthParameterSymbol = context.Scope?.LookupSymbol(id);

                    var newArgument = new IdExpression(Span, id);
                    Arguments.Add(newArgument!);
                    argTypes.Add(newArgument.CheckLocalSemantics(context));
                }
            }
        }
    }
}
