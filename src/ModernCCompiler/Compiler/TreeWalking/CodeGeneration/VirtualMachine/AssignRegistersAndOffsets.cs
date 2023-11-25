using Compiler.Models.Tree;

namespace Compiler.TreeWalking.CodeGeneration.VirtualMachine
{
    public static class AssignRegistersAndOffsets
    {
        private class Context
        {
            private readonly HashSet<int> _regsInUse = new();
            private readonly HashSet<int> _regPool = new();

            public string GetRegister()
            {
                int reg = 1;
                while (_regsInUse.Contains(reg))
                {
                    reg++;
                }

                _regsInUse.Add(reg);
                _regPool.Add(reg);
                return $"r{reg}";
            }

            public void DropRegister(string register)
            {
                var r = int.Parse(register.Replace("r", ""));
                _regsInUse.Remove(r);
            }

            public void Clear()
            {
                _regsInUse.Clear();
            }


            public List<string> GetRegisterPool()
            {
                return _regPool
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

        private static int VisitStatement(Statement statement, Context context, int offset)
        {
            return statement switch
            {
                PrintStatement s => VisitPrintStatement(s, context, offset),
                VariableDefinitionStatement s => VisitVariableDefinitionStatement(s, context, offset),
                AssignmentStatement s => VisitAssignmentStatement(s, context, offset),
                IncrementStatement s => VisitIncrementStatement(s, context, offset),
                VariableDefinitionAndAssignmentStatement s => VisitVariableDefinitionAndAssignmentStatement(s, context, offset),
                CallStatement s => VisitCallStatement(s, context, offset),
                IfStatement s => VisitIfStatement(s, context, offset),
                WhileStatement s => VisitWhileStatement(s, context, offset),
                ForStatement s => VisitForStatement(s, context, offset),
                ReturnStatement s => VisitReturnStatement(s, context, offset),
                CompoundStatement s => VisitCompoundStatement(s, context, offset),
                _ => throw new NotImplementedException($"Unknown statement {statement}"),
            };
        }

        private static int VisitPrintStatement(PrintStatement s, Context context, int offset)
        {
            return VisitExpression(s.Expression, context, offset);
        }

        private static int VisitVariableDefinitionStatement(VariableDefinitionStatement s, Context _, int offset)
        {
            if (s.Id.Symbol != null)
            {
                s.Id.Symbol.Offset = offset;
                return 1;
            }

            throw new Exception("Symbol was null");
        }

        private static int VisitAssignmentStatement(AssignmentStatement s, Context context, int offset)
        {
            if (s.BinaryExpression != null)
            {
                VisitBinaryOperatorExpression(s.BinaryExpression, context, offset);
                s.Left.AssignmentRegister = context.GetRegister();
                context.DropRegister(s.Left.AssignmentRegister);
            }
            else
            {
                VisitExpression(s.Right, context, offset);
                VisitExpression(s.Left, context, offset);
            }

            return 0;
        }

        private static int VisitIncrementStatement(IncrementStatement s, Context context, int offset)
        {
            VisitExpression(s.Left, context, offset);
            s.Left.AssignmentRegister = context.GetRegister();
            context.DropRegister(s.Left.AssignmentRegister);
            return 0;
        }

        private static int VisitVariableDefinitionAndAssignmentStatement(VariableDefinitionAndAssignmentStatement s, Context context, int offset)
        {
            if (s.Id.Symbol != null)
            {
                VisitExpression(s.Expression, context, offset);
                s.Id.Symbol.Offset = offset;
                return 1;
            }

            throw new Exception("Symbol was null");
        }

        private static int VisitCallStatement(CallStatement s, Context context, int offset)
        {
            VisitCallExpression(s.CallExpression, context, offset);
            return 0;
        }

        private static int VisitIfStatement(IfStatement s, Context context, int offset)
        {
            var sizes = new List<int>();
            VisitExpression(s.IfExpression, context, offset);
            sizes.Add(VisitCompoundStatement(s.IfBody, context, offset));

            foreach (var (e, b) in s.ElifExpressions.Zip(s.ElifBodies))
            {
                VisitExpression(e, context, offset);
                sizes.Add(VisitCompoundStatement(b, context, offset));
            }

            if (s.ElseBody != null)
            {
                sizes.Add(VisitCompoundStatement(s.ElseBody, context, offset));
            }

            return sizes.Max();
        }

        private static int VisitWhileStatement(WhileStatement s, Context context, int offset)
        {
            VisitExpression(s.Expression, context, offset);
            return VisitCompoundStatement(s.Body, context, offset);
        }

        private static int VisitForStatement(ForStatement s, Context context, int offset)
        {
            VisitStatement(s.InitialStatement, context, offset);
            VisitExpression(s.Expression, context, offset);
            VisitStatement(s.UpdateStatement, context, offset);
            return VisitCompoundStatement(s.Body, context, offset);
        }

        private static int VisitReturnStatement(ReturnStatement s, Context context, int offset)
        {
            if (s.Expression != null)
            {
                VisitExpression(s.Expression, context, offset);
            }

            return 0;
        }

        private static int VisitExpression(Expression expression, Context context, int offset)
        {
            return expression switch
            {
                BinaryOperatorExpression e => VisitBinaryOperatorExpression(e, context, offset),
                UnaryOperatorExpression e => VisitUnaryOperatorExpression(e, context, offset),
                CallExpression e => VisitCallExpression(e, context, offset),
                IdExpression e => VisitIdExpression(e, context, offset),
                IntLiteralExpression e => VisitIntLiteralExpression(e, context, offset),
                ByteLiteralExpression e => VisitByteLiteralExpression(e, context, offset),
                BoolLiteralExpression e => VisitBoolLiteralExpression(e, context, offset),
                _ => throw new NotImplementedException($"Unknown expression: {expression}")
            };
        }

        private static int VisitBinaryOperatorExpression(BinaryOperatorExpression e, Context context, int offset)
        {
            VisitExpression(e.LeftOperand, context, offset);
            VisitExpression(e.RightOperand, context, offset);
            e.Register = e.LeftOperand.Register;
            context.DropRegister(e.RightOperand.Register);
            
            return 0;
        }

        private static int VisitUnaryOperatorExpression(UnaryOperatorExpression e, Context context, int offset)
        {
            VisitExpression(e.Operand, context, offset);
            e.Register = e.Operand.Register;
            return 0;
        }

        private static int VisitCallExpression(CallExpression e, Context context, int offset)
        {
            VisitIdExpression(e.Function, context, offset);
            var argRegs = new List<string>();
            foreach (var arg in e.ArgumentList.Arguments)
            {
                VisitExpression(arg, context, offset);
                argRegs.Add(arg.Register);
            }

            foreach (var argReg in argRegs)
            {
                context.DropRegister(argReg);
            }

            e.Register = e.Function.Register;
            return 0;
        }


        private static int VisitIdExpression(IdExpression e, Context context, int _)
        {
            e.Register = context.GetRegister();
            return 0;
        }

        private static int VisitIntLiteralExpression(IntLiteralExpression e, Context context, int _)
        {
            e.Register = context.GetRegister();
            return 0;
        }

        private static int VisitByteLiteralExpression(ByteLiteralExpression e, Context context, int _)
        {
            e.Register = context.GetRegister();
            return 0;
        }

        private static int VisitBoolLiteralExpression(BoolLiteralExpression e, Context context, int _)
        {
            e.Register = context.GetRegister();
            return 0;
        }
    }
}
