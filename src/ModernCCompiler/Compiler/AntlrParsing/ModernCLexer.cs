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

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public partial class ModernCLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, T__19=20, T__20=21, T__21=22, T__22=23, T__23=24, 
		T__24=25, VOID_TYPE=26, INT_TYPE=27, BYTE_TYPE=28, FLOAT_TYPE=29, BOOL_TYPE=30, 
		FUNC=31, PRINT=32, PRINTLN=33, READ=34, IF=35, ELIF=36, ELSE=37, WHILE=38, 
		DO=39, FOR=40, BREAK=41, CONTINUE=42, RETURN=43, OK=44, EXIT=45, NOT=46, 
		OR=47, AND=48, TRUE=49, FALSE=50, FLOAT=51, INT=52, ID=53, ASCII_CHAR=54, 
		ESCAPED_ASCII_CHAR=55, COMMENT=56, WHITESPACE=57, NEWLINE=58;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "T__13", "T__14", "T__15", "T__16", 
		"T__17", "T__18", "T__19", "T__20", "T__21", "T__22", "T__23", "T__24", 
		"VOID_TYPE", "INT_TYPE", "BYTE_TYPE", "FLOAT_TYPE", "BOOL_TYPE", "FUNC", 
		"PRINT", "PRINTLN", "READ", "IF", "ELIF", "ELSE", "WHILE", "DO", "FOR", 
		"BREAK", "CONTINUE", "RETURN", "OK", "EXIT", "NOT", "OR", "AND", "TRUE", 
		"FALSE", "FLOAT", "INT", "ID", "ASCII_CHAR", "ESCAPED_ASCII_CHAR", "COMMENT", 
		"WHITESPACE", "NEWLINE"
	};


	public ModernCLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public ModernCLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'('", "')'", "','", "';'", "'{'", "'}'", "'='", "'+='", "'-='", 
		"'*='", "'/='", "'%='", "'++'", "'--'", "'=='", "'!='", "'<'", "'<='", 
		"'>'", "'>='", "'+'", "'-'", "'*'", "'/'", "'%'", "'void'", "'int'", "'byte'", 
		"'float'", "'bool'", "'func'", "'print'", "'println'", "'read'", "'if'", 
		"'elif'", "'else'", "'while'", "'do'", "'for'", "'break'", "'continue'", 
		"'return'", "'ok'", "'exit'", "'not'", "'or'", "'and'", "'true'", "'false'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, "VOID_TYPE", "INT_TYPE", "BYTE_TYPE", "FLOAT_TYPE", "BOOL_TYPE", 
		"FUNC", "PRINT", "PRINTLN", "READ", "IF", "ELIF", "ELSE", "WHILE", "DO", 
		"FOR", "BREAK", "CONTINUE", "RETURN", "OK", "EXIT", "NOT", "OR", "AND", 
		"TRUE", "FALSE", "FLOAT", "INT", "ID", "ASCII_CHAR", "ESCAPED_ASCII_CHAR", 
		"COMMENT", "WHITESPACE", "NEWLINE"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "ModernC.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static ModernCLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,58,369,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,7,27,2,28,
		7,28,2,29,7,29,2,30,7,30,2,31,7,31,2,32,7,32,2,33,7,33,2,34,7,34,2,35,
		7,35,2,36,7,36,2,37,7,37,2,38,7,38,2,39,7,39,2,40,7,40,2,41,7,41,2,42,
		7,42,2,43,7,43,2,44,7,44,2,45,7,45,2,46,7,46,2,47,7,47,2,48,7,48,2,49,
		7,49,2,50,7,50,2,51,7,51,2,52,7,52,2,53,7,53,2,54,7,54,2,55,7,55,2,56,
		7,56,2,57,7,57,1,0,1,0,1,1,1,1,1,2,1,2,1,3,1,3,1,4,1,4,1,5,1,5,1,6,1,6,
		1,7,1,7,1,7,1,8,1,8,1,8,1,9,1,9,1,9,1,10,1,10,1,10,1,11,1,11,1,11,1,12,
		1,12,1,12,1,13,1,13,1,13,1,14,1,14,1,14,1,15,1,15,1,15,1,16,1,16,1,17,
		1,17,1,17,1,18,1,18,1,19,1,19,1,19,1,20,1,20,1,21,1,21,1,22,1,22,1,23,
		1,23,1,24,1,24,1,25,1,25,1,25,1,25,1,25,1,26,1,26,1,26,1,26,1,27,1,27,
		1,27,1,27,1,27,1,28,1,28,1,28,1,28,1,28,1,28,1,29,1,29,1,29,1,29,1,29,
		1,30,1,30,1,30,1,30,1,30,1,31,1,31,1,31,1,31,1,31,1,31,1,32,1,32,1,32,
		1,32,1,32,1,32,1,32,1,32,1,33,1,33,1,33,1,33,1,33,1,34,1,34,1,34,1,35,
		1,35,1,35,1,35,1,35,1,36,1,36,1,36,1,36,1,36,1,37,1,37,1,37,1,37,1,37,
		1,37,1,38,1,38,1,38,1,39,1,39,1,39,1,39,1,40,1,40,1,40,1,40,1,40,1,40,
		1,41,1,41,1,41,1,41,1,41,1,41,1,41,1,41,1,41,1,42,1,42,1,42,1,42,1,42,
		1,42,1,42,1,43,1,43,1,43,1,44,1,44,1,44,1,44,1,44,1,45,1,45,1,45,1,45,
		1,46,1,46,1,46,1,47,1,47,1,47,1,47,1,48,1,48,1,48,1,48,1,48,1,49,1,49,
		1,49,1,49,1,49,1,49,1,50,5,50,307,8,50,10,50,12,50,310,9,50,1,50,1,50,
		4,50,314,8,50,11,50,12,50,315,1,51,4,51,319,8,51,11,51,12,51,320,1,52,
		1,52,5,52,325,8,52,10,52,12,52,328,9,52,1,53,1,53,1,53,1,53,1,54,1,54,
		1,54,1,54,1,54,1,55,1,55,1,55,1,55,5,55,343,8,55,10,55,12,55,346,9,55,
		1,55,1,55,1,55,1,55,1,56,4,56,353,8,56,11,56,12,56,354,1,56,1,56,1,57,
		3,57,360,8,57,1,57,1,57,4,57,364,8,57,11,57,12,57,365,1,57,1,57,1,344,
		0,58,1,1,3,2,5,3,7,4,9,5,11,6,13,7,15,8,17,9,19,10,21,11,23,12,25,13,27,
		14,29,15,31,16,33,17,35,18,37,19,39,20,41,21,43,22,45,23,47,24,49,25,51,
		26,53,27,55,28,57,29,59,30,61,31,63,32,65,33,67,34,69,35,71,36,73,37,75,
		38,77,39,79,40,81,41,83,42,85,43,87,44,89,45,91,46,93,47,95,48,97,49,99,
		50,101,51,103,52,105,53,107,54,109,55,111,56,113,57,115,58,1,0,4,1,0,48,
		57,3,0,65,90,95,95,97,122,4,0,48,57,65,90,95,95,97,122,2,0,9,9,32,32,377,
		0,1,1,0,0,0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,1,0,0,0,0,11,1,0,0,
		0,0,13,1,0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,0,19,1,0,0,0,0,21,1,0,0,0,0,23,
		1,0,0,0,0,25,1,0,0,0,0,27,1,0,0,0,0,29,1,0,0,0,0,31,1,0,0,0,0,33,1,0,0,
		0,0,35,1,0,0,0,0,37,1,0,0,0,0,39,1,0,0,0,0,41,1,0,0,0,0,43,1,0,0,0,0,45,
		1,0,0,0,0,47,1,0,0,0,0,49,1,0,0,0,0,51,1,0,0,0,0,53,1,0,0,0,0,55,1,0,0,
		0,0,57,1,0,0,0,0,59,1,0,0,0,0,61,1,0,0,0,0,63,1,0,0,0,0,65,1,0,0,0,0,67,
		1,0,0,0,0,69,1,0,0,0,0,71,1,0,0,0,0,73,1,0,0,0,0,75,1,0,0,0,0,77,1,0,0,
		0,0,79,1,0,0,0,0,81,1,0,0,0,0,83,1,0,0,0,0,85,1,0,0,0,0,87,1,0,0,0,0,89,
		1,0,0,0,0,91,1,0,0,0,0,93,1,0,0,0,0,95,1,0,0,0,0,97,1,0,0,0,0,99,1,0,0,
		0,0,101,1,0,0,0,0,103,1,0,0,0,0,105,1,0,0,0,0,107,1,0,0,0,0,109,1,0,0,
		0,0,111,1,0,0,0,0,113,1,0,0,0,0,115,1,0,0,0,1,117,1,0,0,0,3,119,1,0,0,
		0,5,121,1,0,0,0,7,123,1,0,0,0,9,125,1,0,0,0,11,127,1,0,0,0,13,129,1,0,
		0,0,15,131,1,0,0,0,17,134,1,0,0,0,19,137,1,0,0,0,21,140,1,0,0,0,23,143,
		1,0,0,0,25,146,1,0,0,0,27,149,1,0,0,0,29,152,1,0,0,0,31,155,1,0,0,0,33,
		158,1,0,0,0,35,160,1,0,0,0,37,163,1,0,0,0,39,165,1,0,0,0,41,168,1,0,0,
		0,43,170,1,0,0,0,45,172,1,0,0,0,47,174,1,0,0,0,49,176,1,0,0,0,51,178,1,
		0,0,0,53,183,1,0,0,0,55,187,1,0,0,0,57,192,1,0,0,0,59,198,1,0,0,0,61,203,
		1,0,0,0,63,208,1,0,0,0,65,214,1,0,0,0,67,222,1,0,0,0,69,227,1,0,0,0,71,
		230,1,0,0,0,73,235,1,0,0,0,75,240,1,0,0,0,77,246,1,0,0,0,79,249,1,0,0,
		0,81,253,1,0,0,0,83,259,1,0,0,0,85,268,1,0,0,0,87,275,1,0,0,0,89,278,1,
		0,0,0,91,283,1,0,0,0,93,287,1,0,0,0,95,290,1,0,0,0,97,294,1,0,0,0,99,299,
		1,0,0,0,101,308,1,0,0,0,103,318,1,0,0,0,105,322,1,0,0,0,107,329,1,0,0,
		0,109,333,1,0,0,0,111,338,1,0,0,0,113,352,1,0,0,0,115,363,1,0,0,0,117,
		118,5,40,0,0,118,2,1,0,0,0,119,120,5,41,0,0,120,4,1,0,0,0,121,122,5,44,
		0,0,122,6,1,0,0,0,123,124,5,59,0,0,124,8,1,0,0,0,125,126,5,123,0,0,126,
		10,1,0,0,0,127,128,5,125,0,0,128,12,1,0,0,0,129,130,5,61,0,0,130,14,1,
		0,0,0,131,132,5,43,0,0,132,133,5,61,0,0,133,16,1,0,0,0,134,135,5,45,0,
		0,135,136,5,61,0,0,136,18,1,0,0,0,137,138,5,42,0,0,138,139,5,61,0,0,139,
		20,1,0,0,0,140,141,5,47,0,0,141,142,5,61,0,0,142,22,1,0,0,0,143,144,5,
		37,0,0,144,145,5,61,0,0,145,24,1,0,0,0,146,147,5,43,0,0,147,148,5,43,0,
		0,148,26,1,0,0,0,149,150,5,45,0,0,150,151,5,45,0,0,151,28,1,0,0,0,152,
		153,5,61,0,0,153,154,5,61,0,0,154,30,1,0,0,0,155,156,5,33,0,0,156,157,
		5,61,0,0,157,32,1,0,0,0,158,159,5,60,0,0,159,34,1,0,0,0,160,161,5,60,0,
		0,161,162,5,61,0,0,162,36,1,0,0,0,163,164,5,62,0,0,164,38,1,0,0,0,165,
		166,5,62,0,0,166,167,5,61,0,0,167,40,1,0,0,0,168,169,5,43,0,0,169,42,1,
		0,0,0,170,171,5,45,0,0,171,44,1,0,0,0,172,173,5,42,0,0,173,46,1,0,0,0,
		174,175,5,47,0,0,175,48,1,0,0,0,176,177,5,37,0,0,177,50,1,0,0,0,178,179,
		5,118,0,0,179,180,5,111,0,0,180,181,5,105,0,0,181,182,5,100,0,0,182,52,
		1,0,0,0,183,184,5,105,0,0,184,185,5,110,0,0,185,186,5,116,0,0,186,54,1,
		0,0,0,187,188,5,98,0,0,188,189,5,121,0,0,189,190,5,116,0,0,190,191,5,101,
		0,0,191,56,1,0,0,0,192,193,5,102,0,0,193,194,5,108,0,0,194,195,5,111,0,
		0,195,196,5,97,0,0,196,197,5,116,0,0,197,58,1,0,0,0,198,199,5,98,0,0,199,
		200,5,111,0,0,200,201,5,111,0,0,201,202,5,108,0,0,202,60,1,0,0,0,203,204,
		5,102,0,0,204,205,5,117,0,0,205,206,5,110,0,0,206,207,5,99,0,0,207,62,
		1,0,0,0,208,209,5,112,0,0,209,210,5,114,0,0,210,211,5,105,0,0,211,212,
		5,110,0,0,212,213,5,116,0,0,213,64,1,0,0,0,214,215,5,112,0,0,215,216,5,
		114,0,0,216,217,5,105,0,0,217,218,5,110,0,0,218,219,5,116,0,0,219,220,
		5,108,0,0,220,221,5,110,0,0,221,66,1,0,0,0,222,223,5,114,0,0,223,224,5,
		101,0,0,224,225,5,97,0,0,225,226,5,100,0,0,226,68,1,0,0,0,227,228,5,105,
		0,0,228,229,5,102,0,0,229,70,1,0,0,0,230,231,5,101,0,0,231,232,5,108,0,
		0,232,233,5,105,0,0,233,234,5,102,0,0,234,72,1,0,0,0,235,236,5,101,0,0,
		236,237,5,108,0,0,237,238,5,115,0,0,238,239,5,101,0,0,239,74,1,0,0,0,240,
		241,5,119,0,0,241,242,5,104,0,0,242,243,5,105,0,0,243,244,5,108,0,0,244,
		245,5,101,0,0,245,76,1,0,0,0,246,247,5,100,0,0,247,248,5,111,0,0,248,78,
		1,0,0,0,249,250,5,102,0,0,250,251,5,111,0,0,251,252,5,114,0,0,252,80,1,
		0,0,0,253,254,5,98,0,0,254,255,5,114,0,0,255,256,5,101,0,0,256,257,5,97,
		0,0,257,258,5,107,0,0,258,82,1,0,0,0,259,260,5,99,0,0,260,261,5,111,0,
		0,261,262,5,110,0,0,262,263,5,116,0,0,263,264,5,105,0,0,264,265,5,110,
		0,0,265,266,5,117,0,0,266,267,5,101,0,0,267,84,1,0,0,0,268,269,5,114,0,
		0,269,270,5,101,0,0,270,271,5,116,0,0,271,272,5,117,0,0,272,273,5,114,
		0,0,273,274,5,110,0,0,274,86,1,0,0,0,275,276,5,111,0,0,276,277,5,107,0,
		0,277,88,1,0,0,0,278,279,5,101,0,0,279,280,5,120,0,0,280,281,5,105,0,0,
		281,282,5,116,0,0,282,90,1,0,0,0,283,284,5,110,0,0,284,285,5,111,0,0,285,
		286,5,116,0,0,286,92,1,0,0,0,287,288,5,111,0,0,288,289,5,114,0,0,289,94,
		1,0,0,0,290,291,5,97,0,0,291,292,5,110,0,0,292,293,5,100,0,0,293,96,1,
		0,0,0,294,295,5,116,0,0,295,296,5,114,0,0,296,297,5,117,0,0,297,298,5,
		101,0,0,298,98,1,0,0,0,299,300,5,102,0,0,300,301,5,97,0,0,301,302,5,108,
		0,0,302,303,5,115,0,0,303,304,5,101,0,0,304,100,1,0,0,0,305,307,7,0,0,
		0,306,305,1,0,0,0,307,310,1,0,0,0,308,306,1,0,0,0,308,309,1,0,0,0,309,
		311,1,0,0,0,310,308,1,0,0,0,311,313,5,46,0,0,312,314,7,0,0,0,313,312,1,
		0,0,0,314,315,1,0,0,0,315,313,1,0,0,0,315,316,1,0,0,0,316,102,1,0,0,0,
		317,319,7,0,0,0,318,317,1,0,0,0,319,320,1,0,0,0,320,318,1,0,0,0,320,321,
		1,0,0,0,321,104,1,0,0,0,322,326,7,1,0,0,323,325,7,2,0,0,324,323,1,0,0,
		0,325,328,1,0,0,0,326,324,1,0,0,0,326,327,1,0,0,0,327,106,1,0,0,0,328,
		326,1,0,0,0,329,330,5,39,0,0,330,331,9,0,0,0,331,332,5,39,0,0,332,108,
		1,0,0,0,333,334,5,39,0,0,334,335,5,92,0,0,335,336,9,0,0,0,336,337,5,39,
		0,0,337,110,1,0,0,0,338,339,5,47,0,0,339,340,5,47,0,0,340,344,1,0,0,0,
		341,343,9,0,0,0,342,341,1,0,0,0,343,346,1,0,0,0,344,345,1,0,0,0,344,342,
		1,0,0,0,345,347,1,0,0,0,346,344,1,0,0,0,347,348,5,10,0,0,348,349,1,0,0,
		0,349,350,6,55,0,0,350,112,1,0,0,0,351,353,7,3,0,0,352,351,1,0,0,0,353,
		354,1,0,0,0,354,352,1,0,0,0,354,355,1,0,0,0,355,356,1,0,0,0,356,357,6,
		56,0,0,357,114,1,0,0,0,358,360,5,13,0,0,359,358,1,0,0,0,359,360,1,0,0,
		0,360,361,1,0,0,0,361,364,5,10,0,0,362,364,5,13,0,0,363,359,1,0,0,0,363,
		362,1,0,0,0,364,365,1,0,0,0,365,363,1,0,0,0,365,366,1,0,0,0,366,367,1,
		0,0,0,367,368,6,57,0,0,368,116,1,0,0,0,10,0,308,315,320,326,344,354,359,
		363,365,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
