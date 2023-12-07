using Compiler.ErrorHandling;
using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Operators;
using Compiler.Models.Tree;

namespace Compiler.TreeWalking.TypeCheck
{
    /// <summary>
    /// Performs type checking for code inside functions or data types.
    /// </summary>
    public static class LocalTypeChecker
    {
        private class Context
        {
            public Scope? Scope { get; set; }
            public FunctionDefinition? EnclosingFunction { get; set; }
            public Stack<LoopingStatement> EnclosingLoops { get; set; } = new();
            public bool LValue { get; set; } = false;
            public FunctionDefinition? RValueFunction { get; set; }

            public SemanticType? VariableAssignmentType { get; set; }
        }

        public static void Walk(ProgramRoot program)
        {
            var context = new Context
            {
                Scope = program.GlobalScope
            };
            VisitProgramRoot(program, context);
        }

        private static void VisitProgramRoot(ProgramRoot program, Context context)
        {
            foreach (var definition in program.Definitions)
            {
                VisitDefinition(definition, context);
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

        private static void VisitStructDefinition(StructDefinition structDefinition, Context context)
        {
            if (structDefinition.IsCircular())
            {
                ErrorHandler.Throw("Struct's cannot be circular, consider using a pointer instead", structDefinition);
            }

            foreach (var field in structDefinition.Fields)
            {
                context.VariableAssignmentType = field.Type.ToSemanticType();
                VisitStructFieldDefinition(field, context);
            }
        }

        private static void VisitStructFieldDefinition(StructFieldDefinition field, Context context)
        {
            var type = field.Type.ToSemanticType();
            if (field.DefaultExpression != null)
            {
                var expressionType = VisitExpression(field.DefaultExpression, context);
                if (!type.TypeEquals(expressionType))
                {
                    ErrorHandler.Throw("Defaul expression type must match", field);
                }
            }
        }

        private static void VisitFunctionDefinition(FunctionDefinition functionDefinition, Context context)
        {
            if (functionDefinition.FunctionScope == null)
            {
                throw new Exception("Function scope was null");
            }

            var returnType = functionDefinition.ReturnType.ToSemanticType();
            if (returnType is PointerType)
            {
                ErrorHandler.Throw("Pointers cannot be returned from functions", functionDefinition);
            }
            else if (returnType is not VoidType && !functionDefinition.Body.AllPathsReturn())
            {
                ErrorHandler.Throw("Not all code paths return", functionDefinition);
            }

            context.Scope = functionDefinition.FunctionScope;
            context.EnclosingFunction = functionDefinition;
            VisitCompoundStatement(functionDefinition.Body, context);
        }

        private static void VisitCompoundStatement(CompoundStatement body, Context context)
        {
            body.LocalScope = new Scope(context.Scope);
            foreach (var statement in body.Statements)
            {
                context.Scope = body.LocalScope;
                VisitStatement(statement, context);
            }
        }

        private static void VisitStatement(Statement statement, Context context)
        {
            switch (statement)
            {
                case PrintStatement s:
                    VisitPrintStatement(s, context);
                    break;
                case PrintLineStatement s:
                    VisitPrintLineStatement(s, context);
                    break;
                case VariableDefinitionStatement s:
                    VisitVariableDefinitionStatement(s, context);
                    break;
                case AssignmentStatement s:
                    VisitAssignmentStatement(s, context);
                    break;
                case IncrementStatement s:
                    VisitIncrementStatement(s, context);
                    break;
                case VariableDefinitionAndAssignmentStatement s:
                    VisitVariableDefinitionAndAssignmentStatement(s, context);
                    break;
                case CallStatement s:
                    VisitCallStatement(s, context);
                    break;
                case IfStatement s:
                    VisitIfStatement(s, context);
                    break;
                case WhileStatement s:
                    context.EnclosingLoops.Push(s);
                    VisitWhileStatement(s, context);
                    context.EnclosingLoops.Pop();
                    break;
                case DoWhileStatement s:
                    context.EnclosingLoops.Push(s);
                    VisitDoWhileStatement(s, context);
                    context.EnclosingLoops.Pop();
                    break;
                case ForStatement s:
                    context.EnclosingLoops.Push(s);
                    VisitForStatement(s, context);
                    context.EnclosingLoops.Pop();
                    break;
                case BreakStatement s:
                    VisitBreakStatement(s, context);
                    break;
                case ContinueStatement s:
                    VisitContinueStatement(s, context);
                    break;
                case ReturnStatement s:
                    VisitReturnStatement(s, context);
                    break;
                case ExitStatement s:
                    VisitExitStatement(s, context);
                    break;
                case CompoundStatement s:
                    VisitCompoundStatement(s, context);
                    break;
                default:
                    throw new NotImplementedException($"Unknown statement {statement}");
            }
        }

        private static void VisitPrintStatement(PrintStatement statement, Context context)
        {
            VisitExpression(statement.Expression, context);
        }

        private static void VisitPrintLineStatement(PrintLineStatement statement, Context context)
        {
            VisitPrintStatement(statement.PrintExpression, context);
            VisitPrintStatement(statement.PrintLine, context);
        }

        private static void VisitVariableDefinitionStatement(VariableDefinitionStatement statement, Context context)
        {
            var type = statement.Type.ToSemanticType();
            context.Scope?.AddSymbol(statement.Id, type);
            VisitIdNode(statement.Id, context);
        }

        private static void VisitAssignmentStatement(AssignmentStatement statement, Context context)
        {
            var rightType = VisitExpression(statement.Right, context);
            if (rightType.IsComplex)
            {
                ErrorHandler.Throw("Complex types cannot be reassigned.");
            }

            context.LValue = true;
            var leftType = VisitExpression(statement.Left, context);
            context.LValue = false;

            switch (leftType)
            {
                case RealType when rightType is NumberType:
                    break;
                case IntegralType when rightType is IntegralType:
                    break;
                default:
                    if (!leftType.TypeEquals(rightType))
                    {
                        ErrorHandler.Throw("Variable assignment must have matching types.", statement);
                    }

                    break;
            }
        }

        private static void VisitIncrementStatement(IncrementStatement s, Context context)
        {
            context.LValue = true;
            var leftType = VisitExpression(s.Left, context);
            context.LValue = false;

            if (leftType is not IntegralType)
            {
                ErrorHandler.Throw("Increment statements cannot be used on non integral types", s);
            }
        }

        private static void VisitVariableDefinitionAndAssignmentStatement(VariableDefinitionAndAssignmentStatement statement, Context context)
        {
            var type = statement.Type.ToSemanticType();
            context.VariableAssignmentType = type;
            var expressionType = VisitExpression(statement.Expression, context);
            if (expressionType.IsComplex && statement.Expression is not ComplexLiteralExpression)
            {
                ErrorHandler.Throw("Complex types cannot be reassigned.");
            }
            //else if (expressionType is PointerType pointerType && )

            switch (type)
            {
                case RealType when expressionType is NumberType:
                    break;
                case IntegralType when expressionType is IntegralType:
                    break;
                default:
                    if (!type.TypeEquals(expressionType))
                    {
                        ErrorHandler.Throw("Variable assignment must have matching types.", statement);
                    }

                    break;
            }

            context.Scope?.AddSymbol(statement.Id, type);
            context.LValue = true;
            VisitIdNode(statement.Id, context);
            context.LValue = false;
        }

        private static void VisitCallStatement(CallStatement s, Context context)
        {
            if (s.CallExpression is not CallExpression)
            {
                ErrorHandler.Throw("Expression is not a statement", s);
            }

            s.CallExpression.IgnoreReturn = true;
            VisitExpression(s.CallExpression, context);
        }

        private static void VisitIfStatement(IfStatement s, Context context)
        {
            var ifExpressionType = VisitExpression(s.IfExpression, context);
            if (ifExpressionType is not BoolType)
            {
                ErrorHandler.Throw("If expression must be of type boolean", s);
            }

            VisitCompoundStatement(s.IfBody, context);

            foreach (var e in s.ElifExpressions)
            {
                var elifExpressionType = VisitExpression(e, context);
                if (elifExpressionType is not BoolType)
                {
                    ErrorHandler.Throw("If expression must be of type boolean", s);
                }
            }

            foreach (var b in s.ElifBodies) 
            {
                VisitCompoundStatement(b, context);
            }
            
            if (s.ElseBody != null)
            {
                VisitCompoundStatement(s.ElseBody, context);
            }
        }

        private static void VisitWhileStatement(WhileStatement s, Context context)
        {
            var expressionType = VisitExpression(s.Expression, context);
            if (expressionType is not BoolType)
            {
                ErrorHandler.Throw("While loop expression must be of type boolean", s);
            }

            VisitCompoundStatement(s.Body, context);
        }

        private static void VisitDoWhileStatement(DoWhileStatement s, Context context)
        {
            VisitCompoundStatement(s.Body, context);
            var expressionType = VisitExpression(s.Expression, context);
            if (expressionType is not BoolType)
            {
                ErrorHandler.Throw("Do while loop expression must be of type boolean", s);
            }
        }

        private static void VisitForStatement(ForStatement s, Context context)
        {
            s.Scope = new Scope(context.Scope);
            context.Scope = s.Scope;
            VisitStatement(s.InitialStatement, context);
            var expressionType = VisitExpression(s.Expression, context);
            if (expressionType is not BoolType)
            {
                ErrorHandler.Throw("For loop expression must be of type boolean", s);
            }

            VisitStatement(s.UpdateStatement, context);
            VisitCompoundStatement(s.Body, context);
        }

        private static void VisitBreakStatement(BreakStatement s, Context context)
        {
            if (context.EnclosingLoops.TryPeek(out var loop))
            {
                s.EnclosingLoop = loop;
            }
            else
            {
                ErrorHandler.Throw("Break statements can only be used inside a loop", s);
            }
        }

        private static void VisitContinueStatement(ContinueStatement s, Context context)
        {
            if (context.EnclosingLoops.TryPeek(out var loop))
            {
                s.EnclosingLoop = loop;
            }
            else
            {
                ErrorHandler.Throw("Continue statements can only be used inside a loop", s);
            }
        }

        private static void VisitReturnStatement(ReturnStatement statement, Context context)
        {
            if (context.EnclosingFunction?.Id?.Symbol?.Type is FunctionType functionType)
            {
                if (functionType.ReturnType is ArrayType)
                {
                    ErrorHandler.Throw("The compilier does not currently support returning arrays from functions", statement); // TODO remove once copy is implemented 
                }

                if (functionType.ReturnType is VoidType && statement.Expression != null)
                {
                    ErrorHandler.Throw("Function has a return type of void and cannot return a value.", statement);
                }
                else if (functionType.ReturnType is not VoidType && statement.Expression == null)
                {
                    ErrorHandler.Throw("Function cannot have an empty return.", statement);
                }

                if (statement.Expression != null)
                {
                    var expressionType = VisitExpression(statement.Expression, context);
                    if (functionType.ReturnType is not VoidType && !expressionType.TypeEquals(functionType.ReturnType))
                    {
                        ErrorHandler.Throw("Function return type does not match return value.", statement);
                    }
                }

                statement.EnclosingFunction = context.EnclosingFunction;

            }
            else
            {
                throw new Exception("Enclosing function is null");
            }
        }

        private static void VisitExitStatement(ExitStatement s, Context context)
        {
            var type = VisitExpression(s.Expression, context);
            if (type is not IntegralType)
            {
                ErrorHandler.Throw("Exit code must be an integer", s);
            }
        }

        private static SemanticType VisitExpression(Expression expression, Context context)
        {
            expression.Type = expression switch
            {
                BinaryOperatorExpression e => VisitBinaryOperatorExpression(e, context),
                CallExpression e => VisitCallExpression(e, context),
                StructLiteralExpression e => VisitStructLiteralExpression(e, context),
                ArrayIndexExpression e => VisitArrayIndexExpression(e, context),
                FieldAccessExpression e => VisitFieldAccessExpression(e, context),
                ReadExpression => new ByteType(),
                UnaryOperatorExpression e => VisitUnaryOperatorExpression(e, context),
                IdExpression e => VisitIdExpression(e, context),
                ArrayLiteralExpression e => VisitArrayLiteralExpression(e, context),
                IntLiteralExpression => new IntType(),
                ByteLiteralExpression => new ByteType(),
                FloatLiteralExpression => new FloatType(),
                BoolLiteralExpression => new BoolType(),
                _ => throw new NotImplementedException($"Unknown expression: {expression}"),
            };

            if (expression.Type is VoidType && expression is not CallExpression)
            {
                ErrorHandler.Throw("Expressions can not have a type of void.", expression);
            }

            return expression.Type; 
        }

        private static SemanticType VisitFieldAccessExpression(FieldAccessExpression e, Context context)
        {
            var type = VisitExpression(e.Left, context);
            if (type is UserDefinedType userDefinedType)
            {
                type = SymbolTable.LookupType(userDefinedType, e.Span);
            }

            switch (type)
            {
                case StructType t:
                    var fieldType = t.FieldTypes.Where(t => t.Value == e.Id.Value).Select(t => t.Type).FirstOrDefault();
                    if (fieldType == null)
                    {
                        ErrorHandler.Throw("Field does not exist", e);
                        throw new Exception("ErrorHandler failed to exit application");
                    }

                    return fieldType;
                case PointerType p when p.ConcreteType is StructType t:
                    e.AutoDereference();
                    return VisitExpression(e, context);
                default:
                    ErrorHandler.Throw("Field access expression is not valid for this type", e);
                    throw new Exception("ErrorHandler failed to exit application");
            }
        }

        private static SemanticType VisitStructLiteralExpression(StructLiteralExpression e, Context context)
        {
            if (context.VariableAssignmentType is UserDefinedType userDefinedType)
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

                return structType;
            }
            
            ErrorHandler.Throw("Struct literal cannot be assigned to this type", e);
            throw ErrorHandler.FailedToExit;
        }

        private static SemanticType VisitCallExpression(CallExpression e, Context context)
        {
            e.Type = VisitExpression(e.Function, context);
            if (e.Type is FunctionType functionType)
            {
                var argTypes = e.Arguments
                    .Select(a => VisitExpression(a, context))
                    .ToList();
                if (argTypes.Count != functionType.Parameters.Count)
                {
                    ErrorHandler.Throw($"Function was called with an incorrect number of arguments.", e);
                }

                for (var i = 0; i < argTypes.Count; i++)
                {
                    if (!argTypes[i].TypeEquals(functionType.Parameters[i]))
                    {
                        ErrorHandler.Throw($"Function was called with incorrect types.", e);
                    }
                }

                return functionType.ReturnType;
            }

            ErrorHandler.Throw($"Expression cannot be called like a function.", e);
            throw new Exception("Error handler did not stop execution");
        }
        private static SemanticType VisitArrayIndexExpression(ArrayIndexExpression e, Context context)
        {
            e.Type = VisitExpression(e.Array, context);
            if (e.Type is ArrayType arrayType)
            {
                var indexType = VisitExpression(e.Index, context);
                if (indexType is not IntegralType)
                {
                    ErrorHandler.Throw("Index expression must be an integer type", e);
                }

                return arrayType.ElementType;
            }

            ErrorHandler.Throw("Expression cannot be indexed like an array", e);
            throw new Exception("Error handler did not stop execution");
        }

        private static SemanticType VisitBinaryOperatorExpression(BinaryOperatorExpression e, Context context)
        {
            var leftType = VisitExpression(e.LeftOperand, context);
            var rightType = VisitExpression(e.RightOperand, context);

            bool NumericTypesMatch(SemanticType t1, SemanticType t2)
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

            bool PointerTypesMatch(SemanticType t1, SemanticType t2)
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

            switch (e.Operator)
            {
                case BinaryOperator.EqualTo:
                case BinaryOperator.NotEqualTo:
                case BinaryOperator.LessThan:
                case BinaryOperator.LessThanEqualTo:
                case BinaryOperator.GreaterThan:
                case BinaryOperator.GreaterThanEqualTo:
                    if (!NumericTypesMatch(leftType, rightType))
                    {
                        ErrorHandler.Throw("Operator is only valid for numeric types.", e);
                    }

                    e.Type = new BoolType();
                    break;
                case BinaryOperator.Plus:
                case BinaryOperator.Minus:
                    if (!NumericTypesMatch(leftType, rightType) && !PointerTypesMatch(leftType, rightType))
                    {
                        ErrorHandler.Throw("Operands do not have valid types.", e);
                    }

                    e.Type = leftType;
                    break;
                case BinaryOperator.Times:
                case BinaryOperator.DividedBy:
                case BinaryOperator.Modulo:
                    if (!NumericTypesMatch(leftType, rightType))
                    {
                        ErrorHandler.Throw("Operator is only valid for numeric types.", e);
                    }

                    e.Type = leftType;
                    break;
                case BinaryOperator.And:
                case BinaryOperator.Or:
                    if (leftType is not BoolType || rightType is not BoolType)
                    {
                        ErrorHandler.Throw("Operator is only valid for boolean types", e);
                    }

                    e.Type = leftType;
                    break;
                default:
                    throw new NotImplementedException();
            }

            return e.Type;
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
                    if (e.Type is FunctionType)
                    {
                        ErrorHandler.Throw("Cannot take the address of a function", e);
                    }

                    return new PointerType(e.Type);
                case UnaryOperator.Dereference:
                    if (e.Type is PointerType pointerType)
                    {
                        return pointerType.UnderlyingType;
                    }

                    ErrorHandler.Throw("Operator is only valid for pointer types");
                    throw ErrorHandler.FailedToExit;
                default:
                    throw new NotImplementedException();
            }
        }

        private static SemanticType VisitIdExpression(IdExpression e, Context context)
        {
            e.Type = VisitIdNode(e.Id, context);
            return e.Type;
        }

        private static SemanticType VisitArrayLiteralExpression(ArrayLiteralExpression e, Context context)
        {
            var elementTypes = e.Elements
                .Select(e => VisitExpression(e, context))
                .ToList();

            if (!elementTypes.TrueForAll(e => e.TypeEquals(elementTypes.First())))
            {
                ErrorHandler.Throw("Array literal elements must all be the same type", e);
            }

            e.Type = new ArrayType(elementTypes.First(), elementTypes.Count);
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
