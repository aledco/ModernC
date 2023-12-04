// Generated from c:/LocalFiles/ModernC/src/ModernCCompiler/Compiler/AntlrParsing/ModernC.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast", "CheckReturnValue"})
public class ModernCParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.13.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, T__19=20, T__20=21, T__21=22, T__22=23, T__23=24, 
		T__24=25, T__25=26, T__26=27, T__27=28, VOID_TYPE=29, INT_TYPE=30, BYTE_TYPE=31, 
		FLOAT_TYPE=32, BOOL_TYPE=33, ARR=34, FUNC=35, PRINT=36, PRINTLN=37, READ=38, 
		IF=39, ELIF=40, ELSE=41, WHILE=42, DO=43, FOR=44, BREAK=45, CONTINUE=46, 
		RETURN=47, OK=48, EXIT=49, NOT=50, OR=51, AND=52, STRUCT=53, TRUE=54, 
		FALSE=55, FLOAT=56, INT=57, ID=58, ASCII_CHAR=59, ESCAPED_ASCII_CHAR=60, 
		COMMENT=61, WHITESPACE=62, NEWLINE=63;
	public static final int
		RULE_program = 0, RULE_topLevelStatement = 1, RULE_functionDefinition = 2, 
		RULE_parameterList = 3, RULE_parameter = 4, RULE_definition = 5, RULE_structDefinition = 6, 
		RULE_structFieldDefinition = 7, RULE_type = 8, RULE_primitiveType = 9, 
		RULE_functionType = 10, RULE_userDefinedType = 11, RULE_typeList = 12, 
		RULE_statement = 13, RULE_simpleStatement = 14, RULE_compoundStatement = 15, 
		RULE_printStatement = 16, RULE_printlnStatement = 17, RULE_variableDefinitionStatement = 18, 
		RULE_variableDefinitionAndAssignmentStatement = 19, RULE_assignmentStatement = 20, 
		RULE_incrementStatement = 21, RULE_callStatement = 22, RULE_ifStatement = 23, 
		RULE_elifPart = 24, RULE_elsePart = 25, RULE_whileStatement = 26, RULE_doWhileStatement = 27, 
		RULE_forStatement = 28, RULE_breakStatement = 29, RULE_continueStatement = 30, 
		RULE_returnStatement = 31, RULE_exitStatement = 32, RULE_expression = 33, 
		RULE_orExpression = 34, RULE_andExpression = 35, RULE_comparison = 36, 
		RULE_term = 37, RULE_factor = 38, RULE_unaryExpression = 39, RULE_tailedExpression = 40, 
		RULE_callExpressionTail = 41, RULE_argumentList = 42, RULE_arrayExpressionTail = 43, 
		RULE_fieldAccessExpressionTail = 44, RULE_readExpression = 45, RULE_intLiteral = 46, 
		RULE_byteLiteral = 47, RULE_floatLiteral = 48, RULE_boolLiteral = 49, 
		RULE_idExpression = 50, RULE_arrayLiteral = 51, RULE_expressionList = 52, 
		RULE_id = 53;
	private static String[] makeRuleNames() {
		return new String[] {
			"program", "topLevelStatement", "functionDefinition", "parameterList", 
			"parameter", "definition", "structDefinition", "structFieldDefinition", 
			"type", "primitiveType", "functionType", "userDefinedType", "typeList", 
			"statement", "simpleStatement", "compoundStatement", "printStatement", 
			"printlnStatement", "variableDefinitionStatement", "variableDefinitionAndAssignmentStatement", 
			"assignmentStatement", "incrementStatement", "callStatement", "ifStatement", 
			"elifPart", "elsePart", "whileStatement", "doWhileStatement", "forStatement", 
			"breakStatement", "continueStatement", "returnStatement", "exitStatement", 
			"expression", "orExpression", "andExpression", "comparison", "term", 
			"factor", "unaryExpression", "tailedExpression", "callExpressionTail", 
			"argumentList", "arrayExpressionTail", "fieldAccessExpressionTail", "readExpression", 
			"intLiteral", "byteLiteral", "floatLiteral", "boolLiteral", "idExpression", 
			"arrayLiteral", "expressionList", "id"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "';'", "'('", "')'", "','", "'{'", "'}'", "'='", "'['", "']'", 
			"'+='", "'-='", "'*='", "'/='", "'%='", "'++'", "'--'", "'=='", "'!='", 
			"'<'", "'<='", "'>'", "'>='", "'+'", "'-'", "'*'", "'/'", "'%'", "'.'", 
			"'void'", "'int'", "'byte'", "'float'", "'bool'", "'arr'", "'func'", 
			"'print'", "'println'", "'read'", "'if'", "'elif'", "'else'", "'while'", 
			"'do'", "'for'", "'break'", "'continue'", "'return'", "'ok'", "'exit'", 
			"'not'", "'or'", "'and'", "'struct'", "'true'", "'false'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, "VOID_TYPE", "INT_TYPE", "BYTE_TYPE", "FLOAT_TYPE", 
			"BOOL_TYPE", "ARR", "FUNC", "PRINT", "PRINTLN", "READ", "IF", "ELIF", 
			"ELSE", "WHILE", "DO", "FOR", "BREAK", "CONTINUE", "RETURN", "OK", "EXIT", 
			"NOT", "OR", "AND", "STRUCT", "TRUE", "FALSE", "FLOAT", "INT", "ID", 
			"ASCII_CHAR", "ESCAPED_ASCII_CHAR", "COMMENT", "WHITESPACE", "NEWLINE"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "ModernC.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public ModernCParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ProgramContext extends ParserRuleContext {
		public TerminalNode EOF() { return getToken(ModernCParser.EOF, 0); }
		public List<TopLevelStatementContext> topLevelStatement() {
			return getRuleContexts(TopLevelStatementContext.class);
		}
		public TopLevelStatementContext topLevelStatement(int i) {
			return getRuleContext(TopLevelStatementContext.class,i);
		}
		public List<DefinitionContext> definition() {
			return getRuleContexts(DefinitionContext.class);
		}
		public DefinitionContext definition(int i) {
			return getRuleContext(DefinitionContext.class,i);
		}
		public List<FunctionDefinitionContext> functionDefinition() {
			return getRuleContexts(FunctionDefinitionContext.class);
		}
		public FunctionDefinitionContext functionDefinition(int i) {
			return getRuleContext(FunctionDefinitionContext.class,i);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_program; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterProgram(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitProgram(this);
		}
	}

	public final ProgramContext program() throws RecognitionException {
		ProgramContext _localctx = new ProgramContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(113);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 297237626409189376L) != 0)) {
				{
				setState(111);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,0,_ctx) ) {
				case 1:
					{
					setState(108);
					topLevelStatement();
					}
					break;
				case 2:
					{
					setState(109);
					definition();
					}
					break;
				case 3:
					{
					setState(110);
					functionDefinition();
					}
					break;
				}
				}
				setState(115);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(116);
			match(EOF);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class TopLevelStatementContext extends ParserRuleContext {
		public VariableDefinitionStatementContext variableDefinitionStatement() {
			return getRuleContext(VariableDefinitionStatementContext.class,0);
		}
		public VariableDefinitionAndAssignmentStatementContext variableDefinitionAndAssignmentStatement() {
			return getRuleContext(VariableDefinitionAndAssignmentStatementContext.class,0);
		}
		public TopLevelStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_topLevelStatement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterTopLevelStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitTopLevelStatement(this);
		}
	}

	public final TopLevelStatementContext topLevelStatement() throws RecognitionException {
		TopLevelStatementContext _localctx = new TopLevelStatementContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_topLevelStatement);
		try {
			setState(124);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,2,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(118);
				variableDefinitionStatement();
				setState(119);
				match(T__0);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(121);
				variableDefinitionAndAssignmentStatement();
				setState(122);
				match(T__0);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class FunctionDefinitionContext extends ParserRuleContext {
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public IdContext id() {
			return getRuleContext(IdContext.class,0);
		}
		public CompoundStatementContext compoundStatement() {
			return getRuleContext(CompoundStatementContext.class,0);
		}
		public ParameterListContext parameterList() {
			return getRuleContext(ParameterListContext.class,0);
		}
		public FunctionDefinitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionDefinition; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterFunctionDefinition(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitFunctionDefinition(this);
		}
	}

	public final FunctionDefinitionContext functionDefinition() throws RecognitionException {
		FunctionDefinitionContext _localctx = new FunctionDefinitionContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_functionDefinition);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(126);
			type(0);
			setState(127);
			id();
			setState(128);
			match(T__1);
			setState(130);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 288230427154448384L) != 0)) {
				{
				setState(129);
				parameterList();
				}
			}

			setState(132);
			match(T__2);
			setState(133);
			compoundStatement();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ParameterListContext extends ParserRuleContext {
		public List<ParameterContext> parameter() {
			return getRuleContexts(ParameterContext.class);
		}
		public ParameterContext parameter(int i) {
			return getRuleContext(ParameterContext.class,i);
		}
		public ParameterListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_parameterList; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterParameterList(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitParameterList(this);
		}
	}

	public final ParameterListContext parameterList() throws RecognitionException {
		ParameterListContext _localctx = new ParameterListContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_parameterList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(135);
			parameter();
			setState(140);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__3) {
				{
				{
				setState(136);
				match(T__3);
				setState(137);
				parameter();
				}
				}
				setState(142);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ParameterContext extends ParserRuleContext {
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public IdContext id() {
			return getRuleContext(IdContext.class,0);
		}
		public ParameterContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_parameter; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterParameter(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitParameter(this);
		}
	}

	public final ParameterContext parameter() throws RecognitionException {
		ParameterContext _localctx = new ParameterContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_parameter);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(143);
			type(0);
			setState(144);
			id();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class DefinitionContext extends ParserRuleContext {
		public StructDefinitionContext structDefinition() {
			return getRuleContext(StructDefinitionContext.class,0);
		}
		public DefinitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_definition; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterDefinition(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitDefinition(this);
		}
	}

	public final DefinitionContext definition() throws RecognitionException {
		DefinitionContext _localctx = new DefinitionContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_definition);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(146);
			structDefinition();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class StructDefinitionContext extends ParserRuleContext {
		public TerminalNode STRUCT() { return getToken(ModernCParser.STRUCT, 0); }
		public UserDefinedTypeContext userDefinedType() {
			return getRuleContext(UserDefinedTypeContext.class,0);
		}
		public List<StructFieldDefinitionContext> structFieldDefinition() {
			return getRuleContexts(StructFieldDefinitionContext.class);
		}
		public StructFieldDefinitionContext structFieldDefinition(int i) {
			return getRuleContext(StructFieldDefinitionContext.class,i);
		}
		public StructDefinitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_structDefinition; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterStructDefinition(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitStructDefinition(this);
		}
	}

	public final StructDefinitionContext structDefinition() throws RecognitionException {
		StructDefinitionContext _localctx = new StructDefinitionContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_structDefinition);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(148);
			match(STRUCT);
			setState(149);
			userDefinedType();
			setState(150);
			match(T__4);
			setState(152); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(151);
				structFieldDefinition();
				}
				}
				setState(154); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & 288230427154448384L) != 0) );
			setState(156);
			match(T__5);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class StructFieldDefinitionContext extends ParserRuleContext {
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public IdContext id() {
			return getRuleContext(IdContext.class,0);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public StructFieldDefinitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_structFieldDefinition; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterStructFieldDefinition(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitStructFieldDefinition(this);
		}
	}

	public final StructFieldDefinitionContext structFieldDefinition() throws RecognitionException {
		StructFieldDefinitionContext _localctx = new StructFieldDefinitionContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_structFieldDefinition);
		try {
			setState(168);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,6,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(158);
				type(0);
				setState(159);
				id();
				setState(160);
				match(T__0);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(162);
				type(0);
				setState(163);
				id();
				setState(164);
				match(T__6);
				setState(165);
				expression(0);
				setState(166);
				match(T__0);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class TypeContext extends ParserRuleContext {
		public TerminalNode VOID_TYPE() { return getToken(ModernCParser.VOID_TYPE, 0); }
		public PrimitiveTypeContext primitiveType() {
			return getRuleContext(PrimitiveTypeContext.class,0);
		}
		public FunctionTypeContext functionType() {
			return getRuleContext(FunctionTypeContext.class,0);
		}
		public UserDefinedTypeContext userDefinedType() {
			return getRuleContext(UserDefinedTypeContext.class,0);
		}
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public IntLiteralContext intLiteral() {
			return getRuleContext(IntLiteralContext.class,0);
		}
		public TypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_type; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterType(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitType(this);
		}
	}

	public final TypeContext type() throws RecognitionException {
		return type(0);
	}

	private TypeContext type(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		TypeContext _localctx = new TypeContext(_ctx, _parentState);
		TypeContext _prevctx = _localctx;
		int _startState = 16;
		enterRecursionRule(_localctx, 16, RULE_type, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(175);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case VOID_TYPE:
				{
				setState(171);
				match(VOID_TYPE);
				}
				break;
			case INT_TYPE:
			case BYTE_TYPE:
			case FLOAT_TYPE:
			case BOOL_TYPE:
				{
				setState(172);
				primitiveType();
				}
				break;
			case FUNC:
				{
				setState(173);
				functionType();
				}
				break;
			case ID:
				{
				setState(174);
				userDefinedType();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			_ctx.stop = _input.LT(-1);
			setState(184);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,8,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new TypeContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_type);
					setState(177);
					if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
					setState(178);
					match(T__7);
					setState(179);
					intLiteral();
					setState(180);
					match(T__8);
					}
					} 
				}
				setState(186);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,8,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class PrimitiveTypeContext extends ParserRuleContext {
		public TerminalNode INT_TYPE() { return getToken(ModernCParser.INT_TYPE, 0); }
		public TerminalNode BYTE_TYPE() { return getToken(ModernCParser.BYTE_TYPE, 0); }
		public TerminalNode FLOAT_TYPE() { return getToken(ModernCParser.FLOAT_TYPE, 0); }
		public TerminalNode BOOL_TYPE() { return getToken(ModernCParser.BOOL_TYPE, 0); }
		public PrimitiveTypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_primitiveType; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterPrimitiveType(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitPrimitiveType(this);
		}
	}

	public final PrimitiveTypeContext primitiveType() throws RecognitionException {
		PrimitiveTypeContext _localctx = new PrimitiveTypeContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_primitiveType);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(187);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 16106127360L) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class FunctionTypeContext extends ParserRuleContext {
		public TerminalNode FUNC() { return getToken(ModernCParser.FUNC, 0); }
		public TypeListContext typeList() {
			return getRuleContext(TypeListContext.class,0);
		}
		public FunctionTypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionType; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterFunctionType(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitFunctionType(this);
		}
	}

	public final FunctionTypeContext functionType() throws RecognitionException {
		FunctionTypeContext _localctx = new FunctionTypeContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_functionType);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(189);
			match(FUNC);
			setState(190);
			match(T__1);
			setState(191);
			typeList();
			setState(192);
			match(T__2);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class UserDefinedTypeContext extends ParserRuleContext {
		public IdContext id() {
			return getRuleContext(IdContext.class,0);
		}
		public UserDefinedTypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_userDefinedType; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterUserDefinedType(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitUserDefinedType(this);
		}
	}

	public final UserDefinedTypeContext userDefinedType() throws RecognitionException {
		UserDefinedTypeContext _localctx = new UserDefinedTypeContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_userDefinedType);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(194);
			id();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class TypeListContext extends ParserRuleContext {
		public List<TypeContext> type() {
			return getRuleContexts(TypeContext.class);
		}
		public TypeContext type(int i) {
			return getRuleContext(TypeContext.class,i);
		}
		public TypeListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_typeList; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterTypeList(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitTypeList(this);
		}
	}

	public final TypeListContext typeList() throws RecognitionException {
		TypeListContext _localctx = new TypeListContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_typeList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(196);
			type(0);
			setState(201);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__3) {
				{
				{
				setState(197);
				match(T__3);
				setState(198);
				type(0);
				}
				}
				setState(203);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class StatementContext extends ParserRuleContext {
		public SimpleStatementContext simpleStatement() {
			return getRuleContext(SimpleStatementContext.class,0);
		}
		public BreakStatementContext breakStatement() {
			return getRuleContext(BreakStatementContext.class,0);
		}
		public ContinueStatementContext continueStatement() {
			return getRuleContext(ContinueStatementContext.class,0);
		}
		public ReturnStatementContext returnStatement() {
			return getRuleContext(ReturnStatementContext.class,0);
		}
		public ExitStatementContext exitStatement() {
			return getRuleContext(ExitStatementContext.class,0);
		}
		public IfStatementContext ifStatement() {
			return getRuleContext(IfStatementContext.class,0);
		}
		public WhileStatementContext whileStatement() {
			return getRuleContext(WhileStatementContext.class,0);
		}
		public DoWhileStatementContext doWhileStatement() {
			return getRuleContext(DoWhileStatementContext.class,0);
		}
		public ForStatementContext forStatement() {
			return getRuleContext(ForStatementContext.class,0);
		}
		public CompoundStatementContext compoundStatement() {
			return getRuleContext(CompoundStatementContext.class,0);
		}
		public StatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitStatement(this);
		}
	}

	public final StatementContext statement() throws RecognitionException {
		StatementContext _localctx = new StatementContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_statement);
		try {
			setState(216);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__1:
			case T__23:
			case VOID_TYPE:
			case INT_TYPE:
			case BYTE_TYPE:
			case FLOAT_TYPE:
			case BOOL_TYPE:
			case FUNC:
			case PRINT:
			case PRINTLN:
			case READ:
			case NOT:
			case TRUE:
			case FALSE:
			case FLOAT:
			case INT:
			case ID:
			case ASCII_CHAR:
			case ESCAPED_ASCII_CHAR:
				enterOuterAlt(_localctx, 1);
				{
				setState(204);
				simpleStatement();
				setState(205);
				match(T__0);
				}
				break;
			case BREAK:
				enterOuterAlt(_localctx, 2);
				{
				setState(207);
				breakStatement();
				}
				break;
			case CONTINUE:
				enterOuterAlt(_localctx, 3);
				{
				setState(208);
				continueStatement();
				}
				break;
			case RETURN:
			case OK:
				enterOuterAlt(_localctx, 4);
				{
				setState(209);
				returnStatement();
				}
				break;
			case EXIT:
				enterOuterAlt(_localctx, 5);
				{
				setState(210);
				exitStatement();
				}
				break;
			case IF:
				enterOuterAlt(_localctx, 6);
				{
				setState(211);
				ifStatement();
				}
				break;
			case WHILE:
				enterOuterAlt(_localctx, 7);
				{
				setState(212);
				whileStatement();
				}
				break;
			case DO:
				enterOuterAlt(_localctx, 8);
				{
				setState(213);
				doWhileStatement();
				}
				break;
			case FOR:
				enterOuterAlt(_localctx, 9);
				{
				setState(214);
				forStatement();
				}
				break;
			case T__4:
				enterOuterAlt(_localctx, 10);
				{
				setState(215);
				compoundStatement();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class SimpleStatementContext extends ParserRuleContext {
		public PrintStatementContext printStatement() {
			return getRuleContext(PrintStatementContext.class,0);
		}
		public PrintlnStatementContext printlnStatement() {
			return getRuleContext(PrintlnStatementContext.class,0);
		}
		public VariableDefinitionStatementContext variableDefinitionStatement() {
			return getRuleContext(VariableDefinitionStatementContext.class,0);
		}
		public AssignmentStatementContext assignmentStatement() {
			return getRuleContext(AssignmentStatementContext.class,0);
		}
		public IncrementStatementContext incrementStatement() {
			return getRuleContext(IncrementStatementContext.class,0);
		}
		public VariableDefinitionAndAssignmentStatementContext variableDefinitionAndAssignmentStatement() {
			return getRuleContext(VariableDefinitionAndAssignmentStatementContext.class,0);
		}
		public CallStatementContext callStatement() {
			return getRuleContext(CallStatementContext.class,0);
		}
		public SimpleStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_simpleStatement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterSimpleStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitSimpleStatement(this);
		}
	}

	public final SimpleStatementContext simpleStatement() throws RecognitionException {
		SimpleStatementContext _localctx = new SimpleStatementContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_simpleStatement);
		try {
			setState(225);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,11,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(218);
				printStatement();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(219);
				printlnStatement();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(220);
				variableDefinitionStatement();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(221);
				assignmentStatement();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(222);
				incrementStatement();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(223);
				variableDefinitionAndAssignmentStatement();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(224);
				callStatement();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class CompoundStatementContext extends ParserRuleContext {
		public List<StatementContext> statement() {
			return getRuleContexts(StatementContext.class);
		}
		public StatementContext statement(int i) {
			return getRuleContext(StatementContext.class,i);
		}
		public CompoundStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_compoundStatement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterCompoundStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitCompoundStatement(this);
		}
	}

	public final CompoundStatementContext compoundStatement() throws RecognitionException {
		CompoundStatementContext _localctx = new CompoundStatementContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_compoundStatement);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(227);
			match(T__4);
			setState(231);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 2290077094283051044L) != 0)) {
				{
				{
				setState(228);
				statement();
				}
				}
				setState(233);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(234);
			match(T__5);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class PrintStatementContext extends ParserRuleContext {
		public TerminalNode PRINT() { return getToken(ModernCParser.PRINT, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public PrintStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_printStatement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterPrintStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitPrintStatement(this);
		}
	}

	public final PrintStatementContext printStatement() throws RecognitionException {
		PrintStatementContext _localctx = new PrintStatementContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_printStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(236);
			match(PRINT);
			setState(237);
			expression(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class PrintlnStatementContext extends ParserRuleContext {
		public TerminalNode PRINTLN() { return getToken(ModernCParser.PRINTLN, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public PrintlnStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_printlnStatement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterPrintlnStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitPrintlnStatement(this);
		}
	}

	public final PrintlnStatementContext printlnStatement() throws RecognitionException {
		PrintlnStatementContext _localctx = new PrintlnStatementContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_printlnStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(239);
			match(PRINTLN);
			setState(240);
			expression(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class VariableDefinitionStatementContext extends ParserRuleContext {
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public IdContext id() {
			return getRuleContext(IdContext.class,0);
		}
		public VariableDefinitionStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_variableDefinitionStatement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterVariableDefinitionStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitVariableDefinitionStatement(this);
		}
	}

	public final VariableDefinitionStatementContext variableDefinitionStatement() throws RecognitionException {
		VariableDefinitionStatementContext _localctx = new VariableDefinitionStatementContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_variableDefinitionStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(242);
			type(0);
			setState(243);
			id();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class VariableDefinitionAndAssignmentStatementContext extends ParserRuleContext {
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public IdContext id() {
			return getRuleContext(IdContext.class,0);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public ArrayLiteralContext arrayLiteral() {
			return getRuleContext(ArrayLiteralContext.class,0);
		}
		public VariableDefinitionAndAssignmentStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_variableDefinitionAndAssignmentStatement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterVariableDefinitionAndAssignmentStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitVariableDefinitionAndAssignmentStatement(this);
		}
	}

	public final VariableDefinitionAndAssignmentStatementContext variableDefinitionAndAssignmentStatement() throws RecognitionException {
		VariableDefinitionAndAssignmentStatementContext _localctx = new VariableDefinitionAndAssignmentStatementContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_variableDefinitionAndAssignmentStatement);
		try {
			setState(255);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,13,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(245);
				type(0);
				setState(246);
				id();
				setState(247);
				match(T__6);
				setState(248);
				expression(0);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(250);
				type(0);
				setState(251);
				id();
				setState(252);
				match(T__6);
				setState(253);
				arrayLiteral();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class AssignmentStatementContext extends ParserRuleContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public ArrayLiteralContext arrayLiteral() {
			return getRuleContext(ArrayLiteralContext.class,0);
		}
		public AssignmentStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_assignmentStatement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterAssignmentStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitAssignmentStatement(this);
		}
	}

	public final AssignmentStatementContext assignmentStatement() throws RecognitionException {
		AssignmentStatementContext _localctx = new AssignmentStatementContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_assignmentStatement);
		int _la;
		try {
			setState(265);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,14,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(257);
				expression(0);
				setState(258);
				_la = _input.LA(1);
				if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 31872L) != 0)) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(259);
				expression(0);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(261);
				expression(0);
				setState(262);
				match(T__6);
				setState(263);
				arrayLiteral();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class IncrementStatementContext extends ParserRuleContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public IncrementStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_incrementStatement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterIncrementStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitIncrementStatement(this);
		}
	}

	public final IncrementStatementContext incrementStatement() throws RecognitionException {
		IncrementStatementContext _localctx = new IncrementStatementContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_incrementStatement);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(267);
			expression(0);
			setState(268);
			_la = _input.LA(1);
			if ( !(_la==T__14 || _la==T__15) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class CallStatementContext extends ParserRuleContext {
		public TailedExpressionContext tailedExpression() {
			return getRuleContext(TailedExpressionContext.class,0);
		}
		public CallStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_callStatement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterCallStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitCallStatement(this);
		}
	}

	public final CallStatementContext callStatement() throws RecognitionException {
		CallStatementContext _localctx = new CallStatementContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_callStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(270);
			tailedExpression(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class IfStatementContext extends ParserRuleContext {
		public TerminalNode IF() { return getToken(ModernCParser.IF, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public CompoundStatementContext compoundStatement() {
			return getRuleContext(CompoundStatementContext.class,0);
		}
		public List<ElifPartContext> elifPart() {
			return getRuleContexts(ElifPartContext.class);
		}
		public ElifPartContext elifPart(int i) {
			return getRuleContext(ElifPartContext.class,i);
		}
		public ElsePartContext elsePart() {
			return getRuleContext(ElsePartContext.class,0);
		}
		public IfStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_ifStatement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterIfStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitIfStatement(this);
		}
	}

	public final IfStatementContext ifStatement() throws RecognitionException {
		IfStatementContext _localctx = new IfStatementContext(_ctx, getState());
		enterRule(_localctx, 46, RULE_ifStatement);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(272);
			match(IF);
			setState(273);
			expression(0);
			setState(274);
			compoundStatement();
			setState(278);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==ELIF) {
				{
				{
				setState(275);
				elifPart();
				}
				}
				setState(280);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(282);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ELSE) {
				{
				setState(281);
				elsePart();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ElifPartContext extends ParserRuleContext {
		public TerminalNode ELIF() { return getToken(ModernCParser.ELIF, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public CompoundStatementContext compoundStatement() {
			return getRuleContext(CompoundStatementContext.class,0);
		}
		public ElifPartContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_elifPart; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterElifPart(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitElifPart(this);
		}
	}

	public final ElifPartContext elifPart() throws RecognitionException {
		ElifPartContext _localctx = new ElifPartContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_elifPart);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(284);
			match(ELIF);
			setState(285);
			expression(0);
			setState(286);
			compoundStatement();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ElsePartContext extends ParserRuleContext {
		public TerminalNode ELSE() { return getToken(ModernCParser.ELSE, 0); }
		public CompoundStatementContext compoundStatement() {
			return getRuleContext(CompoundStatementContext.class,0);
		}
		public ElsePartContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_elsePart; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterElsePart(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitElsePart(this);
		}
	}

	public final ElsePartContext elsePart() throws RecognitionException {
		ElsePartContext _localctx = new ElsePartContext(_ctx, getState());
		enterRule(_localctx, 50, RULE_elsePart);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(288);
			match(ELSE);
			setState(289);
			compoundStatement();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class WhileStatementContext extends ParserRuleContext {
		public TerminalNode WHILE() { return getToken(ModernCParser.WHILE, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public CompoundStatementContext compoundStatement() {
			return getRuleContext(CompoundStatementContext.class,0);
		}
		public WhileStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_whileStatement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterWhileStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitWhileStatement(this);
		}
	}

	public final WhileStatementContext whileStatement() throws RecognitionException {
		WhileStatementContext _localctx = new WhileStatementContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_whileStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(291);
			match(WHILE);
			setState(292);
			expression(0);
			setState(293);
			compoundStatement();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class DoWhileStatementContext extends ParserRuleContext {
		public TerminalNode DO() { return getToken(ModernCParser.DO, 0); }
		public CompoundStatementContext compoundStatement() {
			return getRuleContext(CompoundStatementContext.class,0);
		}
		public TerminalNode WHILE() { return getToken(ModernCParser.WHILE, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public DoWhileStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_doWhileStatement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterDoWhileStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitDoWhileStatement(this);
		}
	}

	public final DoWhileStatementContext doWhileStatement() throws RecognitionException {
		DoWhileStatementContext _localctx = new DoWhileStatementContext(_ctx, getState());
		enterRule(_localctx, 54, RULE_doWhileStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(295);
			match(DO);
			setState(296);
			compoundStatement();
			setState(297);
			match(WHILE);
			setState(298);
			expression(0);
			setState(299);
			match(T__0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ForStatementContext extends ParserRuleContext {
		public TerminalNode FOR() { return getToken(ModernCParser.FOR, 0); }
		public List<SimpleStatementContext> simpleStatement() {
			return getRuleContexts(SimpleStatementContext.class);
		}
		public SimpleStatementContext simpleStatement(int i) {
			return getRuleContext(SimpleStatementContext.class,i);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public CompoundStatementContext compoundStatement() {
			return getRuleContext(CompoundStatementContext.class,0);
		}
		public ForStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_forStatement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterForStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitForStatement(this);
		}
	}

	public final ForStatementContext forStatement() throws RecognitionException {
		ForStatementContext _localctx = new ForStatementContext(_ctx, getState());
		enterRule(_localctx, 56, RULE_forStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(301);
			match(FOR);
			setState(302);
			simpleStatement();
			setState(303);
			match(T__0);
			setState(304);
			expression(0);
			setState(305);
			match(T__0);
			setState(306);
			simpleStatement();
			setState(307);
			compoundStatement();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class BreakStatementContext extends ParserRuleContext {
		public TerminalNode BREAK() { return getToken(ModernCParser.BREAK, 0); }
		public BreakStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_breakStatement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterBreakStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitBreakStatement(this);
		}
	}

	public final BreakStatementContext breakStatement() throws RecognitionException {
		BreakStatementContext _localctx = new BreakStatementContext(_ctx, getState());
		enterRule(_localctx, 58, RULE_breakStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(309);
			match(BREAK);
			setState(310);
			match(T__0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ContinueStatementContext extends ParserRuleContext {
		public TerminalNode CONTINUE() { return getToken(ModernCParser.CONTINUE, 0); }
		public ContinueStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_continueStatement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterContinueStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitContinueStatement(this);
		}
	}

	public final ContinueStatementContext continueStatement() throws RecognitionException {
		ContinueStatementContext _localctx = new ContinueStatementContext(_ctx, getState());
		enterRule(_localctx, 60, RULE_continueStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(312);
			match(CONTINUE);
			setState(313);
			match(T__0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ReturnStatementContext extends ParserRuleContext {
		public TerminalNode RETURN() { return getToken(ModernCParser.RETURN, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode OK() { return getToken(ModernCParser.OK, 0); }
		public ReturnStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_returnStatement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterReturnStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitReturnStatement(this);
		}
	}

	public final ReturnStatementContext returnStatement() throws RecognitionException {
		ReturnStatementContext _localctx = new ReturnStatementContext(_ctx, getState());
		enterRule(_localctx, 62, RULE_returnStatement);
		int _la;
		try {
			setState(322);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case RETURN:
				enterOuterAlt(_localctx, 1);
				{
				setState(315);
				match(RETURN);
				setState(317);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 2288954785505738756L) != 0)) {
					{
					setState(316);
					expression(0);
					}
				}

				setState(319);
				match(T__0);
				}
				break;
			case OK:
				enterOuterAlt(_localctx, 2);
				{
				setState(320);
				match(OK);
				setState(321);
				match(T__0);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ExitStatementContext extends ParserRuleContext {
		public TerminalNode EXIT() { return getToken(ModernCParser.EXIT, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public ExitStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_exitStatement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterExitStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitExitStatement(this);
		}
	}

	public final ExitStatementContext exitStatement() throws RecognitionException {
		ExitStatementContext _localctx = new ExitStatementContext(_ctx, getState());
		enterRule(_localctx, 64, RULE_exitStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(324);
			match(EXIT);
			setState(325);
			expression(0);
			setState(326);
			match(T__0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ExpressionContext extends ParserRuleContext {
		public OrExpressionContext orExpression() {
			return getRuleContext(OrExpressionContext.class,0);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode OR() { return getToken(ModernCParser.OR, 0); }
		public ExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitExpression(this);
		}
	}

	public final ExpressionContext expression() throws RecognitionException {
		return expression(0);
	}

	private ExpressionContext expression(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		ExpressionContext _localctx = new ExpressionContext(_ctx, _parentState);
		ExpressionContext _prevctx = _localctx;
		int _startState = 66;
		enterRecursionRule(_localctx, 66, RULE_expression, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(329);
			orExpression(0);
			}
			_ctx.stop = _input.LT(-1);
			setState(336);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,19,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new ExpressionContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_expression);
					setState(331);
					if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
					setState(332);
					match(OR);
					setState(333);
					orExpression(0);
					}
					} 
				}
				setState(338);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,19,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class OrExpressionContext extends ParserRuleContext {
		public AndExpressionContext andExpression() {
			return getRuleContext(AndExpressionContext.class,0);
		}
		public OrExpressionContext orExpression() {
			return getRuleContext(OrExpressionContext.class,0);
		}
		public TerminalNode AND() { return getToken(ModernCParser.AND, 0); }
		public OrExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_orExpression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterOrExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitOrExpression(this);
		}
	}

	public final OrExpressionContext orExpression() throws RecognitionException {
		return orExpression(0);
	}

	private OrExpressionContext orExpression(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		OrExpressionContext _localctx = new OrExpressionContext(_ctx, _parentState);
		OrExpressionContext _prevctx = _localctx;
		int _startState = 68;
		enterRecursionRule(_localctx, 68, RULE_orExpression, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(340);
			andExpression(0);
			}
			_ctx.stop = _input.LT(-1);
			setState(347);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,20,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new OrExpressionContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_orExpression);
					setState(342);
					if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
					setState(343);
					match(AND);
					setState(344);
					andExpression(0);
					}
					} 
				}
				setState(349);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,20,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class AndExpressionContext extends ParserRuleContext {
		public ComparisonContext comparison() {
			return getRuleContext(ComparisonContext.class,0);
		}
		public AndExpressionContext andExpression() {
			return getRuleContext(AndExpressionContext.class,0);
		}
		public AndExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_andExpression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterAndExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitAndExpression(this);
		}
	}

	public final AndExpressionContext andExpression() throws RecognitionException {
		return andExpression(0);
	}

	private AndExpressionContext andExpression(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		AndExpressionContext _localctx = new AndExpressionContext(_ctx, _parentState);
		AndExpressionContext _prevctx = _localctx;
		int _startState = 70;
		enterRecursionRule(_localctx, 70, RULE_andExpression, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(351);
			comparison(0);
			}
			_ctx.stop = _input.LT(-1);
			setState(358);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,21,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new AndExpressionContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_andExpression);
					setState(353);
					if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
					setState(354);
					_la = _input.LA(1);
					if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 8257536L) != 0)) ) {
					_errHandler.recoverInline(this);
					}
					else {
						if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
						_errHandler.reportMatch(this);
						consume();
					}
					setState(355);
					comparison(0);
					}
					} 
				}
				setState(360);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,21,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ComparisonContext extends ParserRuleContext {
		public TermContext term() {
			return getRuleContext(TermContext.class,0);
		}
		public ComparisonContext comparison() {
			return getRuleContext(ComparisonContext.class,0);
		}
		public ComparisonContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_comparison; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterComparison(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitComparison(this);
		}
	}

	public final ComparisonContext comparison() throws RecognitionException {
		return comparison(0);
	}

	private ComparisonContext comparison(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		ComparisonContext _localctx = new ComparisonContext(_ctx, _parentState);
		ComparisonContext _prevctx = _localctx;
		int _startState = 72;
		enterRecursionRule(_localctx, 72, RULE_comparison, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(362);
			term(0);
			}
			_ctx.stop = _input.LT(-1);
			setState(369);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,22,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new ComparisonContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_comparison);
					setState(364);
					if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
					setState(365);
					_la = _input.LA(1);
					if ( !(_la==T__22 || _la==T__23) ) {
					_errHandler.recoverInline(this);
					}
					else {
						if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
						_errHandler.reportMatch(this);
						consume();
					}
					setState(366);
					term(0);
					}
					} 
				}
				setState(371);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,22,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class TermContext extends ParserRuleContext {
		public FactorContext factor() {
			return getRuleContext(FactorContext.class,0);
		}
		public TermContext term() {
			return getRuleContext(TermContext.class,0);
		}
		public TermContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_term; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterTerm(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitTerm(this);
		}
	}

	public final TermContext term() throws RecognitionException {
		return term(0);
	}

	private TermContext term(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		TermContext _localctx = new TermContext(_ctx, _parentState);
		TermContext _prevctx = _localctx;
		int _startState = 74;
		enterRecursionRule(_localctx, 74, RULE_term, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(373);
			factor();
			}
			_ctx.stop = _input.LT(-1);
			setState(380);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,23,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new TermContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_term);
					setState(375);
					if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
					setState(376);
					_la = _input.LA(1);
					if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 234881024L) != 0)) ) {
					_errHandler.recoverInline(this);
					}
					else {
						if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
						_errHandler.reportMatch(this);
						consume();
					}
					setState(377);
					factor();
					}
					} 
				}
				setState(382);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,23,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class FactorContext extends ParserRuleContext {
		public UnaryExpressionContext unaryExpression() {
			return getRuleContext(UnaryExpressionContext.class,0);
		}
		public TailedExpressionContext tailedExpression() {
			return getRuleContext(TailedExpressionContext.class,0);
		}
		public ReadExpressionContext readExpression() {
			return getRuleContext(ReadExpressionContext.class,0);
		}
		public IntLiteralContext intLiteral() {
			return getRuleContext(IntLiteralContext.class,0);
		}
		public ByteLiteralContext byteLiteral() {
			return getRuleContext(ByteLiteralContext.class,0);
		}
		public FloatLiteralContext floatLiteral() {
			return getRuleContext(FloatLiteralContext.class,0);
		}
		public BoolLiteralContext boolLiteral() {
			return getRuleContext(BoolLiteralContext.class,0);
		}
		public IdExpressionContext idExpression() {
			return getRuleContext(IdExpressionContext.class,0);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public FactorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_factor; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterFactor(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitFactor(this);
		}
	}

	public final FactorContext factor() throws RecognitionException {
		FactorContext _localctx = new FactorContext(_ctx, getState());
		enterRule(_localctx, 76, RULE_factor);
		try {
			setState(395);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,24,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(383);
				unaryExpression();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(384);
				tailedExpression(0);
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(385);
				readExpression();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(386);
				intLiteral();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(387);
				byteLiteral();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(388);
				floatLiteral();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(389);
				boolLiteral();
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(390);
				idExpression();
				}
				break;
			case 9:
				enterOuterAlt(_localctx, 9);
				{
				setState(391);
				match(T__1);
				setState(392);
				expression(0);
				setState(393);
				match(T__2);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class UnaryExpressionContext extends ParserRuleContext {
		public FactorContext factor() {
			return getRuleContext(FactorContext.class,0);
		}
		public TerminalNode NOT() { return getToken(ModernCParser.NOT, 0); }
		public UnaryExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_unaryExpression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterUnaryExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitUnaryExpression(this);
		}
	}

	public final UnaryExpressionContext unaryExpression() throws RecognitionException {
		UnaryExpressionContext _localctx = new UnaryExpressionContext(_ctx, getState());
		enterRule(_localctx, 78, RULE_unaryExpression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(397);
			_la = _input.LA(1);
			if ( !(_la==T__23 || _la==NOT) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(398);
			factor();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class TailedExpressionContext extends ParserRuleContext {
		public IdExpressionContext idExpression() {
			return getRuleContext(IdExpressionContext.class,0);
		}
		public CallExpressionTailContext callExpressionTail() {
			return getRuleContext(CallExpressionTailContext.class,0);
		}
		public ArrayExpressionTailContext arrayExpressionTail() {
			return getRuleContext(ArrayExpressionTailContext.class,0);
		}
		public FieldAccessExpressionTailContext fieldAccessExpressionTail() {
			return getRuleContext(FieldAccessExpressionTailContext.class,0);
		}
		public TailedExpressionContext tailedExpression() {
			return getRuleContext(TailedExpressionContext.class,0);
		}
		public TailedExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_tailedExpression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterTailedExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitTailedExpression(this);
		}
	}

	public final TailedExpressionContext tailedExpression() throws RecognitionException {
		return tailedExpression(0);
	}

	private TailedExpressionContext tailedExpression(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		TailedExpressionContext _localctx = new TailedExpressionContext(_ctx, _parentState);
		TailedExpressionContext _prevctx = _localctx;
		int _startState = 80;
		enterRecursionRule(_localctx, 80, RULE_tailedExpression, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(401);
			idExpression();
			setState(405);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__1:
				{
				setState(402);
				callExpressionTail();
				}
				break;
			case T__7:
				{
				setState(403);
				arrayExpressionTail();
				}
				break;
			case T__27:
				{
				setState(404);
				fieldAccessExpressionTail();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
			_ctx.stop = _input.LT(-1);
			setState(415);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,27,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new TailedExpressionContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_tailedExpression);
					setState(407);
					if (!(precpred(_ctx, 1))) throw new FailedPredicateException(this, "precpred(_ctx, 1)");
					setState(411);
					_errHandler.sync(this);
					switch (_input.LA(1)) {
					case T__1:
						{
						setState(408);
						callExpressionTail();
						}
						break;
					case T__7:
						{
						setState(409);
						arrayExpressionTail();
						}
						break;
					case T__27:
						{
						setState(410);
						fieldAccessExpressionTail();
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					}
					} 
				}
				setState(417);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,27,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class CallExpressionTailContext extends ParserRuleContext {
		public ArgumentListContext argumentList() {
			return getRuleContext(ArgumentListContext.class,0);
		}
		public CallExpressionTailContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_callExpressionTail; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterCallExpressionTail(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitCallExpressionTail(this);
		}
	}

	public final CallExpressionTailContext callExpressionTail() throws RecognitionException {
		CallExpressionTailContext _localctx = new CallExpressionTailContext(_ctx, getState());
		enterRule(_localctx, 82, RULE_callExpressionTail);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(418);
			match(T__1);
			setState(420);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 2288954785505738756L) != 0)) {
				{
				setState(419);
				argumentList();
				}
			}

			setState(422);
			match(T__2);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ArgumentListContext extends ParserRuleContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public ArgumentListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_argumentList; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterArgumentList(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitArgumentList(this);
		}
	}

	public final ArgumentListContext argumentList() throws RecognitionException {
		ArgumentListContext _localctx = new ArgumentListContext(_ctx, getState());
		enterRule(_localctx, 84, RULE_argumentList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(424);
			expression(0);
			setState(429);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__3) {
				{
				{
				setState(425);
				match(T__3);
				setState(426);
				expression(0);
				}
				}
				setState(431);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ArrayExpressionTailContext extends ParserRuleContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public ArrayExpressionTailContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_arrayExpressionTail; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterArrayExpressionTail(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitArrayExpressionTail(this);
		}
	}

	public final ArrayExpressionTailContext arrayExpressionTail() throws RecognitionException {
		ArrayExpressionTailContext _localctx = new ArrayExpressionTailContext(_ctx, getState());
		enterRule(_localctx, 86, RULE_arrayExpressionTail);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(432);
			match(T__7);
			setState(433);
			expression(0);
			setState(434);
			match(T__8);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class FieldAccessExpressionTailContext extends ParserRuleContext {
		public IdContext id() {
			return getRuleContext(IdContext.class,0);
		}
		public FieldAccessExpressionTailContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_fieldAccessExpressionTail; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterFieldAccessExpressionTail(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitFieldAccessExpressionTail(this);
		}
	}

	public final FieldAccessExpressionTailContext fieldAccessExpressionTail() throws RecognitionException {
		FieldAccessExpressionTailContext _localctx = new FieldAccessExpressionTailContext(_ctx, getState());
		enterRule(_localctx, 88, RULE_fieldAccessExpressionTail);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(436);
			match(T__27);
			setState(437);
			id();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ReadExpressionContext extends ParserRuleContext {
		public TerminalNode READ() { return getToken(ModernCParser.READ, 0); }
		public ReadExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_readExpression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterReadExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitReadExpression(this);
		}
	}

	public final ReadExpressionContext readExpression() throws RecognitionException {
		ReadExpressionContext _localctx = new ReadExpressionContext(_ctx, getState());
		enterRule(_localctx, 90, RULE_readExpression);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(439);
			match(READ);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class IntLiteralContext extends ParserRuleContext {
		public TerminalNode INT() { return getToken(ModernCParser.INT, 0); }
		public IntLiteralContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_intLiteral; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterIntLiteral(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitIntLiteral(this);
		}
	}

	public final IntLiteralContext intLiteral() throws RecognitionException {
		IntLiteralContext _localctx = new IntLiteralContext(_ctx, getState());
		enterRule(_localctx, 92, RULE_intLiteral);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(441);
			match(INT);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ByteLiteralContext extends ParserRuleContext {
		public TerminalNode ASCII_CHAR() { return getToken(ModernCParser.ASCII_CHAR, 0); }
		public TerminalNode ESCAPED_ASCII_CHAR() { return getToken(ModernCParser.ESCAPED_ASCII_CHAR, 0); }
		public TerminalNode INT() { return getToken(ModernCParser.INT, 0); }
		public ByteLiteralContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_byteLiteral; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterByteLiteral(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitByteLiteral(this);
		}
	}

	public final ByteLiteralContext byteLiteral() throws RecognitionException {
		ByteLiteralContext _localctx = new ByteLiteralContext(_ctx, getState());
		enterRule(_localctx, 94, RULE_byteLiteral);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(443);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 1873497444986126336L) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class FloatLiteralContext extends ParserRuleContext {
		public TerminalNode FLOAT() { return getToken(ModernCParser.FLOAT, 0); }
		public TerminalNode INT() { return getToken(ModernCParser.INT, 0); }
		public FloatLiteralContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_floatLiteral; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterFloatLiteral(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitFloatLiteral(this);
		}
	}

	public final FloatLiteralContext floatLiteral() throws RecognitionException {
		FloatLiteralContext _localctx = new FloatLiteralContext(_ctx, getState());
		enterRule(_localctx, 96, RULE_floatLiteral);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(445);
			_la = _input.LA(1);
			if ( !(_la==FLOAT || _la==INT) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class BoolLiteralContext extends ParserRuleContext {
		public TerminalNode TRUE() { return getToken(ModernCParser.TRUE, 0); }
		public TerminalNode FALSE() { return getToken(ModernCParser.FALSE, 0); }
		public BoolLiteralContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_boolLiteral; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterBoolLiteral(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitBoolLiteral(this);
		}
	}

	public final BoolLiteralContext boolLiteral() throws RecognitionException {
		BoolLiteralContext _localctx = new BoolLiteralContext(_ctx, getState());
		enterRule(_localctx, 98, RULE_boolLiteral);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(447);
			_la = _input.LA(1);
			if ( !(_la==TRUE || _la==FALSE) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class IdExpressionContext extends ParserRuleContext {
		public IdContext id() {
			return getRuleContext(IdContext.class,0);
		}
		public IdExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_idExpression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterIdExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitIdExpression(this);
		}
	}

	public final IdExpressionContext idExpression() throws RecognitionException {
		IdExpressionContext _localctx = new IdExpressionContext(_ctx, getState());
		enterRule(_localctx, 100, RULE_idExpression);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(449);
			id();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ArrayLiteralContext extends ParserRuleContext {
		public ExpressionListContext expressionList() {
			return getRuleContext(ExpressionListContext.class,0);
		}
		public ArrayLiteralContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_arrayLiteral; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterArrayLiteral(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitArrayLiteral(this);
		}
	}

	public final ArrayLiteralContext arrayLiteral() throws RecognitionException {
		ArrayLiteralContext _localctx = new ArrayLiteralContext(_ctx, getState());
		enterRule(_localctx, 102, RULE_arrayLiteral);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(451);
			match(T__7);
			setState(452);
			expressionList();
			setState(453);
			match(T__8);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ExpressionListContext extends ParserRuleContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public ExpressionListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expressionList; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterExpressionList(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitExpressionList(this);
		}
	}

	public final ExpressionListContext expressionList() throws RecognitionException {
		ExpressionListContext _localctx = new ExpressionListContext(_ctx, getState());
		enterRule(_localctx, 104, RULE_expressionList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(455);
			expression(0);
			setState(460);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__3) {
				{
				{
				setState(456);
				match(T__3);
				setState(457);
				expression(0);
				}
				}
				setState(462);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class IdContext extends ParserRuleContext {
		public TerminalNode ID() { return getToken(ModernCParser.ID, 0); }
		public IdContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_id; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).enterId(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof ModernCListener ) ((ModernCListener)listener).exitId(this);
		}
	}

	public final IdContext id() throws RecognitionException {
		IdContext _localctx = new IdContext(_ctx, getState());
		enterRule(_localctx, 106, RULE_id);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(463);
			match(ID);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 8:
			return type_sempred((TypeContext)_localctx, predIndex);
		case 33:
			return expression_sempred((ExpressionContext)_localctx, predIndex);
		case 34:
			return orExpression_sempred((OrExpressionContext)_localctx, predIndex);
		case 35:
			return andExpression_sempred((AndExpressionContext)_localctx, predIndex);
		case 36:
			return comparison_sempred((ComparisonContext)_localctx, predIndex);
		case 37:
			return term_sempred((TermContext)_localctx, predIndex);
		case 40:
			return tailedExpression_sempred((TailedExpressionContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean type_sempred(TypeContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 3);
		}
		return true;
	}
	private boolean expression_sempred(ExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 1:
			return precpred(_ctx, 2);
		}
		return true;
	}
	private boolean orExpression_sempred(OrExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 2:
			return precpred(_ctx, 2);
		}
		return true;
	}
	private boolean andExpression_sempred(AndExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 3:
			return precpred(_ctx, 2);
		}
		return true;
	}
	private boolean comparison_sempred(ComparisonContext _localctx, int predIndex) {
		switch (predIndex) {
		case 4:
			return precpred(_ctx, 2);
		}
		return true;
	}
	private boolean term_sempred(TermContext _localctx, int predIndex) {
		switch (predIndex) {
		case 5:
			return precpred(_ctx, 2);
		}
		return true;
	}
	private boolean tailedExpression_sempred(TailedExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 6:
			return precpred(_ctx, 1);
		}
		return true;
	}

	public static final String _serializedATN =
		"\u0004\u0001?\u01d2\u0002\u0000\u0007\u0000\u0002\u0001\u0007\u0001\u0002"+
		"\u0002\u0007\u0002\u0002\u0003\u0007\u0003\u0002\u0004\u0007\u0004\u0002"+
		"\u0005\u0007\u0005\u0002\u0006\u0007\u0006\u0002\u0007\u0007\u0007\u0002"+
		"\b\u0007\b\u0002\t\u0007\t\u0002\n\u0007\n\u0002\u000b\u0007\u000b\u0002"+
		"\f\u0007\f\u0002\r\u0007\r\u0002\u000e\u0007\u000e\u0002\u000f\u0007\u000f"+
		"\u0002\u0010\u0007\u0010\u0002\u0011\u0007\u0011\u0002\u0012\u0007\u0012"+
		"\u0002\u0013\u0007\u0013\u0002\u0014\u0007\u0014\u0002\u0015\u0007\u0015"+
		"\u0002\u0016\u0007\u0016\u0002\u0017\u0007\u0017\u0002\u0018\u0007\u0018"+
		"\u0002\u0019\u0007\u0019\u0002\u001a\u0007\u001a\u0002\u001b\u0007\u001b"+
		"\u0002\u001c\u0007\u001c\u0002\u001d\u0007\u001d\u0002\u001e\u0007\u001e"+
		"\u0002\u001f\u0007\u001f\u0002 \u0007 \u0002!\u0007!\u0002\"\u0007\"\u0002"+
		"#\u0007#\u0002$\u0007$\u0002%\u0007%\u0002&\u0007&\u0002\'\u0007\'\u0002"+
		"(\u0007(\u0002)\u0007)\u0002*\u0007*\u0002+\u0007+\u0002,\u0007,\u0002"+
		"-\u0007-\u0002.\u0007.\u0002/\u0007/\u00020\u00070\u00021\u00071\u0002"+
		"2\u00072\u00023\u00073\u00024\u00074\u00025\u00075\u0001\u0000\u0001\u0000"+
		"\u0001\u0000\u0005\u0000p\b\u0000\n\u0000\f\u0000s\t\u0000\u0001\u0000"+
		"\u0001\u0000\u0001\u0001\u0001\u0001\u0001\u0001\u0001\u0001\u0001\u0001"+
		"\u0001\u0001\u0003\u0001}\b\u0001\u0001\u0002\u0001\u0002\u0001\u0002"+
		"\u0001\u0002\u0003\u0002\u0083\b\u0002\u0001\u0002\u0001\u0002\u0001\u0002"+
		"\u0001\u0003\u0001\u0003\u0001\u0003\u0005\u0003\u008b\b\u0003\n\u0003"+
		"\f\u0003\u008e\t\u0003\u0001\u0004\u0001\u0004\u0001\u0004\u0001\u0005"+
		"\u0001\u0005\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0006\u0004\u0006"+
		"\u0099\b\u0006\u000b\u0006\f\u0006\u009a\u0001\u0006\u0001\u0006\u0001"+
		"\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0001"+
		"\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0003\u0007\u00a9\b\u0007\u0001"+
		"\b\u0001\b\u0001\b\u0001\b\u0001\b\u0003\b\u00b0\b\b\u0001\b\u0001\b\u0001"+
		"\b\u0001\b\u0001\b\u0005\b\u00b7\b\b\n\b\f\b\u00ba\t\b\u0001\t\u0001\t"+
		"\u0001\n\u0001\n\u0001\n\u0001\n\u0001\n\u0001\u000b\u0001\u000b\u0001"+
		"\f\u0001\f\u0001\f\u0005\f\u00c8\b\f\n\f\f\f\u00cb\t\f\u0001\r\u0001\r"+
		"\u0001\r\u0001\r\u0001\r\u0001\r\u0001\r\u0001\r\u0001\r\u0001\r\u0001"+
		"\r\u0001\r\u0003\r\u00d9\b\r\u0001\u000e\u0001\u000e\u0001\u000e\u0001"+
		"\u000e\u0001\u000e\u0001\u000e\u0001\u000e\u0003\u000e\u00e2\b\u000e\u0001"+
		"\u000f\u0001\u000f\u0005\u000f\u00e6\b\u000f\n\u000f\f\u000f\u00e9\t\u000f"+
		"\u0001\u000f\u0001\u000f\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0011"+
		"\u0001\u0011\u0001\u0011\u0001\u0012\u0001\u0012\u0001\u0012\u0001\u0013"+
		"\u0001\u0013\u0001\u0013\u0001\u0013\u0001\u0013\u0001\u0013\u0001\u0013"+
		"\u0001\u0013\u0001\u0013\u0001\u0013\u0003\u0013\u0100\b\u0013\u0001\u0014"+
		"\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0014"+
		"\u0001\u0014\u0003\u0014\u010a\b\u0014\u0001\u0015\u0001\u0015\u0001\u0015"+
		"\u0001\u0016\u0001\u0016\u0001\u0017\u0001\u0017\u0001\u0017\u0001\u0017"+
		"\u0005\u0017\u0115\b\u0017\n\u0017\f\u0017\u0118\t\u0017\u0001\u0017\u0003"+
		"\u0017\u011b\b\u0017\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001"+
		"\u0019\u0001\u0019\u0001\u0019\u0001\u001a\u0001\u001a\u0001\u001a\u0001"+
		"\u001a\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001b\u0001"+
		"\u001b\u0001\u001c\u0001\u001c\u0001\u001c\u0001\u001c\u0001\u001c\u0001"+
		"\u001c\u0001\u001c\u0001\u001c\u0001\u001d\u0001\u001d\u0001\u001d\u0001"+
		"\u001e\u0001\u001e\u0001\u001e\u0001\u001f\u0001\u001f\u0003\u001f\u013e"+
		"\b\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0003\u001f\u0143\b\u001f"+
		"\u0001 \u0001 \u0001 \u0001 \u0001!\u0001!\u0001!\u0001!\u0001!\u0001"+
		"!\u0005!\u014f\b!\n!\f!\u0152\t!\u0001\"\u0001\"\u0001\"\u0001\"\u0001"+
		"\"\u0001\"\u0005\"\u015a\b\"\n\"\f\"\u015d\t\"\u0001#\u0001#\u0001#\u0001"+
		"#\u0001#\u0001#\u0005#\u0165\b#\n#\f#\u0168\t#\u0001$\u0001$\u0001$\u0001"+
		"$\u0001$\u0001$\u0005$\u0170\b$\n$\f$\u0173\t$\u0001%\u0001%\u0001%\u0001"+
		"%\u0001%\u0001%\u0005%\u017b\b%\n%\f%\u017e\t%\u0001&\u0001&\u0001&\u0001"+
		"&\u0001&\u0001&\u0001&\u0001&\u0001&\u0001&\u0001&\u0001&\u0003&\u018c"+
		"\b&\u0001\'\u0001\'\u0001\'\u0001(\u0001(\u0001(\u0001(\u0001(\u0003("+
		"\u0196\b(\u0001(\u0001(\u0001(\u0001(\u0003(\u019c\b(\u0005(\u019e\b("+
		"\n(\f(\u01a1\t(\u0001)\u0001)\u0003)\u01a5\b)\u0001)\u0001)\u0001*\u0001"+
		"*\u0001*\u0005*\u01ac\b*\n*\f*\u01af\t*\u0001+\u0001+\u0001+\u0001+\u0001"+
		",\u0001,\u0001,\u0001-\u0001-\u0001.\u0001.\u0001/\u0001/\u00010\u0001"+
		"0\u00011\u00011\u00012\u00012\u00013\u00013\u00013\u00013\u00014\u0001"+
		"4\u00014\u00054\u01cb\b4\n4\f4\u01ce\t4\u00015\u00015\u00015\u0000\u0007"+
		"\u0010BDFHJP6\u0000\u0002\u0004\u0006\b\n\f\u000e\u0010\u0012\u0014\u0016"+
		"\u0018\u001a\u001c\u001e \"$&(*,.02468:<>@BDFHJLNPRTVXZ\\^`bdfhj\u0000"+
		"\n\u0001\u0000\u001e!\u0002\u0000\u0007\u0007\n\u000e\u0001\u0000\u000f"+
		"\u0010\u0001\u0000\u0011\u0016\u0001\u0000\u0017\u0018\u0001\u0000\u0019"+
		"\u001b\u0002\u0000\u0018\u001822\u0002\u000099;<\u0001\u000089\u0001\u0000"+
		"67\u01d3\u0000q\u0001\u0000\u0000\u0000\u0002|\u0001\u0000\u0000\u0000"+
		"\u0004~\u0001\u0000\u0000\u0000\u0006\u0087\u0001\u0000\u0000\u0000\b"+
		"\u008f\u0001\u0000\u0000\u0000\n\u0092\u0001\u0000\u0000\u0000\f\u0094"+
		"\u0001\u0000\u0000\u0000\u000e\u00a8\u0001\u0000\u0000\u0000\u0010\u00af"+
		"\u0001\u0000\u0000\u0000\u0012\u00bb\u0001\u0000\u0000\u0000\u0014\u00bd"+
		"\u0001\u0000\u0000\u0000\u0016\u00c2\u0001\u0000\u0000\u0000\u0018\u00c4"+
		"\u0001\u0000\u0000\u0000\u001a\u00d8\u0001\u0000\u0000\u0000\u001c\u00e1"+
		"\u0001\u0000\u0000\u0000\u001e\u00e3\u0001\u0000\u0000\u0000 \u00ec\u0001"+
		"\u0000\u0000\u0000\"\u00ef\u0001\u0000\u0000\u0000$\u00f2\u0001\u0000"+
		"\u0000\u0000&\u00ff\u0001\u0000\u0000\u0000(\u0109\u0001\u0000\u0000\u0000"+
		"*\u010b\u0001\u0000\u0000\u0000,\u010e\u0001\u0000\u0000\u0000.\u0110"+
		"\u0001\u0000\u0000\u00000\u011c\u0001\u0000\u0000\u00002\u0120\u0001\u0000"+
		"\u0000\u00004\u0123\u0001\u0000\u0000\u00006\u0127\u0001\u0000\u0000\u0000"+
		"8\u012d\u0001\u0000\u0000\u0000:\u0135\u0001\u0000\u0000\u0000<\u0138"+
		"\u0001\u0000\u0000\u0000>\u0142\u0001\u0000\u0000\u0000@\u0144\u0001\u0000"+
		"\u0000\u0000B\u0148\u0001\u0000\u0000\u0000D\u0153\u0001\u0000\u0000\u0000"+
		"F\u015e\u0001\u0000\u0000\u0000H\u0169\u0001\u0000\u0000\u0000J\u0174"+
		"\u0001\u0000\u0000\u0000L\u018b\u0001\u0000\u0000\u0000N\u018d\u0001\u0000"+
		"\u0000\u0000P\u0190\u0001\u0000\u0000\u0000R\u01a2\u0001\u0000\u0000\u0000"+
		"T\u01a8\u0001\u0000\u0000\u0000V\u01b0\u0001\u0000\u0000\u0000X\u01b4"+
		"\u0001\u0000\u0000\u0000Z\u01b7\u0001\u0000\u0000\u0000\\\u01b9\u0001"+
		"\u0000\u0000\u0000^\u01bb\u0001\u0000\u0000\u0000`\u01bd\u0001\u0000\u0000"+
		"\u0000b\u01bf\u0001\u0000\u0000\u0000d\u01c1\u0001\u0000\u0000\u0000f"+
		"\u01c3\u0001\u0000\u0000\u0000h\u01c7\u0001\u0000\u0000\u0000j\u01cf\u0001"+
		"\u0000\u0000\u0000lp\u0003\u0002\u0001\u0000mp\u0003\n\u0005\u0000np\u0003"+
		"\u0004\u0002\u0000ol\u0001\u0000\u0000\u0000om\u0001\u0000\u0000\u0000"+
		"on\u0001\u0000\u0000\u0000ps\u0001\u0000\u0000\u0000qo\u0001\u0000\u0000"+
		"\u0000qr\u0001\u0000\u0000\u0000rt\u0001\u0000\u0000\u0000sq\u0001\u0000"+
		"\u0000\u0000tu\u0005\u0000\u0000\u0001u\u0001\u0001\u0000\u0000\u0000"+
		"vw\u0003$\u0012\u0000wx\u0005\u0001\u0000\u0000x}\u0001\u0000\u0000\u0000"+
		"yz\u0003&\u0013\u0000z{\u0005\u0001\u0000\u0000{}\u0001\u0000\u0000\u0000"+
		"|v\u0001\u0000\u0000\u0000|y\u0001\u0000\u0000\u0000}\u0003\u0001\u0000"+
		"\u0000\u0000~\u007f\u0003\u0010\b\u0000\u007f\u0080\u0003j5\u0000\u0080"+
		"\u0082\u0005\u0002\u0000\u0000\u0081\u0083\u0003\u0006\u0003\u0000\u0082"+
		"\u0081\u0001\u0000\u0000\u0000\u0082\u0083\u0001\u0000\u0000\u0000\u0083"+
		"\u0084\u0001\u0000\u0000\u0000\u0084\u0085\u0005\u0003\u0000\u0000\u0085"+
		"\u0086\u0003\u001e\u000f\u0000\u0086\u0005\u0001\u0000\u0000\u0000\u0087"+
		"\u008c\u0003\b\u0004\u0000\u0088\u0089\u0005\u0004\u0000\u0000\u0089\u008b"+
		"\u0003\b\u0004\u0000\u008a\u0088\u0001\u0000\u0000\u0000\u008b\u008e\u0001"+
		"\u0000\u0000\u0000\u008c\u008a\u0001\u0000\u0000\u0000\u008c\u008d\u0001"+
		"\u0000\u0000\u0000\u008d\u0007\u0001\u0000\u0000\u0000\u008e\u008c\u0001"+
		"\u0000\u0000\u0000\u008f\u0090\u0003\u0010\b\u0000\u0090\u0091\u0003j"+
		"5\u0000\u0091\t\u0001\u0000\u0000\u0000\u0092\u0093\u0003\f\u0006\u0000"+
		"\u0093\u000b\u0001\u0000\u0000\u0000\u0094\u0095\u00055\u0000\u0000\u0095"+
		"\u0096\u0003\u0016\u000b\u0000\u0096\u0098\u0005\u0005\u0000\u0000\u0097"+
		"\u0099\u0003\u000e\u0007\u0000\u0098\u0097\u0001\u0000\u0000\u0000\u0099"+
		"\u009a\u0001\u0000\u0000\u0000\u009a\u0098\u0001\u0000\u0000\u0000\u009a"+
		"\u009b\u0001\u0000\u0000\u0000\u009b\u009c\u0001\u0000\u0000\u0000\u009c"+
		"\u009d\u0005\u0006\u0000\u0000\u009d\r\u0001\u0000\u0000\u0000\u009e\u009f"+
		"\u0003\u0010\b\u0000\u009f\u00a0\u0003j5\u0000\u00a0\u00a1\u0005\u0001"+
		"\u0000\u0000\u00a1\u00a9\u0001\u0000\u0000\u0000\u00a2\u00a3\u0003\u0010"+
		"\b\u0000\u00a3\u00a4\u0003j5\u0000\u00a4\u00a5\u0005\u0007\u0000\u0000"+
		"\u00a5\u00a6\u0003B!\u0000\u00a6\u00a7\u0005\u0001\u0000\u0000\u00a7\u00a9"+
		"\u0001\u0000\u0000\u0000\u00a8\u009e\u0001\u0000\u0000\u0000\u00a8\u00a2"+
		"\u0001\u0000\u0000\u0000\u00a9\u000f\u0001\u0000\u0000\u0000\u00aa\u00ab"+
		"\u0006\b\uffff\uffff\u0000\u00ab\u00b0\u0005\u001d\u0000\u0000\u00ac\u00b0"+
		"\u0003\u0012\t\u0000\u00ad\u00b0\u0003\u0014\n\u0000\u00ae\u00b0\u0003"+
		"\u0016\u000b\u0000\u00af\u00aa\u0001\u0000\u0000\u0000\u00af\u00ac\u0001"+
		"\u0000\u0000\u0000\u00af\u00ad\u0001\u0000\u0000\u0000\u00af\u00ae\u0001"+
		"\u0000\u0000\u0000\u00b0\u00b8\u0001\u0000\u0000\u0000\u00b1\u00b2\n\u0003"+
		"\u0000\u0000\u00b2\u00b3\u0005\b\u0000\u0000\u00b3\u00b4\u0003\\.\u0000"+
		"\u00b4\u00b5\u0005\t\u0000\u0000\u00b5\u00b7\u0001\u0000\u0000\u0000\u00b6"+
		"\u00b1\u0001\u0000\u0000\u0000\u00b7\u00ba\u0001\u0000\u0000\u0000\u00b8"+
		"\u00b6\u0001\u0000\u0000\u0000\u00b8\u00b9\u0001\u0000\u0000\u0000\u00b9"+
		"\u0011\u0001\u0000\u0000\u0000\u00ba\u00b8\u0001\u0000\u0000\u0000\u00bb"+
		"\u00bc\u0007\u0000\u0000\u0000\u00bc\u0013\u0001\u0000\u0000\u0000\u00bd"+
		"\u00be\u0005#\u0000\u0000\u00be\u00bf\u0005\u0002\u0000\u0000\u00bf\u00c0"+
		"\u0003\u0018\f\u0000\u00c0\u00c1\u0005\u0003\u0000\u0000\u00c1\u0015\u0001"+
		"\u0000\u0000\u0000\u00c2\u00c3\u0003j5\u0000\u00c3\u0017\u0001\u0000\u0000"+
		"\u0000\u00c4\u00c9\u0003\u0010\b\u0000\u00c5\u00c6\u0005\u0004\u0000\u0000"+
		"\u00c6\u00c8\u0003\u0010\b\u0000\u00c7\u00c5\u0001\u0000\u0000\u0000\u00c8"+
		"\u00cb\u0001\u0000\u0000\u0000\u00c9\u00c7\u0001\u0000\u0000\u0000\u00c9"+
		"\u00ca\u0001\u0000\u0000\u0000\u00ca\u0019\u0001\u0000\u0000\u0000\u00cb"+
		"\u00c9\u0001\u0000\u0000\u0000\u00cc\u00cd\u0003\u001c\u000e\u0000\u00cd"+
		"\u00ce\u0005\u0001\u0000\u0000\u00ce\u00d9\u0001\u0000\u0000\u0000\u00cf"+
		"\u00d9\u0003:\u001d\u0000\u00d0\u00d9\u0003<\u001e\u0000\u00d1\u00d9\u0003"+
		">\u001f\u0000\u00d2\u00d9\u0003@ \u0000\u00d3\u00d9\u0003.\u0017\u0000"+
		"\u00d4\u00d9\u00034\u001a\u0000\u00d5\u00d9\u00036\u001b\u0000\u00d6\u00d9"+
		"\u00038\u001c\u0000\u00d7\u00d9\u0003\u001e\u000f\u0000\u00d8\u00cc\u0001"+
		"\u0000\u0000\u0000\u00d8\u00cf\u0001\u0000\u0000\u0000\u00d8\u00d0\u0001"+
		"\u0000\u0000\u0000\u00d8\u00d1\u0001\u0000\u0000\u0000\u00d8\u00d2\u0001"+
		"\u0000\u0000\u0000\u00d8\u00d3\u0001\u0000\u0000\u0000\u00d8\u00d4\u0001"+
		"\u0000\u0000\u0000\u00d8\u00d5\u0001\u0000\u0000\u0000\u00d8\u00d6\u0001"+
		"\u0000\u0000\u0000\u00d8\u00d7\u0001\u0000\u0000\u0000\u00d9\u001b\u0001"+
		"\u0000\u0000\u0000\u00da\u00e2\u0003 \u0010\u0000\u00db\u00e2\u0003\""+
		"\u0011\u0000\u00dc\u00e2\u0003$\u0012\u0000\u00dd\u00e2\u0003(\u0014\u0000"+
		"\u00de\u00e2\u0003*\u0015\u0000\u00df\u00e2\u0003&\u0013\u0000\u00e0\u00e2"+
		"\u0003,\u0016\u0000\u00e1\u00da\u0001\u0000\u0000\u0000\u00e1\u00db\u0001"+
		"\u0000\u0000\u0000\u00e1\u00dc\u0001\u0000\u0000\u0000\u00e1\u00dd\u0001"+
		"\u0000\u0000\u0000\u00e1\u00de\u0001\u0000\u0000\u0000\u00e1\u00df\u0001"+
		"\u0000\u0000\u0000\u00e1\u00e0\u0001\u0000\u0000\u0000\u00e2\u001d\u0001"+
		"\u0000\u0000\u0000\u00e3\u00e7\u0005\u0005\u0000\u0000\u00e4\u00e6\u0003"+
		"\u001a\r\u0000\u00e5\u00e4\u0001\u0000\u0000\u0000\u00e6\u00e9\u0001\u0000"+
		"\u0000\u0000\u00e7\u00e5\u0001\u0000\u0000\u0000\u00e7\u00e8\u0001\u0000"+
		"\u0000\u0000\u00e8\u00ea\u0001\u0000\u0000\u0000\u00e9\u00e7\u0001\u0000"+
		"\u0000\u0000\u00ea\u00eb\u0005\u0006\u0000\u0000\u00eb\u001f\u0001\u0000"+
		"\u0000\u0000\u00ec\u00ed\u0005$\u0000\u0000\u00ed\u00ee\u0003B!\u0000"+
		"\u00ee!\u0001\u0000\u0000\u0000\u00ef\u00f0\u0005%\u0000\u0000\u00f0\u00f1"+
		"\u0003B!\u0000\u00f1#\u0001\u0000\u0000\u0000\u00f2\u00f3\u0003\u0010"+
		"\b\u0000\u00f3\u00f4\u0003j5\u0000\u00f4%\u0001\u0000\u0000\u0000\u00f5"+
		"\u00f6\u0003\u0010\b\u0000\u00f6\u00f7\u0003j5\u0000\u00f7\u00f8\u0005"+
		"\u0007\u0000\u0000\u00f8\u00f9\u0003B!\u0000\u00f9\u0100\u0001\u0000\u0000"+
		"\u0000\u00fa\u00fb\u0003\u0010\b\u0000\u00fb\u00fc\u0003j5\u0000\u00fc"+
		"\u00fd\u0005\u0007\u0000\u0000\u00fd\u00fe\u0003f3\u0000\u00fe\u0100\u0001"+
		"\u0000\u0000\u0000\u00ff\u00f5\u0001\u0000\u0000\u0000\u00ff\u00fa\u0001"+
		"\u0000\u0000\u0000\u0100\'\u0001\u0000\u0000\u0000\u0101\u0102\u0003B"+
		"!\u0000\u0102\u0103\u0007\u0001\u0000\u0000\u0103\u0104\u0003B!\u0000"+
		"\u0104\u010a\u0001\u0000\u0000\u0000\u0105\u0106\u0003B!\u0000\u0106\u0107"+
		"\u0005\u0007\u0000\u0000\u0107\u0108\u0003f3\u0000\u0108\u010a\u0001\u0000"+
		"\u0000\u0000\u0109\u0101\u0001\u0000\u0000\u0000\u0109\u0105\u0001\u0000"+
		"\u0000\u0000\u010a)\u0001\u0000\u0000\u0000\u010b\u010c\u0003B!\u0000"+
		"\u010c\u010d\u0007\u0002\u0000\u0000\u010d+\u0001\u0000\u0000\u0000\u010e"+
		"\u010f\u0003P(\u0000\u010f-\u0001\u0000\u0000\u0000\u0110\u0111\u0005"+
		"\'\u0000\u0000\u0111\u0112\u0003B!\u0000\u0112\u0116\u0003\u001e\u000f"+
		"\u0000\u0113\u0115\u00030\u0018\u0000\u0114\u0113\u0001\u0000\u0000\u0000"+
		"\u0115\u0118\u0001\u0000\u0000\u0000\u0116\u0114\u0001\u0000\u0000\u0000"+
		"\u0116\u0117\u0001\u0000\u0000\u0000\u0117\u011a\u0001\u0000\u0000\u0000"+
		"\u0118\u0116\u0001\u0000\u0000\u0000\u0119\u011b\u00032\u0019\u0000\u011a"+
		"\u0119\u0001\u0000\u0000\u0000\u011a\u011b\u0001\u0000\u0000\u0000\u011b"+
		"/\u0001\u0000\u0000\u0000\u011c\u011d\u0005(\u0000\u0000\u011d\u011e\u0003"+
		"B!\u0000\u011e\u011f\u0003\u001e\u000f\u0000\u011f1\u0001\u0000\u0000"+
		"\u0000\u0120\u0121\u0005)\u0000\u0000\u0121\u0122\u0003\u001e\u000f\u0000"+
		"\u01223\u0001\u0000\u0000\u0000\u0123\u0124\u0005*\u0000\u0000\u0124\u0125"+
		"\u0003B!\u0000\u0125\u0126\u0003\u001e\u000f\u0000\u01265\u0001\u0000"+
		"\u0000\u0000\u0127\u0128\u0005+\u0000\u0000\u0128\u0129\u0003\u001e\u000f"+
		"\u0000\u0129\u012a\u0005*\u0000\u0000\u012a\u012b\u0003B!\u0000\u012b"+
		"\u012c\u0005\u0001\u0000\u0000\u012c7\u0001\u0000\u0000\u0000\u012d\u012e"+
		"\u0005,\u0000\u0000\u012e\u012f\u0003\u001c\u000e\u0000\u012f\u0130\u0005"+
		"\u0001\u0000\u0000\u0130\u0131\u0003B!\u0000\u0131\u0132\u0005\u0001\u0000"+
		"\u0000\u0132\u0133\u0003\u001c\u000e\u0000\u0133\u0134\u0003\u001e\u000f"+
		"\u0000\u01349\u0001\u0000\u0000\u0000\u0135\u0136\u0005-\u0000\u0000\u0136"+
		"\u0137\u0005\u0001\u0000\u0000\u0137;\u0001\u0000\u0000\u0000\u0138\u0139"+
		"\u0005.\u0000\u0000\u0139\u013a\u0005\u0001\u0000\u0000\u013a=\u0001\u0000"+
		"\u0000\u0000\u013b\u013d\u0005/\u0000\u0000\u013c\u013e\u0003B!\u0000"+
		"\u013d\u013c\u0001\u0000\u0000\u0000\u013d\u013e\u0001\u0000\u0000\u0000"+
		"\u013e\u013f\u0001\u0000\u0000\u0000\u013f\u0143\u0005\u0001\u0000\u0000"+
		"\u0140\u0141\u00050\u0000\u0000\u0141\u0143\u0005\u0001\u0000\u0000\u0142"+
		"\u013b\u0001\u0000\u0000\u0000\u0142\u0140\u0001\u0000\u0000\u0000\u0143"+
		"?\u0001\u0000\u0000\u0000\u0144\u0145\u00051\u0000\u0000\u0145\u0146\u0003"+
		"B!\u0000\u0146\u0147\u0005\u0001\u0000\u0000\u0147A\u0001\u0000\u0000"+
		"\u0000\u0148\u0149\u0006!\uffff\uffff\u0000\u0149\u014a\u0003D\"\u0000"+
		"\u014a\u0150\u0001\u0000\u0000\u0000\u014b\u014c\n\u0002\u0000\u0000\u014c"+
		"\u014d\u00053\u0000\u0000\u014d\u014f\u0003D\"\u0000\u014e\u014b\u0001"+
		"\u0000\u0000\u0000\u014f\u0152\u0001\u0000\u0000\u0000\u0150\u014e\u0001"+
		"\u0000\u0000\u0000\u0150\u0151\u0001\u0000\u0000\u0000\u0151C\u0001\u0000"+
		"\u0000\u0000\u0152\u0150\u0001\u0000\u0000\u0000\u0153\u0154\u0006\"\uffff"+
		"\uffff\u0000\u0154\u0155\u0003F#\u0000\u0155\u015b\u0001\u0000\u0000\u0000"+
		"\u0156\u0157\n\u0002\u0000\u0000\u0157\u0158\u00054\u0000\u0000\u0158"+
		"\u015a\u0003F#\u0000\u0159\u0156\u0001\u0000\u0000\u0000\u015a\u015d\u0001"+
		"\u0000\u0000\u0000\u015b\u0159\u0001\u0000\u0000\u0000\u015b\u015c\u0001"+
		"\u0000\u0000\u0000\u015cE\u0001\u0000\u0000\u0000\u015d\u015b\u0001\u0000"+
		"\u0000\u0000\u015e\u015f\u0006#\uffff\uffff\u0000\u015f\u0160\u0003H$"+
		"\u0000\u0160\u0166\u0001\u0000\u0000\u0000\u0161\u0162\n\u0002\u0000\u0000"+
		"\u0162\u0163\u0007\u0003\u0000\u0000\u0163\u0165\u0003H$\u0000\u0164\u0161"+
		"\u0001\u0000\u0000\u0000\u0165\u0168\u0001\u0000\u0000\u0000\u0166\u0164"+
		"\u0001\u0000\u0000\u0000\u0166\u0167\u0001\u0000\u0000\u0000\u0167G\u0001"+
		"\u0000\u0000\u0000\u0168\u0166\u0001\u0000\u0000\u0000\u0169\u016a\u0006"+
		"$\uffff\uffff\u0000\u016a\u016b\u0003J%\u0000\u016b\u0171\u0001\u0000"+
		"\u0000\u0000\u016c\u016d\n\u0002\u0000\u0000\u016d\u016e\u0007\u0004\u0000"+
		"\u0000\u016e\u0170\u0003J%\u0000\u016f\u016c\u0001\u0000\u0000\u0000\u0170"+
		"\u0173\u0001\u0000\u0000\u0000\u0171\u016f\u0001\u0000\u0000\u0000\u0171"+
		"\u0172\u0001\u0000\u0000\u0000\u0172I\u0001\u0000\u0000\u0000\u0173\u0171"+
		"\u0001\u0000\u0000\u0000\u0174\u0175\u0006%\uffff\uffff\u0000\u0175\u0176"+
		"\u0003L&\u0000\u0176\u017c\u0001\u0000\u0000\u0000\u0177\u0178\n\u0002"+
		"\u0000\u0000\u0178\u0179\u0007\u0005\u0000\u0000\u0179\u017b\u0003L&\u0000"+
		"\u017a\u0177\u0001\u0000\u0000\u0000\u017b\u017e\u0001\u0000\u0000\u0000"+
		"\u017c\u017a\u0001\u0000\u0000\u0000\u017c\u017d\u0001\u0000\u0000\u0000"+
		"\u017dK\u0001\u0000\u0000\u0000\u017e\u017c\u0001\u0000\u0000\u0000\u017f"+
		"\u018c\u0003N\'\u0000\u0180\u018c\u0003P(\u0000\u0181\u018c\u0003Z-\u0000"+
		"\u0182\u018c\u0003\\.\u0000\u0183\u018c\u0003^/\u0000\u0184\u018c\u0003"+
		"`0\u0000\u0185\u018c\u0003b1\u0000\u0186\u018c\u0003d2\u0000\u0187\u0188"+
		"\u0005\u0002\u0000\u0000\u0188\u0189\u0003B!\u0000\u0189\u018a\u0005\u0003"+
		"\u0000\u0000\u018a\u018c\u0001\u0000\u0000\u0000\u018b\u017f\u0001\u0000"+
		"\u0000\u0000\u018b\u0180\u0001\u0000\u0000\u0000\u018b\u0181\u0001\u0000"+
		"\u0000\u0000\u018b\u0182\u0001\u0000\u0000\u0000\u018b\u0183\u0001\u0000"+
		"\u0000\u0000\u018b\u0184\u0001\u0000\u0000\u0000\u018b\u0185\u0001\u0000"+
		"\u0000\u0000\u018b\u0186\u0001\u0000\u0000\u0000\u018b\u0187\u0001\u0000"+
		"\u0000\u0000\u018cM\u0001\u0000\u0000\u0000\u018d\u018e\u0007\u0006\u0000"+
		"\u0000\u018e\u018f\u0003L&\u0000\u018fO\u0001\u0000\u0000\u0000\u0190"+
		"\u0191\u0006(\uffff\uffff\u0000\u0191\u0195\u0003d2\u0000\u0192\u0196"+
		"\u0003R)\u0000\u0193\u0196\u0003V+\u0000\u0194\u0196\u0003X,\u0000\u0195"+
		"\u0192\u0001\u0000\u0000\u0000\u0195\u0193\u0001\u0000\u0000\u0000\u0195"+
		"\u0194\u0001\u0000\u0000\u0000\u0196\u019f\u0001\u0000\u0000\u0000\u0197"+
		"\u019b\n\u0001\u0000\u0000\u0198\u019c\u0003R)\u0000\u0199\u019c\u0003"+
		"V+\u0000\u019a\u019c\u0003X,\u0000\u019b\u0198\u0001\u0000\u0000\u0000"+
		"\u019b\u0199\u0001\u0000\u0000\u0000\u019b\u019a\u0001\u0000\u0000\u0000"+
		"\u019c\u019e\u0001\u0000\u0000\u0000\u019d\u0197\u0001\u0000\u0000\u0000"+
		"\u019e\u01a1\u0001\u0000\u0000\u0000\u019f\u019d\u0001\u0000\u0000\u0000"+
		"\u019f\u01a0\u0001\u0000\u0000\u0000\u01a0Q\u0001\u0000\u0000\u0000\u01a1"+
		"\u019f\u0001\u0000\u0000\u0000\u01a2\u01a4\u0005\u0002\u0000\u0000\u01a3"+
		"\u01a5\u0003T*\u0000\u01a4\u01a3\u0001\u0000\u0000\u0000\u01a4\u01a5\u0001"+
		"\u0000\u0000\u0000\u01a5\u01a6\u0001\u0000\u0000\u0000\u01a6\u01a7\u0005"+
		"\u0003\u0000\u0000\u01a7S\u0001\u0000\u0000\u0000\u01a8\u01ad\u0003B!"+
		"\u0000\u01a9\u01aa\u0005\u0004\u0000\u0000\u01aa\u01ac\u0003B!\u0000\u01ab"+
		"\u01a9\u0001\u0000\u0000\u0000\u01ac\u01af\u0001\u0000\u0000\u0000\u01ad"+
		"\u01ab\u0001\u0000\u0000\u0000\u01ad\u01ae\u0001\u0000\u0000\u0000\u01ae"+
		"U\u0001\u0000\u0000\u0000\u01af\u01ad\u0001\u0000\u0000\u0000\u01b0\u01b1"+
		"\u0005\b\u0000\u0000\u01b1\u01b2\u0003B!\u0000\u01b2\u01b3\u0005\t\u0000"+
		"\u0000\u01b3W\u0001\u0000\u0000\u0000\u01b4\u01b5\u0005\u001c\u0000\u0000"+
		"\u01b5\u01b6\u0003j5\u0000\u01b6Y\u0001\u0000\u0000\u0000\u01b7\u01b8"+
		"\u0005&\u0000\u0000\u01b8[\u0001\u0000\u0000\u0000\u01b9\u01ba\u00059"+
		"\u0000\u0000\u01ba]\u0001\u0000\u0000\u0000\u01bb\u01bc\u0007\u0007\u0000"+
		"\u0000\u01bc_\u0001\u0000\u0000\u0000\u01bd\u01be\u0007\b\u0000\u0000"+
		"\u01bea\u0001\u0000\u0000\u0000\u01bf\u01c0\u0007\t\u0000\u0000\u01c0"+
		"c\u0001\u0000\u0000\u0000\u01c1\u01c2\u0003j5\u0000\u01c2e\u0001\u0000"+
		"\u0000\u0000\u01c3\u01c4\u0005\b\u0000\u0000\u01c4\u01c5\u0003h4\u0000"+
		"\u01c5\u01c6\u0005\t\u0000\u0000\u01c6g\u0001\u0000\u0000\u0000\u01c7"+
		"\u01cc\u0003B!\u0000\u01c8\u01c9\u0005\u0004\u0000\u0000\u01c9\u01cb\u0003"+
		"B!\u0000\u01ca\u01c8\u0001\u0000\u0000\u0000\u01cb\u01ce\u0001\u0000\u0000"+
		"\u0000\u01cc\u01ca\u0001\u0000\u0000\u0000\u01cc\u01cd\u0001\u0000\u0000"+
		"\u0000\u01cdi\u0001\u0000\u0000\u0000\u01ce\u01cc\u0001\u0000\u0000\u0000"+
		"\u01cf\u01d0\u0005:\u0000\u0000\u01d0k\u0001\u0000\u0000\u0000\u001fo"+
		"q|\u0082\u008c\u009a\u00a8\u00af\u00b8\u00c9\u00d8\u00e1\u00e7\u00ff\u0109"+
		"\u0116\u011a\u013d\u0142\u0150\u015b\u0166\u0171\u017c\u018b\u0195\u019b"+
		"\u019f\u01a4\u01ad\u01cc";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}