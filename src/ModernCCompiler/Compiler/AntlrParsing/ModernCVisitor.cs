//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from c:/LocalFiles/ModernC/src/ModernCCompiler/Compiler/AntlrParsing/ModernC.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="ModernCParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public interface IModernCVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProgram([NotNull] ModernCParser.ProgramContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.functionDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionDefinition([NotNull] ModernCParser.FunctionDefinitionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.parameterList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameterList([NotNull] ModernCParser.ParameterListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameter([NotNull] ModernCParser.ParameterContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitType([NotNull] ModernCParser.TypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.primitiveType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrimitiveType([NotNull] ModernCParser.PrimitiveTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.functionType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionType([NotNull] ModernCParser.FunctionTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.typeList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypeList([NotNull] ModernCParser.TypeListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement([NotNull] ModernCParser.StatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.simpleStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSimpleStatement([NotNull] ModernCParser.SimpleStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.compoundStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCompoundStatement([NotNull] ModernCParser.CompoundStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.printStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrintStatement([NotNull] ModernCParser.PrintStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.printlnStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrintlnStatement([NotNull] ModernCParser.PrintlnStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.variableDefinitionStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariableDefinitionStatement([NotNull] ModernCParser.VariableDefinitionStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.variableDefinitionAndAssignmentStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariableDefinitionAndAssignmentStatement([NotNull] ModernCParser.VariableDefinitionAndAssignmentStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.assignmentStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignmentStatement([NotNull] ModernCParser.AssignmentStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.incrementStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIncrementStatement([NotNull] ModernCParser.IncrementStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.callStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCallStatement([NotNull] ModernCParser.CallStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.ifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfStatement([NotNull] ModernCParser.IfStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.elifPart"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElifPart([NotNull] ModernCParser.ElifPartContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.elsePart"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElsePart([NotNull] ModernCParser.ElsePartContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.whileStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhileStatement([NotNull] ModernCParser.WhileStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.doWhileStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDoWhileStatement([NotNull] ModernCParser.DoWhileStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.forStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitForStatement([NotNull] ModernCParser.ForStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.breakStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBreakStatement([NotNull] ModernCParser.BreakStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.continueStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitContinueStatement([NotNull] ModernCParser.ContinueStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.returnStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturnStatement([NotNull] ModernCParser.ReturnStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.exitStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExitStatement([NotNull] ModernCParser.ExitStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression([NotNull] ModernCParser.ExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.orExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOrExpression([NotNull] ModernCParser.OrExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.andExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAndExpression([NotNull] ModernCParser.AndExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.comparison"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitComparison([NotNull] ModernCParser.ComparisonContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTerm([NotNull] ModernCParser.TermContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFactor([NotNull] ModernCParser.FactorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.unaryExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnaryExpression([NotNull] ModernCParser.UnaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.callExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCallExpression([NotNull] ModernCParser.CallExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.argumentList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgumentList([NotNull] ModernCParser.ArgumentListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.readExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReadExpression([NotNull] ModernCParser.ReadExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.intLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIntLiteral([NotNull] ModernCParser.IntLiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.byteLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitByteLiteral([NotNull] ModernCParser.ByteLiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.floatLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFloatLiteral([NotNull] ModernCParser.FloatLiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.boolLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBoolLiteral([NotNull] ModernCParser.BoolLiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.idExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdExpression([NotNull] ModernCParser.IdExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ModernCParser.id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitId([NotNull] ModernCParser.IdContext context);
}
