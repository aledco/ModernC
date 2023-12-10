using Compiler.ErrorHandling;
using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Operators;
using Compiler.Models.Tree;

namespace Compiler.TreeWalking.TypeCheck
{
    /// <summary>
    /// Does the first pass of name resolution, filling the global and function scopes.
    /// This allows functions and statements to be defined in any order but still be visable.
    /// </summary>
    public static class GlobalTypeChecker
    {
        private class Context
        {
            public Scope? Scope { get; set; }
            public SemanticType? VariableAssignmentType { get; set; }
        }

        public static void Walk(ProgramRoot program)
        {
            var context = new Context
            {
                Scope = SymbolTable.GlobalScope
            };

            VisitProgramRoot(program, context);
        }

        private static void VisitProgramRoot(ProgramRoot program, Context context)
        {
            program.GlobalScope = context.Scope;
            foreach (var definition in program.Definitions)
            {
                VisitDefinition(definition, context);
            }

            foreach (var statement in program.GlobalStatements)
            {
                VisitStatement(statement, context);
            }

            foreach (var functionDefinition in program.FunctionDefinitions)
            {
                VisitFunctionDefinition(functionDefinition, context);
            }
        }

        private static void VisitDefinition(Definition definition, Context context)
        {
            switch (definition) 
            {
                case StructDefinition d:
                    VisitStructDefinition(d, context);
                    break;
                default:
                    throw new NotImplementedException();
            }      
        }

        private static void VisitStatement(Statement statement, Context context)
        {
            SemanticType type;
            switch (statement)
            {
                case VariableDefinitionStatement s:
                    type = s.Type.ToSemanticType();
                    if (type.IsFunctionParameterOnly)
                    {
                        ErrorHandler.Throw("Type can only be used in function parameters");
                    }
                    else if (type is PointerType)
                    {
                        ErrorHandler.Throw("Pointers cannot be global", statement);
                    }

                    context.Scope?.AddSymbol(s.Id, type);
                    VisitIdNode(s.Id, context);
                    break;
                case VariableDefinitionAndAssignmentStatement s:
                    type = s.Type.ToSemanticType();
                    if (type.IsFunctionParameterOnly)
                    {
                        ErrorHandler.Throw("Type can only be used in function parameters");
                    }
                    else if (type is PointerType)
                    {
                        ErrorHandler.Throw("Pointers cannot be global", statement);
                    }

                    context.Scope?.AddSymbol(s.Id, type);
                    context.VariableAssignmentType = type;
                    VisitIdNode(s.Id, context);
                    var expressionType = VisitExpression(s.Expression, context);
                    if (!type.TypeEquals(expressionType))
                    {
                        ErrorHandler.Throw("Expression must be a matching type", s);
                    }

                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private static void VisitStructDefinition(StructDefinition structDefinition, Context _)
        {
            SymbolTable.AddType(structDefinition.Type, structDefinition);
        }

        private static void VisitFunctionDefinition(FunctionDefinition functionDefinition, Context context)
        {
            var globalScope = context.Scope;

            functionDefinition.FunctionScope = new Scope(context.Scope);
            context.Scope = functionDefinition.FunctionScope;

            var returnType = functionDefinition.ReturnType.ToSemanticType();
            var parameterTypes = functionDefinition.Parameters
                .Select(p => VisitParameter(p, context))
                .ToList();

            ProcessParameterizedParameters(functionDefinition, context, parameterTypes);

            globalScope?.AddSymbol(functionDefinition.Id, new FunctionType(returnType, parameterTypes));
            context.Scope = globalScope;
            VisitIdNode(functionDefinition.Id, context);
            if (functionDefinition.Id.Symbol == null)
            {
                throw new Exception("Symbol was null");
            }

            functionDefinition.Id.Symbol.IsDefinedGlobalFunction = true;
            functionDefinition.Id.Symbol.EnclosingFunction = functionDefinition;
        }

        private static void ProcessParameterizedParameters(FunctionDefinition functionDefinition, Context context, List<SemanticType> parameterTypes)
        {
            var previousCount = parameterTypes.Count;
            for (int i = 0; i < previousCount; i++)
            {
                var type = parameterTypes[i];
                if (type is not PointerType) continue;

                var arrayParameter = functionDefinition.Parameters[i];
                var arrayParameterType = arrayParameter.Type;
                var loop = true;
                while (loop)
                {
                    switch (type)
                    {

                        case PointerType pointerType when pointerType.BaseType is ArrayType arrayType && !arrayType.Length.HasValue
                                                       && arrayParameterType is PointerTypeNode pointerTypeNode
                                                       && pointerTypeNode.BaseType is ParameterizedArrayTypeNode arrayTypeNode:
                            CreateLengthParameter(functionDefinition, context, parameterTypes, arrayTypeNode);
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

            static void CreateLengthParameter(FunctionDefinition functionDefinition, Context context, List<SemanticType> parameterTypes, ParameterizedArrayTypeNode innerArrayTypeNode)
            {
                var newParameter = new Parameter(functionDefinition.Span, new IntTypeNode(functionDefinition.Span), innerArrayTypeNode.Parameter);
                functionDefinition.Parameters.Add(newParameter);
                parameterTypes.Add(VisitParameter(newParameter, context));
            }
        }

        private static SemanticType VisitParameter(Parameter parameter, Context context)
        {
            var type = parameter.Type.ToSemanticType();
            context.Scope?.AddSymbol(parameter.Id, type);
            VisitIdNode(parameter.Id, context);
            return type;
        }

        private static SemanticType VisitExpression(Expression expression, Context context)
        {
            switch (expression)
            {
                case UnaryOperatorExpression e:
                    expression.Type = VisitUnaryOperatorExpression(e, context);
                    break;
                case StructLiteralExpression e:
                    expression.Type = VisitStructLiteralExpression(e, context);
                    break;
                case ArrayLiteralExpression e:
                    expression.Type = VisitArrayLiteralExpression(e, context);
                    break;
                case IdExpression e:
                    expression.Type = VisitIdExpression(e, context);
                    break;
                case IntLiteralExpression:
                    expression.Type = new IntType();
                    break;
                case ByteLiteralExpression:
                    expression.Type = new ByteType();
                    break;
                case FloatLiteralExpression:
                    expression.Type = new FloatType();
                    break;
                case BoolLiteralExpression:
                    expression.Type = new BoolType();
                    break;
                default:
                    ErrorHandler.Throw("Expression cannot be made global", expression);
                    break;
            }

            if (expression.Type == null) 
            {
                throw new Exception("Type was null");
            }

            if (expression.Type is VoidType)
            {
                ErrorHandler.Throw("Expressions can not have a type of void.", expression);
            }

            return expression.Type;
        }

        private static SemanticType VisitUnaryOperatorExpression(UnaryOperatorExpression e, Context context)
        {
            e.Type = VisitExpression(e.Operand, context);
            switch (e.Operator)
            {
                case UnaryOperator.Minus:
                    if (e.Type is not NumberType)
                    {
                        ErrorHandler.Throw("Operator is only valid for numeric types", e);
                    }

                    return e.Type;
                case UnaryOperator.Not:
                    if (e.Type is not BoolType)
                    {
                        ErrorHandler.Throw("Operator is only valid for boolean types", e);
                    }

                    return e.Type;
                case UnaryOperator.AddressOf:
                case UnaryOperator.Dereference:
                    ErrorHandler.Throw("Unary operator cannot be used globally", e);
                    throw ErrorHandler.FailedToExit;
                default:
                    throw new NotImplementedException();
            }
        }

        private static SemanticType VisitStructLiteralExpression(StructLiteralExpression e, Context context)
        {
            var variableAssignmentType = context.VariableAssignmentType;
            if (variableAssignmentType?.BaseType is UserDefinedType userDefinedType)
            {
                var (structType, definition) = SymbolTable.LookupTypeAndDefinition<StructType, StructDefinition>(userDefinedType, e.Span);
                e.MapDefaultExpressionsFromDefinition(structType, definition);
                foreach (var field in e.Fields)
                {
                    var fieldDefinition = definition.Fields.Where(f => field.Id.Value == f.Id.Value).FirstOrDefault();
                    if (fieldDefinition == null)
                    {
                        ErrorHandler.Throw("Struct does not have a definition for this field", e);
                    }

                    var fieldDefinitionType = fieldDefinition!.Type.ToSemanticType();

                    context.VariableAssignmentType = fieldDefinitionType;
                    var type = VisitExpression(field.Expression, context);
                    if (!fieldDefinition!.Type.ToSemanticType().TypeEquals(type))
                    {
                        ErrorHandler.Throw("Type does not match field definition", e);
                    }
                }

                context.VariableAssignmentType = variableAssignmentType;
                return structType;
            }

            ErrorHandler.Throw("Struct literal cannot be assigned to this type", e);
            throw ErrorHandler.FailedToExit;
        }

        private static SemanticType VisitArrayLiteralExpression(ArrayLiteralExpression e, Context context)
        {
            var elementTypes = e.Elements
                .Select(e => VisitExpression(e.Expression, context))
                .ToList();

            if (!elementTypes.TrueForAll(e => e.TypeEquals(elementTypes.First())))
            {
                ErrorHandler.Throw("Array literal elements must all be the same type", e);
            }

            e.Type = new ArrayType(elementTypes.First(), elementTypes.Count);
            return e.Type;
        }

        private static SemanticType? VisitIdExpression(IdExpression e, Context context)
        {
            e.Type = VisitIdNode(e.Id, context);
            return e.Type;
        }

        private static SemanticType VisitIdNode(IdNode id, Context context)
        {
            id.Symbol = context.Scope?.LookupSymbol(id);
            if (id.Symbol == null)
            {
                throw new Exception("Symbol was null");
            }

            return id.Symbol.Type;
        }
    }
}
