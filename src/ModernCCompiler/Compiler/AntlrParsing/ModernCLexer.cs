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
		T__17=18, T__18=19, T__19=20, VOID_TYPE=21, INT_TYPE=22, BOOL_TYPE=23, 
		TRUE=24, FALSE=25, INT=26, ID=27, WHITESPACE=28, NEWLINE=29;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "T__13", "T__14", "T__15", "T__16", 
		"T__17", "T__18", "T__19", "VOID_TYPE", "INT_TYPE", "BOOL_TYPE", "TRUE", 
		"FALSE", "INT", "ID", "WHITESPACE", "NEWLINE"
	};


	public ModernCLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public ModernCLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'('", "')'", "','", "'func'", "'{'", "'}'", "'print'", "';'", "'='", 
		"'if'", "'elif'", "'else'", "'return'", "'+'", "'-'", "'or'", "'*'", "'/'", 
		"'and'", "'not'", "'void'", "'int'", "'bool'", "'true'", "'false'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, "VOID_TYPE", "INT_TYPE", 
		"BOOL_TYPE", "TRUE", "FALSE", "INT", "ID", "WHITESPACE", "NEWLINE"
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
		4,0,29,178,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,7,27,2,28,
		7,28,1,0,1,0,1,1,1,1,1,2,1,2,1,3,1,3,1,3,1,3,1,3,1,4,1,4,1,5,1,5,1,6,1,
		6,1,6,1,6,1,6,1,6,1,7,1,7,1,8,1,8,1,9,1,9,1,9,1,10,1,10,1,10,1,10,1,10,
		1,11,1,11,1,11,1,11,1,11,1,12,1,12,1,12,1,12,1,12,1,12,1,12,1,13,1,13,
		1,14,1,14,1,15,1,15,1,15,1,16,1,16,1,17,1,17,1,18,1,18,1,18,1,18,1,19,
		1,19,1,19,1,19,1,20,1,20,1,20,1,20,1,20,1,21,1,21,1,21,1,21,1,22,1,22,
		1,22,1,22,1,22,1,23,1,23,1,23,1,23,1,23,1,24,1,24,1,24,1,24,1,24,1,24,
		1,25,4,25,150,8,25,11,25,12,25,151,1,26,1,26,5,26,156,8,26,10,26,12,26,
		159,9,26,1,27,4,27,162,8,27,11,27,12,27,163,1,27,1,27,1,28,3,28,169,8,
		28,1,28,1,28,4,28,173,8,28,11,28,12,28,174,1,28,1,28,0,0,29,1,1,3,2,5,
		3,7,4,9,5,11,6,13,7,15,8,17,9,19,10,21,11,23,12,25,13,27,14,29,15,31,16,
		33,17,35,18,37,19,39,20,41,21,43,22,45,23,47,24,49,25,51,26,53,27,55,28,
		57,29,1,0,4,1,0,48,57,3,0,65,90,95,95,97,122,4,0,48,57,65,90,95,95,97,
		122,2,0,9,9,32,32,183,0,1,1,0,0,0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,
		0,9,1,0,0,0,0,11,1,0,0,0,0,13,1,0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,0,19,1,
		0,0,0,0,21,1,0,0,0,0,23,1,0,0,0,0,25,1,0,0,0,0,27,1,0,0,0,0,29,1,0,0,0,
		0,31,1,0,0,0,0,33,1,0,0,0,0,35,1,0,0,0,0,37,1,0,0,0,0,39,1,0,0,0,0,41,
		1,0,0,0,0,43,1,0,0,0,0,45,1,0,0,0,0,47,1,0,0,0,0,49,1,0,0,0,0,51,1,0,0,
		0,0,53,1,0,0,0,0,55,1,0,0,0,0,57,1,0,0,0,1,59,1,0,0,0,3,61,1,0,0,0,5,63,
		1,0,0,0,7,65,1,0,0,0,9,70,1,0,0,0,11,72,1,0,0,0,13,74,1,0,0,0,15,80,1,
		0,0,0,17,82,1,0,0,0,19,84,1,0,0,0,21,87,1,0,0,0,23,92,1,0,0,0,25,97,1,
		0,0,0,27,104,1,0,0,0,29,106,1,0,0,0,31,108,1,0,0,0,33,111,1,0,0,0,35,113,
		1,0,0,0,37,115,1,0,0,0,39,119,1,0,0,0,41,123,1,0,0,0,43,128,1,0,0,0,45,
		132,1,0,0,0,47,137,1,0,0,0,49,142,1,0,0,0,51,149,1,0,0,0,53,153,1,0,0,
		0,55,161,1,0,0,0,57,172,1,0,0,0,59,60,5,40,0,0,60,2,1,0,0,0,61,62,5,41,
		0,0,62,4,1,0,0,0,63,64,5,44,0,0,64,6,1,0,0,0,65,66,5,102,0,0,66,67,5,117,
		0,0,67,68,5,110,0,0,68,69,5,99,0,0,69,8,1,0,0,0,70,71,5,123,0,0,71,10,
		1,0,0,0,72,73,5,125,0,0,73,12,1,0,0,0,74,75,5,112,0,0,75,76,5,114,0,0,
		76,77,5,105,0,0,77,78,5,110,0,0,78,79,5,116,0,0,79,14,1,0,0,0,80,81,5,
		59,0,0,81,16,1,0,0,0,82,83,5,61,0,0,83,18,1,0,0,0,84,85,5,105,0,0,85,86,
		5,102,0,0,86,20,1,0,0,0,87,88,5,101,0,0,88,89,5,108,0,0,89,90,5,105,0,
		0,90,91,5,102,0,0,91,22,1,0,0,0,92,93,5,101,0,0,93,94,5,108,0,0,94,95,
		5,115,0,0,95,96,5,101,0,0,96,24,1,0,0,0,97,98,5,114,0,0,98,99,5,101,0,
		0,99,100,5,116,0,0,100,101,5,117,0,0,101,102,5,114,0,0,102,103,5,110,0,
		0,103,26,1,0,0,0,104,105,5,43,0,0,105,28,1,0,0,0,106,107,5,45,0,0,107,
		30,1,0,0,0,108,109,5,111,0,0,109,110,5,114,0,0,110,32,1,0,0,0,111,112,
		5,42,0,0,112,34,1,0,0,0,113,114,5,47,0,0,114,36,1,0,0,0,115,116,5,97,0,
		0,116,117,5,110,0,0,117,118,5,100,0,0,118,38,1,0,0,0,119,120,5,110,0,0,
		120,121,5,111,0,0,121,122,5,116,0,0,122,40,1,0,0,0,123,124,5,118,0,0,124,
		125,5,111,0,0,125,126,5,105,0,0,126,127,5,100,0,0,127,42,1,0,0,0,128,129,
		5,105,0,0,129,130,5,110,0,0,130,131,5,116,0,0,131,44,1,0,0,0,132,133,5,
		98,0,0,133,134,5,111,0,0,134,135,5,111,0,0,135,136,5,108,0,0,136,46,1,
		0,0,0,137,138,5,116,0,0,138,139,5,114,0,0,139,140,5,117,0,0,140,141,5,
		101,0,0,141,48,1,0,0,0,142,143,5,102,0,0,143,144,5,97,0,0,144,145,5,108,
		0,0,145,146,5,115,0,0,146,147,5,101,0,0,147,50,1,0,0,0,148,150,7,0,0,0,
		149,148,1,0,0,0,150,151,1,0,0,0,151,149,1,0,0,0,151,152,1,0,0,0,152,52,
		1,0,0,0,153,157,7,1,0,0,154,156,7,2,0,0,155,154,1,0,0,0,156,159,1,0,0,
		0,157,155,1,0,0,0,157,158,1,0,0,0,158,54,1,0,0,0,159,157,1,0,0,0,160,162,
		7,3,0,0,161,160,1,0,0,0,162,163,1,0,0,0,163,161,1,0,0,0,163,164,1,0,0,
		0,164,165,1,0,0,0,165,166,6,27,0,0,166,56,1,0,0,0,167,169,5,13,0,0,168,
		167,1,0,0,0,168,169,1,0,0,0,169,170,1,0,0,0,170,173,5,10,0,0,171,173,5,
		13,0,0,172,168,1,0,0,0,172,171,1,0,0,0,173,174,1,0,0,0,174,172,1,0,0,0,
		174,175,1,0,0,0,175,176,1,0,0,0,176,177,6,28,0,0,177,58,1,0,0,0,7,0,151,
		157,163,168,172,174,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
