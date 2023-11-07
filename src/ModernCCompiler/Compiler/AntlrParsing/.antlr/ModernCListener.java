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