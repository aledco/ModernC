// Generated from c:/LocalFiles/ModernC/src/ModernCCompiler/Compiler/AntlrParsing/ModernC.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link ModernCParser}.
 */
public interface ModernCListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link ModernCParser#program}.
	 * @param ctx the parse tree
	 */
	void enterProgram(ModernCParser.ProgramContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#program}.
	 * @param ctx the parse tree
	 */
	void exitProgram(ModernCParser.ProgramContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#topLevelStatement}.
	 * @param ctx the parse tree
	 */
	void enterTopLevelStatement(ModernCParser.TopLevelStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#topLevelStatement}.
	 * @param ctx the parse tree
	 */
	void exitTopLevelStatement(ModernCParser.TopLevelStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#functionDefinition}.
	 * @param ctx the parse tree
	 */
	void enterFunctionDefinition(ModernCParser.FunctionDefinitionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#functionDefinition}.
	 * @param ctx the parse tree
	 */
	void exitFunctionDefinition(ModernCParser.FunctionDefinitionContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#parameterList}.
	 * @param ctx the parse tree
	 */
	void enterParameterList(ModernCParser.ParameterListContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#parameterList}.
	 * @param ctx the parse tree
	 */
	void exitParameterList(ModernCParser.ParameterListContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#parameter}.
	 * @param ctx the parse tree
	 */
	void enterParameter(ModernCParser.ParameterContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#parameter}.
	 * @param ctx the parse tree
	 */
	void exitParameter(ModernCParser.ParameterContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#definition}.
	 * @param ctx the parse tree
	 */
	void enterDefinition(ModernCParser.DefinitionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#definition}.
	 * @param ctx the parse tree
	 */
	void exitDefinition(ModernCParser.DefinitionContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#structDefinition}.
	 * @param ctx the parse tree
	 */
	void enterStructDefinition(ModernCParser.StructDefinitionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#structDefinition}.
	 * @param ctx the parse tree
	 */
	void exitStructDefinition(ModernCParser.StructDefinitionContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#structFieldDefinition}.
	 * @param ctx the parse tree
	 */
	void enterStructFieldDefinition(ModernCParser.StructFieldDefinitionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#structFieldDefinition}.
	 * @param ctx the parse tree
	 */
	void exitStructFieldDefinition(ModernCParser.StructFieldDefinitionContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#type}.
	 * @param ctx the parse tree
	 */
	void enterType(ModernCParser.TypeContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#type}.
	 * @param ctx the parse tree
	 */
	void exitType(ModernCParser.TypeContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#primitiveType}.
	 * @param ctx the parse tree
	 */
	void enterPrimitiveType(ModernCParser.PrimitiveTypeContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#primitiveType}.
	 * @param ctx the parse tree
	 */
	void exitPrimitiveType(ModernCParser.PrimitiveTypeContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#functionType}.
	 * @param ctx the parse tree
	 */
	void enterFunctionType(ModernCParser.FunctionTypeContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#functionType}.
	 * @param ctx the parse tree
	 */
	void exitFunctionType(ModernCParser.FunctionTypeContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#userDefinedType}.
	 * @param ctx the parse tree
	 */
	void enterUserDefinedType(ModernCParser.UserDefinedTypeContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#userDefinedType}.
	 * @param ctx the parse tree
	 */
	void exitUserDefinedType(ModernCParser.UserDefinedTypeContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#typeList}.
	 * @param ctx the parse tree
	 */
	void enterTypeList(ModernCParser.TypeListContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#typeList}.
	 * @param ctx the parse tree
	 */
	void exitTypeList(ModernCParser.TypeListContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#statement}.
	 * @param ctx the parse tree
	 */
	void enterStatement(ModernCParser.StatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#statement}.
	 * @param ctx the parse tree
	 */
	void exitStatement(ModernCParser.StatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#simpleStatement}.
	 * @param ctx the parse tree
	 */
	void enterSimpleStatement(ModernCParser.SimpleStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#simpleStatement}.
	 * @param ctx the parse tree
	 */
	void exitSimpleStatement(ModernCParser.SimpleStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#compoundStatement}.
	 * @param ctx the parse tree
	 */
	void enterCompoundStatement(ModernCParser.CompoundStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#compoundStatement}.
	 * @param ctx the parse tree
	 */
	void exitCompoundStatement(ModernCParser.CompoundStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#printStatement}.
	 * @param ctx the parse tree
	 */
	void enterPrintStatement(ModernCParser.PrintStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#printStatement}.
	 * @param ctx the parse tree
	 */
	void exitPrintStatement(ModernCParser.PrintStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#printlnStatement}.
	 * @param ctx the parse tree
	 */
	void enterPrintlnStatement(ModernCParser.PrintlnStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#printlnStatement}.
	 * @param ctx the parse tree
	 */
	void exitPrintlnStatement(ModernCParser.PrintlnStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#variableDefinitionStatement}.
	 * @param ctx the parse tree
	 */
	void enterVariableDefinitionStatement(ModernCParser.VariableDefinitionStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#variableDefinitionStatement}.
	 * @param ctx the parse tree
	 */
	void exitVariableDefinitionStatement(ModernCParser.VariableDefinitionStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#variableDefinitionAndAssignmentStatement}.
	 * @param ctx the parse tree
	 */
	void enterVariableDefinitionAndAssignmentStatement(ModernCParser.VariableDefinitionAndAssignmentStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#variableDefinitionAndAssignmentStatement}.
	 * @param ctx the parse tree
	 */
	void exitVariableDefinitionAndAssignmentStatement(ModernCParser.VariableDefinitionAndAssignmentStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#assignmentStatement}.
	 * @param ctx the parse tree
	 */
	void enterAssignmentStatement(ModernCParser.AssignmentStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#assignmentStatement}.
	 * @param ctx the parse tree
	 */
	void exitAssignmentStatement(ModernCParser.AssignmentStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#incrementStatement}.
	 * @param ctx the parse tree
	 */
	void enterIncrementStatement(ModernCParser.IncrementStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#incrementStatement}.
	 * @param ctx the parse tree
	 */
	void exitIncrementStatement(ModernCParser.IncrementStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#callStatement}.
	 * @param ctx the parse tree
	 */
	void enterCallStatement(ModernCParser.CallStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#callStatement}.
	 * @param ctx the parse tree
	 */
	void exitCallStatement(ModernCParser.CallStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#ifStatement}.
	 * @param ctx the parse tree
	 */
	void enterIfStatement(ModernCParser.IfStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#ifStatement}.
	 * @param ctx the parse tree
	 */
	void exitIfStatement(ModernCParser.IfStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#elifPart}.
	 * @param ctx the parse tree
	 */
	void enterElifPart(ModernCParser.ElifPartContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#elifPart}.
	 * @param ctx the parse tree
	 */
	void exitElifPart(ModernCParser.ElifPartContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#elsePart}.
	 * @param ctx the parse tree
	 */
	void enterElsePart(ModernCParser.ElsePartContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#elsePart}.
	 * @param ctx the parse tree
	 */
	void exitElsePart(ModernCParser.ElsePartContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#whileStatement}.
	 * @param ctx the parse tree
	 */
	void enterWhileStatement(ModernCParser.WhileStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#whileStatement}.
	 * @param ctx the parse tree
	 */
	void exitWhileStatement(ModernCParser.WhileStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#doWhileStatement}.
	 * @param ctx the parse tree
	 */
	void enterDoWhileStatement(ModernCParser.DoWhileStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#doWhileStatement}.
	 * @param ctx the parse tree
	 */
	void exitDoWhileStatement(ModernCParser.DoWhileStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#forStatement}.
	 * @param ctx the parse tree
	 */
	void enterForStatement(ModernCParser.ForStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#forStatement}.
	 * @param ctx the parse tree
	 */
	void exitForStatement(ModernCParser.ForStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#breakStatement}.
	 * @param ctx the parse tree
	 */
	void enterBreakStatement(ModernCParser.BreakStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#breakStatement}.
	 * @param ctx the parse tree
	 */
	void exitBreakStatement(ModernCParser.BreakStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#continueStatement}.
	 * @param ctx the parse tree
	 */
	void enterContinueStatement(ModernCParser.ContinueStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#continueStatement}.
	 * @param ctx the parse tree
	 */
	void exitContinueStatement(ModernCParser.ContinueStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#returnStatement}.
	 * @param ctx the parse tree
	 */
	void enterReturnStatement(ModernCParser.ReturnStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#returnStatement}.
	 * @param ctx the parse tree
	 */
	void exitReturnStatement(ModernCParser.ReturnStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#exitStatement}.
	 * @param ctx the parse tree
	 */
	void enterExitStatement(ModernCParser.ExitStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#exitStatement}.
	 * @param ctx the parse tree
	 */
	void exitExitStatement(ModernCParser.ExitStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterExpression(ModernCParser.ExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitExpression(ModernCParser.ExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#orExpression}.
	 * @param ctx the parse tree
	 */
	void enterOrExpression(ModernCParser.OrExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#orExpression}.
	 * @param ctx the parse tree
	 */
	void exitOrExpression(ModernCParser.OrExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#andExpression}.
	 * @param ctx the parse tree
	 */
	void enterAndExpression(ModernCParser.AndExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#andExpression}.
	 * @param ctx the parse tree
	 */
	void exitAndExpression(ModernCParser.AndExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#comparison}.
	 * @param ctx the parse tree
	 */
	void enterComparison(ModernCParser.ComparisonContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#comparison}.
	 * @param ctx the parse tree
	 */
	void exitComparison(ModernCParser.ComparisonContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#term}.
	 * @param ctx the parse tree
	 */
	void enterTerm(ModernCParser.TermContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#term}.
	 * @param ctx the parse tree
	 */
	void exitTerm(ModernCParser.TermContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#factor}.
	 * @param ctx the parse tree
	 */
	void enterFactor(ModernCParser.FactorContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#factor}.
	 * @param ctx the parse tree
	 */
	void exitFactor(ModernCParser.FactorContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#unaryExpression}.
	 * @param ctx the parse tree
	 */
	void enterUnaryExpression(ModernCParser.UnaryExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#unaryExpression}.
	 * @param ctx the parse tree
	 */
	void exitUnaryExpression(ModernCParser.UnaryExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#argumentList}.
	 * @param ctx the parse tree
	 */
	void enterArgumentList(ModernCParser.ArgumentListContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#argumentList}.
	 * @param ctx the parse tree
	 */
	void exitArgumentList(ModernCParser.ArgumentListContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#arrayExpressionTail}.
	 * @param ctx the parse tree
	 */
	void enterArrayExpressionTail(ModernCParser.ArrayExpressionTailContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#arrayExpressionTail}.
	 * @param ctx the parse tree
	 */
	void exitArrayExpressionTail(ModernCParser.ArrayExpressionTailContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#readExpression}.
	 * @param ctx the parse tree
	 */
	void enterReadExpression(ModernCParser.ReadExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#readExpression}.
	 * @param ctx the parse tree
	 */
	void exitReadExpression(ModernCParser.ReadExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#intLiteral}.
	 * @param ctx the parse tree
	 */
	void enterIntLiteral(ModernCParser.IntLiteralContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#intLiteral}.
	 * @param ctx the parse tree
	 */
	void exitIntLiteral(ModernCParser.IntLiteralContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#byteLiteral}.
	 * @param ctx the parse tree
	 */
	void enterByteLiteral(ModernCParser.ByteLiteralContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#byteLiteral}.
	 * @param ctx the parse tree
	 */
	void exitByteLiteral(ModernCParser.ByteLiteralContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#floatLiteral}.
	 * @param ctx the parse tree
	 */
	void enterFloatLiteral(ModernCParser.FloatLiteralContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#floatLiteral}.
	 * @param ctx the parse tree
	 */
	void exitFloatLiteral(ModernCParser.FloatLiteralContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#boolLiteral}.
	 * @param ctx the parse tree
	 */
	void enterBoolLiteral(ModernCParser.BoolLiteralContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#boolLiteral}.
	 * @param ctx the parse tree
	 */
	void exitBoolLiteral(ModernCParser.BoolLiteralContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#idExpression}.
	 * @param ctx the parse tree
	 */
	void enterIdExpression(ModernCParser.IdExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#idExpression}.
	 * @param ctx the parse tree
	 */
	void exitIdExpression(ModernCParser.IdExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#complexLiteral}.
	 * @param ctx the parse tree
	 */
	void enterComplexLiteral(ModernCParser.ComplexLiteralContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#complexLiteral}.
	 * @param ctx the parse tree
	 */
	void exitComplexLiteral(ModernCParser.ComplexLiteralContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#arrayLiteral}.
	 * @param ctx the parse tree
	 */
	void enterArrayLiteral(ModernCParser.ArrayLiteralContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#arrayLiteral}.
	 * @param ctx the parse tree
	 */
	void exitArrayLiteral(ModernCParser.ArrayLiteralContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#stringLiteral}.
	 * @param ctx the parse tree
	 */
	void enterStringLiteral(ModernCParser.StringLiteralContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#stringLiteral}.
	 * @param ctx the parse tree
	 */
	void exitStringLiteral(ModernCParser.StringLiteralContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#structLiteral}.
	 * @param ctx the parse tree
	 */
	void enterStructLiteral(ModernCParser.StructLiteralContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#structLiteral}.
	 * @param ctx the parse tree
	 */
	void exitStructLiteral(ModernCParser.StructLiteralContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#structLiteralField}.
	 * @param ctx the parse tree
	 */
	void enterStructLiteralField(ModernCParser.StructLiteralFieldContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#structLiteralField}.
	 * @param ctx the parse tree
	 */
	void exitStructLiteralField(ModernCParser.StructLiteralFieldContext ctx);
	/**
	 * Enter a parse tree produced by {@link ModernCParser#id}.
	 * @param ctx the parse tree
	 */
	void enterId(ModernCParser.IdContext ctx);
	/**
	 * Exit a parse tree produced by {@link ModernCParser#id}.
	 * @param ctx the parse tree
	 */
	void exitId(ModernCParser.IdContext ctx);
}