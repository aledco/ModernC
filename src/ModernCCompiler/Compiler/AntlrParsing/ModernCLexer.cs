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
		T__24=25, T__25=26, T__26=27, T__27=28, T__28=29, T__29=30, T__30=31, 
		T__31=32, T__32=33, VOID_TYPE=34, INT_TYPE=35, BOOL_TYPE=36, TRUE=37, 
		FALSE=38, INT=39, ID=40, WHITESPACE=41, NEWLINE=42;
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
		"T__25", "T__26", "T__27", "T__28", "T__29", "T__30", "T__31", "T__32", 
		"VOID_TYPE", "INT_TYPE", "BOOL_TYPE", "TRUE", "FALSE", "INT", "ID", "WHITESPACE", 
		"NEWLINE"
	};


	public ModernCLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public ModernCLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'('", "')'", "','", "'func'", "'{'", "'}'", "';'", "'print'", "'='", 
		"'+='", "'-='", "'*='", "'/='", "'++'", "'--'", "'if'", "'elif'", "'else'", 
		"'while'", "'for'", "'return'", "'or'", "'and'", "'=='", "'<'", "'<='", 
		"'>'", "'>='", "'+'", "'-'", "'*'", "'/'", "'not'", "'void'", "'int'", 
		"'bool'", "'true'", "'false'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, "VOID_TYPE", 
		"INT_TYPE", "BOOL_TYPE", "TRUE", "FALSE", "INT", "ID", "WHITESPACE", "NEWLINE"
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
		4,0,42,245,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,7,27,2,28,
		7,28,2,29,7,29,2,30,7,30,2,31,7,31,2,32,7,32,2,33,7,33,2,34,7,34,2,35,
		7,35,2,36,7,36,2,37,7,37,2,38,7,38,2,39,7,39,2,40,7,40,2,41,7,41,1,0,1,
		0,1,1,1,1,1,2,1,2,1,3,1,3,1,3,1,3,1,3,1,4,1,4,1,5,1,5,1,6,1,6,1,7,1,7,
		1,7,1,7,1,7,1,7,1,8,1,8,1,9,1,9,1,9,1,10,1,10,1,10,1,11,1,11,1,11,1,12,
		1,12,1,12,1,13,1,13,1,13,1,14,1,14,1,14,1,15,1,15,1,15,1,16,1,16,1,16,
		1,16,1,16,1,17,1,17,1,17,1,17,1,17,1,18,1,18,1,18,1,18,1,18,1,18,1,19,
		1,19,1,19,1,19,1,20,1,20,1,20,1,20,1,20,1,20,1,20,1,21,1,21,1,21,1,22,
		1,22,1,22,1,22,1,23,1,23,1,23,1,24,1,24,1,25,1,25,1,25,1,26,1,26,1,27,
		1,27,1,27,1,28,1,28,1,29,1,29,1,30,1,30,1,31,1,31,1,32,1,32,1,32,1,32,
		1,33,1,33,1,33,1,33,1,33,1,34,1,34,1,34,1,34,1,35,1,35,1,35,1,35,1,35,
		1,36,1,36,1,36,1,36,1,36,1,37,1,37,1,37,1,37,1,37,1,37,1,38,4,38,217,8,
		38,11,38,12,38,218,1,39,1,39,5,39,223,8,39,10,39,12,39,226,9,39,1,40,4,
		40,229,8,40,11,40,12,40,230,1,40,1,40,1,41,3,41,236,8,41,1,41,1,41,4,41,
		240,8,41,11,41,12,41,241,1,41,1,41,0,0,42,1,1,3,2,5,3,7,4,9,5,11,6,13,
		7,15,8,17,9,19,10,21,11,23,12,25,13,27,14,29,15,31,16,33,17,35,18,37,19,
		39,20,41,21,43,22,45,23,47,24,49,25,51,26,53,27,55,28,57,29,59,30,61,31,
		63,32,65,33,67,34,69,35,71,36,73,37,75,38,77,39,79,40,81,41,83,42,1,0,
		4,1,0,48,57,3,0,65,90,95,95,97,122,4,0,48,57,65,90,95,95,97,122,2,0,9,
		9,32,32,250,0,1,1,0,0,0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,1,0,0,
		0,0,11,1,0,0,0,0,13,1,0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,0,19,1,0,0,0,0,21,
		1,0,0,0,0,23,1,0,0,0,0,25,1,0,0,0,0,27,1,0,0,0,0,29,1,0,0,0,0,31,1,0,0,
		0,0,33,1,0,0,0,0,35,1,0,0,0,0,37,1,0,0,0,0,39,1,0,0,0,0,41,1,0,0,0,0,43,
		1,0,0,0,0,45,1,0,0,0,0,47,1,0,0,0,0,49,1,0,0,0,0,51,1,0,0,0,0,53,1,0,0,
		0,0,55,1,0,0,0,0,57,1,0,0,0,0,59,1,0,0,0,0,61,1,0,0,0,0,63,1,0,0,0,0,65,
		1,0,0,0,0,67,1,0,0,0,0,69,1,0,0,0,0,71,1,0,0,0,0,73,1,0,0,0,0,75,1,0,0,
		0,0,77,1,0,0,0,0,79,1,0,0,0,0,81,1,0,0,0,0,83,1,0,0,0,1,85,1,0,0,0,3,87,
		1,0,0,0,5,89,1,0,0,0,7,91,1,0,0,0,9,96,1,0,0,0,11,98,1,0,0,0,13,100,1,
		0,0,0,15,102,1,0,0,0,17,108,1,0,0,0,19,110,1,0,0,0,21,113,1,0,0,0,23,116,
		1,0,0,0,25,119,1,0,0,0,27,122,1,0,0,0,29,125,1,0,0,0,31,128,1,0,0,0,33,
		131,1,0,0,0,35,136,1,0,0,0,37,141,1,0,0,0,39,147,1,0,0,0,41,151,1,0,0,
		0,43,158,1,0,0,0,45,161,1,0,0,0,47,165,1,0,0,0,49,168,1,0,0,0,51,170,1,
		0,0,0,53,173,1,0,0,0,55,175,1,0,0,0,57,178,1,0,0,0,59,180,1,0,0,0,61,182,
		1,0,0,0,63,184,1,0,0,0,65,186,1,0,0,0,67,190,1,0,0,0,69,195,1,0,0,0,71,
		199,1,0,0,0,73,204,1,0,0,0,75,209,1,0,0,0,77,216,1,0,0,0,79,220,1,0,0,
		0,81,228,1,0,0,0,83,239,1,0,0,0,85,86,5,40,0,0,86,2,1,0,0,0,87,88,5,41,
		0,0,88,4,1,0,0,0,89,90,5,44,0,0,90,6,1,0,0,0,91,92,5,102,0,0,92,93,5,117,
		0,0,93,94,5,110,0,0,94,95,5,99,0,0,95,8,1,0,0,0,96,97,5,123,0,0,97,10,
		1,0,0,0,98,99,5,125,0,0,99,12,1,0,0,0,100,101,5,59,0,0,101,14,1,0,0,0,
		102,103,5,112,0,0,103,104,5,114,0,0,104,105,5,105,0,0,105,106,5,110,0,
		0,106,107,5,116,0,0,107,16,1,0,0,0,108,109,5,61,0,0,109,18,1,0,0,0,110,
		111,5,43,0,0,111,112,5,61,0,0,112,20,1,0,0,0,113,114,5,45,0,0,114,115,
		5,61,0,0,115,22,1,0,0,0,116,117,5,42,0,0,117,118,5,61,0,0,118,24,1,0,0,
		0,119,120,5,47,0,0,120,121,5,61,0,0,121,26,1,0,0,0,122,123,5,43,0,0,123,
		124,5,43,0,0,124,28,1,0,0,0,125,126,5,45,0,0,126,127,5,45,0,0,127,30,1,
		0,0,0,128,129,5,105,0,0,129,130,5,102,0,0,130,32,1,0,0,0,131,132,5,101,
		0,0,132,133,5,108,0,0,133,134,5,105,0,0,134,135,5,102,0,0,135,34,1,0,0,
		0,136,137,5,101,0,0,137,138,5,108,0,0,138,139,5,115,0,0,139,140,5,101,
		0,0,140,36,1,0,0,0,141,142,5,119,0,0,142,143,5,104,0,0,143,144,5,105,0,
		0,144,145,5,108,0,0,145,146,5,101,0,0,146,38,1,0,0,0,147,148,5,102,0,0,
		148,149,5,111,0,0,149,150,5,114,0,0,150,40,1,0,0,0,151,152,5,114,0,0,152,
		153,5,101,0,0,153,154,5,116,0,0,154,155,5,117,0,0,155,156,5,114,0,0,156,
		157,5,110,0,0,157,42,1,0,0,0,158,159,5,111,0,0,159,160,5,114,0,0,160,44,
		1,0,0,0,161,162,5,97,0,0,162,163,5,110,0,0,163,164,5,100,0,0,164,46,1,
		0,0,0,165,166,5,61,0,0,166,167,5,61,0,0,167,48,1,0,0,0,168,169,5,60,0,
		0,169,50,1,0,0,0,170,171,5,60,0,0,171,172,5,61,0,0,172,52,1,0,0,0,173,
		174,5,62,0,0,174,54,1,0,0,0,175,176,5,62,0,0,176,177,5,61,0,0,177,56,1,
		0,0,0,178,179,5,43,0,0,179,58,1,0,0,0,180,181,5,45,0,0,181,60,1,0,0,0,
		182,183,5,42,0,0,183,62,1,0,0,0,184,185,5,47,0,0,185,64,1,0,0,0,186,187,
		5,110,0,0,187,188,5,111,0,0,188,189,5,116,0,0,189,66,1,0,0,0,190,191,5,
		118,0,0,191,192,5,111,0,0,192,193,5,105,0,0,193,194,5,100,0,0,194,68,1,
		0,0,0,195,196,5,105,0,0,196,197,5,110,0,0,197,198,5,116,0,0,198,70,1,0,
		0,0,199,200,5,98,0,0,200,201,5,111,0,0,201,202,5,111,0,0,202,203,5,108,
		0,0,203,72,1,0,0,0,204,205,5,116,0,0,205,206,5,114,0,0,206,207,5,117,0,
		0,207,208,5,101,0,0,208,74,1,0,0,0,209,210,5,102,0,0,210,211,5,97,0,0,
		211,212,5,108,0,0,212,213,5,115,0,0,213,214,5,101,0,0,214,76,1,0,0,0,215,
		217,7,0,0,0,216,215,1,0,0,0,217,218,1,0,0,0,218,216,1,0,0,0,218,219,1,
		0,0,0,219,78,1,0,0,0,220,224,7,1,0,0,221,223,7,2,0,0,222,221,1,0,0,0,223,
		226,1,0,0,0,224,222,1,0,0,0,224,225,1,0,0,0,225,80,1,0,0,0,226,224,1,0,
		0,0,227,229,7,3,0,0,228,227,1,0,0,0,229,230,1,0,0,0,230,228,1,0,0,0,230,
		231,1,0,0,0,231,232,1,0,0,0,232,233,6,40,0,0,233,82,1,0,0,0,234,236,5,
		13,0,0,235,234,1,0,0,0,235,236,1,0,0,0,236,237,1,0,0,0,237,240,5,10,0,
		0,238,240,5,13,0,0,239,235,1,0,0,0,239,238,1,0,0,0,240,241,1,0,0,0,241,
		239,1,0,0,0,241,242,1,0,0,0,242,243,1,0,0,0,243,244,6,41,0,0,244,84,1,
		0,0,0,7,0,218,224,230,235,239,241,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
