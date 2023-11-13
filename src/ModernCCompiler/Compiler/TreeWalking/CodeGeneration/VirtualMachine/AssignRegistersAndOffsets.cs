using Compiler.Models.Tree;

namespace Compiler.TreeWalking.CodeGeneration.VirtualMachine
{
    public static class AssignRegistersAndOffsets
    {
        private class Context
        {
            private readonly HashSet<int> _regsInUse = new HashSet<int>();

            public string GetRegister()
            {
                int reg = 0;
                while (_regsInUse.Contains(reg))
                {
                    reg++;
                }

                _regsInUse.Add(reg);
                return $"r{reg}";
            }

            public List<string> GetRegisterPool()
            {
                return _regsInUse
                    .OrderBy(x => x)
                    .Select(x => $"r{x}")
                    .ToList();
            }
        }

        public static void Walk(ProgramRoot program)
        {
            VisitProgramRoot(program);
        }

        private static void VisitProgramRoot(ProgramRoot program) 
        { 
            foreach (var function in program.FunctionDefinitions)
            {
                VisitFunctionDefinition(function);
            }
        }

        private static void VisitFunctionDefinition(FunctionDefinition function)
        {
            var context = new Context();
            VisitParameterList(function.ParameterList, context, -2);
            function.Size = VisitCompoundStatement(function.Body, context, 3);
            function.RegisterPool = context.GetRegisterPool();
        }

        private static void VisitParameterList(ParameterList parameterList, Context _, int offset)
        {
            foreach (var parameter in parameterList.Parameters)
            {
                if (parameter.Id.Symbol != null)
                {
                    parameter.Id.Symbol.Offset = offset;
                }
                else
                {
                    throw new Exception("Parameter symbol was null");
                }

                offset--;
            }
        }


        private static int VisitCompoundStatement(CompoundStatement compoundStatement, Context context, int offset)
        {
            foreach (var statement in compoundStatement.Statements)
            {
                offset += VisitStatement(statement, context, offset);
            }

            return offset;
        }

        private static int VisitStatement(Statement statement, Context context, int offset)
        {
            return statement switch
            {
                PrintStatement s => offset + VisitPrintStatement(s, context, offset),
                VariableDefinitionStatement s => offset + VisitVariableDefinitionStatement(s, context, offset),
                AssignmentStatement s => offset + VisitAssignmentStatement(s, context, offset),
                VariableDefinitionAndAssignmentStatement s => offset + VisitVariableDefinitionAndAssignmentStatement(s, context, offset),
                ReturnStatement s => offset + VisitReturnStatement(s, context, offset),
                CompoundStatement s => offset + VisitCompoundStatement(s, context, offset),
                _ => throw new NotImplementedException($"Unknown statement {statement}"),
            };
        }

        private static int VisitPrintStatement(PrintStatement s, Context context, int offset)
        {
            return offset + VisitExpression(s.Expression, context, offset);
        }

        private static int VisitVariableDefinitionStatement(VariableDefinitionStatement s, Context context, int offset)
        {
            if (s.Id.Symbol != null)
            {
                s.Id.Symbol.Offset = offset;
                return offset + 1;
            }

            throw new Exception("Symbol was null");
        }

        private static int VisitAssignmentStatement(AssignmentStatement s, Context context, int offset)
        {
            offset += VisitExpression(s.Left, context, offset);
            offset += VisitExpression(s.Right, context, offset);
            return offset;
        }

        private static int VisitVariableDefinitionAndAssignmentStatement(VariableDefinitionAndAssignmentStatement s, Context context, int offset)
        {
            if (s.Id.Symbol != null)
            {
                offset += VisitExpression(s.Expression, context, offset);
                s.Id.Symbol.Offset = offset;
                return offset + 1;
            }

            throw new Exception("Symbol was null");
        }

        private static int VisitReturnStatement(ReturnStatement s, Context context, int offset)
        {
            if (s.Expression != null)
            {
                offset += VisitExpression(s.Expression, context, offset);
            }

            return offset;
        }

        private static int VisitExpression(Expression expression, Context context, int offset)
        {
            return expression switch
            {
                BinaryOperatorExpression e => VisitBinaryOperatorExpression(e, context, offset),
                UnaryOperatorExpression e => VisitUnaryOperatorExpression(e, context, offset),
                IdExpression e => VisitIdExpression(e, context, offset),
                IntLiteralExpression e => VisitIntLiteralExpression(e, context, offset),
                BoolLiteralExpression e => VisitBoolLiteralExpression(e, context, offset),
                _ => throw new NotImplementedException($"Unknown expression: {expression}"),
            };
        }

        private static int VisitBinaryOperatorExpression(BinaryOperatorExpression e, Context context, int offset)
        {
            offset += VisitExpression(e.LeftOperand, context, offset);
            offset += VisitExpression(e.RightOperand, context, offset);
            e.Register = e.LeftOperand.Register;
            return offset;
        }

        private static int VisitUnaryOperatorExpression(UnaryOperatorExpression e, Context context, int offset)
        {
            offset += VisitExpression(e.Operand, context, offset);
            e.Register = e.Operand.Register;
            return offset;
        }

        private static int VisitIdExpression(IdExpression e, Context context, int offset)
        {
            e.Register = context.GetRegister();
            return offset;
        }

        private static int VisitBoolLiteralExpression(BoolLiteralExpression e, Context context, int offset)
        {
            e.Register = context.GetRegister();
            return offset;
        }

        private static int VisitIntLiteralExpression(IntLiteralExpression e, Context context, int offset)
        {
            e.Register = context.GetRegister();
            return offset;
        }
    }
}
