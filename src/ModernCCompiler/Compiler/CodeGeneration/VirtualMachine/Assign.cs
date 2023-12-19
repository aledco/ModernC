using Compiler.Context.VirtualMachine;
using Compiler.ErrorHandling;
using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;
using Compiler.Models.Tree;
using System.Diagnostics;

namespace Compiler.CodeGeneration.VirtualMachine
{
    /// <summary>
    /// Assigns registers and offsets to nodes in preperation for code generation.
    /// </summary>
    public static class Assign
    {
        public static void Walk(ProgramRoot program)
        {
            VisitProgramRoot(program);
        }

        private static void VisitProgramRoot(ProgramRoot program)
        {
            var context = new AssignContext();
            foreach (var definition in program.Definitions)
            {
                VisitDefinition(definition, context);
            }
            foreach (var statement in program.GlobalStatements)
            {
                VisitStatement(statement, context, 0);
            }

            foreach (var function in program.FunctionDefinitions)
            {
                VisitFunctionDefinition(function);
            }
        }

        private static void VisitDefinition(Definition definition, AssignContext context)
        {
            switch (definition)
            {
                case StructDefinition d:
                    VisitStructDefinition(d, context);
                    break;
                case AliasDefinition:
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private static void VisitStructDefinition(StructDefinition structDefinition, AssignContext context)
        {
            var offset = 0;
            foreach (var field in structDefinition.Fields)
            {
                field.Offset = offset;
                if (field.DefaultExpression != null)
                {
                    VisitExpression(field.DefaultExpression, context, offset);
                    context.DropRegister(field.DefaultExpression.Register);
                }

                offset += field.Type.ToSemanticType().GetSizeInWords();
            }
        }

        private static void VisitFunctionDefinition(FunctionDefinition function)
        {
            var context = new AssignContext();
            int offset = -2; // to allow space for return value
            foreach (var parameter in function.Parameters)
            {
                VisitParameter(parameter, context, offset);
                offset--;
            }

            offset = 3; // to allow space for frame/stack pointer and return address
            function.Size = VisitCompoundStatement(function.Body, context, offset);
            function.RegisterPool.AddRange(context.GetRegisterPool());
        }

        private static void VisitParameter(Parameter parameter, AssignContext _, int offset)
        {
            Debug.Assert(parameter.Id.Symbol != null);

            parameter.Id.Symbol.Offset = offset;
        }

        private static int VisitCompoundStatement(CompoundStatement compoundStatement, AssignContext context, int offset)
        {
            var size = 0;
            foreach (var statement in compoundStatement.Statements)
            {
                if (statement is VariableDefinitionStatement || statement is VariableDefinitionAndAssignmentStatement)
                {
                    var varSize = VisitStatement(statement, context, offset);
                    offset += varSize;
                    size += varSize;
                }
                else
                {
                    size += VisitStatement(statement, context, offset);
                }

                context.Clear();
            }

            return size;
        }

        private static int VisitStatement(Statement statement, AssignContext context, int offset)
        {
            return statement switch
            {
                PrintStatement s => VisitPrintStatement(s, context, offset),
                PrintLineStatement s => VisitPrintLineStatement(s, context, offset),
                VariableDefinitionStatement s => VisitVariableDefinitionStatement(s, context, offset),
                AssignmentStatement s => VisitAssignmentStatement(s, context, offset),
                IncrementStatement s => VisitIncrementStatement(s, context, offset),
                VariableDefinitionAndAssignmentStatement s => VisitVariableDefinitionAndAssignmentStatement(s, context, offset),
                CallStatement s => VisitCallStatement(s, context, offset),
                IfStatement s => VisitIfStatement(s, context, offset),
                WhileStatement s => VisitWhileStatement(s, context, offset),
                DoWhileStatement s => VisitDoWhileStatement(s, context, offset),
                ForStatement s => VisitForStatement(s, context, offset),
                BreakStatement or ContinueStatement => 0,
                ReturnStatement s => VisitReturnStatement(s, context, offset),
                ExitStatement s => VisitExitStatement(s, context, offset),
                CompoundStatement s => VisitCompoundStatement(s, context, offset),
                _ => throw new NotImplementedException($"Unknown statement {statement}"),
            };
        }

        private static int VisitPrintStatement(PrintStatement s, AssignContext context, int offset)
        {
            VisitExpression(s.Expression, context, offset);
            return 0;
        }

        private static int VisitPrintLineStatement(PrintLineStatement s, AssignContext context, int offset)
        {
            VisitPrintStatement(s.PrintExpression, context, offset);
            VisitPrintStatement(s.PrintLine, context, offset);
            return 0;
        }

        private static int VisitVariableDefinitionStatement(VariableDefinitionStatement s, AssignContext _, int offset)
        {
            Debug.Assert(s.Id.Symbol != null);

            s.Id.Symbol.Offset = offset;
            return s.Id.Symbol.Type.GetSizeInWords();
        }

        private static int VisitAssignmentStatement(AssignmentStatement s, AssignContext context, int offset)
        {
            VisitExpression(s.Right, context, offset);
            VisitExpression(s.Left, context, offset);
            context.DropRegister(s.Right.Register);
            context.DropRegister(s.Left.Register);
            return 0;
        }

        private static int VisitIncrementStatement(IncrementStatement s, AssignContext context, int offset)
        {
            s.IncrementRegister = context.GetRegister();
            VisitExpression(s.Left, context, offset);
            context.DropRegister(s.Left.Register);
            context.DropRegister(s.IncrementRegister);
            return 0;
        }

        private static int VisitVariableDefinitionAndAssignmentStatement(VariableDefinitionAndAssignmentStatement s, AssignContext context, int offset)
        {
            Debug.Assert(s.Id.Symbol != null);

            VisitExpression(s.Expression, context, offset);
            context.DropRegister(s.Expression.Register);
            s.Id.Symbol.Offset = offset;
            return s.Id.Symbol.Type.GetSizeInWords();
        }

        private static int VisitCallStatement(CallStatement s, AssignContext context, int offset)
        {
            VisitExpression(s.CallExpression, context, offset);
            context.DropRegister(s.CallExpression.Register);
            return 0;
        }

        private static int VisitIfStatement(IfStatement s, AssignContext context, int offset)
        {
            var sizes = new List<int>();
            VisitExpression(s.IfExpression, context, offset);
            context.DropRegister(s.IfExpression.Register);
            sizes.Add(VisitCompoundStatement(s.IfBody, context, offset));

            foreach (var (e, b) in s.ElifExpressions.Zip(s.ElifBodies))
            {
                VisitExpression(e, context, offset);
                context.DropRegister(e.Register);
                sizes.Add(VisitCompoundStatement(b, context, offset));
            }

            if (s.ElseBody != null)
            {
                sizes.Add(VisitCompoundStatement(s.ElseBody, context, offset));
            }

            return sizes.Max();
        }

        private static int VisitWhileStatement(WhileStatement s, AssignContext context, int offset)
        {
            VisitExpression(s.Expression, context, offset);
            context.DropRegister(s.Expression.Register);
            return VisitCompoundStatement(s.Body, context, offset);
        }

        private static int VisitDoWhileStatement(DoWhileStatement s, AssignContext context, int offset)
        {
            var size = VisitCompoundStatement(s.Body, context, offset);
            VisitExpression(s.Expression, context, offset);
            context.DropRegister(s.Expression.Register);
            return size;
        }


        private static int VisitForStatement(ForStatement s, AssignContext context, int offset)
        {
            var size = 0;
            if (s.InitialStatement is VariableDefinitionStatement or VariableDefinitionAndAssignmentStatement)
            {
                var varSize = VisitStatement(s.InitialStatement, context, offset);
                offset += varSize;
                size += varSize;
            }
            else
            {
                VisitStatement(s.InitialStatement, context, offset);
            }


            VisitExpression(s.Expression, context, offset);
            context.DropRegister(s.Expression.Register);
            if (s.UpdateStatement is VariableDefinitionStatement or VariableDefinitionAndAssignmentStatement)
            {
                var varSize = VisitStatement(s.UpdateStatement, context, offset);
                offset += varSize;
                size += varSize;
            }
            else
            {
                VisitStatement(s.UpdateStatement, context, offset);
            }

            size += VisitCompoundStatement(s.Body, context, offset);
            return size;
        }

        private static int VisitReturnStatement(ReturnStatement s, AssignContext context, int offset)
        {
            if (s.Expression != null)
            {
                VisitExpression(s.Expression, context, offset);
                context.DropRegister(s.Expression.Register);
            }

            return 0;
        }

        private static int VisitExitStatement(ExitStatement s, AssignContext context, int offset)
        {
            VisitExpression(s.Expression, context, offset);
            context.DropRegister(s.Expression.Register);
            return 0;
        }

        private static int VisitExpression(Expression expression, AssignContext context, int offset)
        {
            return expression switch
            {
                BinaryOperatorExpression e => VisitBinaryOperatorExpression(e, context, offset),
                UnaryOperatorExpression e => VisitUnaryOperatorExpression(e, context, offset),
                ArrayIndexExpression e => VisitArrayIndexExpression(e, context, offset),
                FieldAccessExpression e => VisitFieldAccessExpression(e, context, offset),
                CallExpression e => VisitCallExpression(e, context, offset),
                StructLiteralExpression e => VisitStructLiteralExpression(e, context, offset),
                ArrayLiteralExpression e => VisitArrayLiteralExpression(e, context, offset),
                Expression e => VisitAtomicExpression(e, context, offset),
                _ => throw new NotImplementedException($"Unknown expression: {expression}")
            };
        }

        private static int VisitBinaryOperatorExpression(BinaryOperatorExpression e, AssignContext context, int offset)
        {
            VisitExpression(e.LeftOperand, context, offset);
            VisitExpression(e.RightOperand, context, offset);
            e.Register = e.LeftOperand.Register;
            context.DropRegister(e.RightOperand.Register);

            return 0;
        }

        private static int VisitUnaryOperatorExpression(UnaryOperatorExpression e, AssignContext context, int offset)
        {
            VisitExpression(e.Operand, context, offset);
            e.Register = e.Operand.Register;
            return 0;
        }

        private static int VisitCallExpression(CallExpression e, AssignContext context, int offset)
        {
            VisitExpression(e.Function, context, offset);
            foreach (var arg in e.Arguments)
            {
                VisitExpression(arg, context, offset);
                context.DropRegister(arg.Register);
            }

            e.Register = e.Function.Register;
            return 0;
        }

        private static int VisitArrayIndexExpression(ArrayIndexExpression e, AssignContext context, int offset)
        {
            VisitExpression(e.Array, context, offset);
            VisitExpression(e.Index, context, offset);
            context.DropRegister(e.Index.Register);
            e.Register = e.Array.Register;
            return 0;
        }

        private static int VisitFieldAccessExpression(FieldAccessExpression e, AssignContext context, int offset)
        {
            var operatingType = e.GetOperatingType();
            if (operatingType is UserDefinedType userDefinedType)
            {
                var definition = SymbolTable.LookupDefinition(userDefinedType, e.Span);
                switch (definition)
                {
                    case StructDefinition d:
                        e.Offset = d.Fields.Where(f => f.Id.Value == e.Id.Value).Select(f => f.Offset).FirstOrDefault();
                        break;
                    default:
                        ErrorHandler.Throw("Field access expression is invalid for type", e);
                        break;
                }

                VisitExpression(e.Left, context, offset);
                e.Register = e.Left.Register;
                return 0;
            }

            throw new Exception("Operating type was not a user defined type");
        }

        private static int VisitStructLiteralExpression(StructLiteralExpression e, AssignContext context, int offset)
        {
            e.Register = context.GetRegister();
            e.MapOffsetsFromDefinition();
            foreach (var field in e.Fields)
            {
                VisitExpression(field.Expression, context, offset);
                context.DropRegister(field.Expression.Register);
            }

            context.DropRegister(e.Register);
            return 0;
        }

        private static int VisitArrayLiteralExpression(ArrayLiteralExpression e, AssignContext context, int offset)
        {
            e.Offset = offset;
            e.Register = context.GetRegister();
            var localOffset = 0;
            foreach (var element in e.Elements)
            {
                element.Offset = localOffset;
                VisitExpression(element.Expression, context, localOffset);
                context.DropRegister(element.Expression.Register);
                localOffset += element.Expression.Type!.GetSizeInWords();
            }

            return 0;
        }

        private static int VisitAtomicExpression(Expression e, AssignContext context, int _)
        {
            e.Register = context.GetRegister();
            return 0;
        }
    }
}
