using Compiler.Context;
using Compiler.ErrorHandling;
using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The function definition.
    /// </summary>
    public class FunctionDefinition : AbstractSyntaxTree
    {
        /// <summary>
        /// Gets the identifier of the function.
        /// </summary>
        public IdNode Id { get; }

        /// <summary>
        /// Gets the parameters of the function.
        /// </summary>
        public IList<Parameter> Parameters { get; }

        /// <summary>
        /// Gets the return type of the function.
        /// </summary>
        public TypeNode ReturnType { get; }

        /// <summary>
        /// Gets the body of the function.
        /// </summary>
        public CompoundStatement Body { get; }

        /// <summary>
        /// Gets or sets the scope of the function.
        /// </summary>
        public Scope? FunctionScope { get; set; }

        /// <summary>
        /// Gets or sets the size of the function.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Gets the register pool of the function.
        /// </summary>
        public List<string> RegisterPool { get; }

        /// <summary>
        /// Gets the enter label for this function.
        /// </summary>
        [JsonIgnore]
        public string EnterLabel { get => Id.Symbol!.Name; }

        /// <summary>
        /// Gets the return label for this function.
        /// </summary>
        [JsonIgnore]
        public string ReturnLabel { get => $"{Id.Symbol!.Name}_return"; }

        /// <summary>
        /// Initializes a new instance of a <see cref="FunctionDefinition"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="returnType">The return type.</param>
        /// <param name="body">The function body.</param>
        public FunctionDefinition(
            Span span,
            IdNode id,
            IList<Parameter> parameters,
            TypeNode returnType,
            CompoundStatement body) : base(span)
        {
            ReturnType = returnType;
            Id = id;
            Parameters = parameters;
            Body = body;
            RegisterPool = new List<string>();
        }

        public override SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context)
        {
            var outerScope = context.Scope;
            context.Scope = FunctionScope = new Scope(outerScope);
            var returnType = ReturnType.ToSemanticType();
            var parameterTypes = Parameters
                .Select(p => p.CheckGlobalSemantics(context))
                .ToList();
            ProcessParameterizedTypes(context, parameterTypes);
            var type = new FunctionType(returnType, parameterTypes);
            outerScope.AddSymbol(Id, type);
            context.Scope = outerScope;
            Id.CheckGlobalSemantics(context);
            Id.Symbol!.IsDefinedGlobalFunction = true;
            Id.Symbol!.EnclosingFunction = this;
            return SemanticType.NoType;
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            Debug.Assert(FunctionScope != null);

            var returnType = ReturnType.ToSemanticType();
            if (returnType is PointerType)
            {
                ErrorHandler.Throw("Pointers cannot be returned from functions", this);
            }
            else if (returnType.IsComplex)
            {
                ErrorHandler.Throw("Complex types cannot be returned from functions", this);
            }
            else if (returnType is not VoidType && !Body.AllPathsReturn())
            {
                ErrorHandler.Throw("Not all code paths return", this);
            }

            context.Scope = FunctionScope;
            context.EnclosingFunction = this;
            Body.CheckLocalSemantics(context);
            return SemanticType.NoType;
        }

        /// <summary>
        /// Processes parameterized types in the function parameters.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="parameterTypes">The parameter types.</param>
        private void ProcessParameterizedTypes(GlobalSemanticCheckContext context, List<SemanticType> parameterTypes)
        {
            var previousCount = parameterTypes.Count;
            for (int i = 0; i < previousCount; i++)
            {
                var type = parameterTypes[i];
                if (type is not PointerType) continue;

                var arrayParameter = Parameters[i];
                var arrayParameterType = arrayParameter.Type;
                var loop = true;
                while (loop)
                {
                    switch (type)
                    {
                        case PointerType pointerType when pointerType.BaseType is ArrayType arrayType && !arrayType.Length.HasValue
                                                       && arrayParameterType is PointerTypeNode pointerTypeNode
                                                       && pointerTypeNode.BaseType is ParameterizedArrayTypeNode arrayTypeNode:
                            var newParameter = new Parameter(Span, new IntTypeNode(Span), arrayTypeNode.Parameter);
                            Parameters.Add(newParameter);
                            parameterTypes.Add(newParameter.CheckGlobalSemantics(context));
                            type = arrayType;
                            arrayParameterType = arrayTypeNode;
                            break;
                        //case ArrayType outerArrayType when outerArrayType.ElementType is ArrayType arrayType && !arrayType.Length.HasValue
                        //                                && arrayParameterType is ParameterizedArrayTypeNode outerArrayTypeNode
                        //                                && outerArrayTypeNode.ElementType is ParameterizedArrayTypeNode arrayTypeNode:
                        //    CreateLengthParameter(functionDefinition, context, parameterTypes, arrayTypeNode);
                        //    type = arrayType;
                        //    arrayParameterType = arrayTypeNode;
                        //    break;
                        // TODO uncomment for multidimensional parmeterization
                        default:
                            loop = false;
                            break;
                    }
                }
            }
        }
    }
}
