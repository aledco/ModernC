grammar ModernC;

/*
 * Parsing rules
 */
program
    : (topLevelStatement|definition|functionDefinition)* EOF;

topLevelStatement
    : variableDefinitionStatement ';'
    | variableDefinitionAndAssignmentStatement ';';

functionDefinition
    : type id '(' parameterList? ')' compoundStatement;

parameterList
    : parameter (',' parameter)*;

parameter
    : type id;

definition
    : structDefinition;

structDefinition
     : STRUCT userDefinedType '{' structFieldDefinition+ '}';

structFieldDefinition
    : type id ';'
    | type id '=' expression ';';
    
type
    : VOID_TYPE
    | primitiveType
    | type '[' intLiteral ']' // array type
    | functionType
    | userDefinedType; // user-defined type

primitiveType
    : INT_TYPE 
    | BYTE_TYPE
    | FLOAT_TYPE
    | BOOL_TYPE;

functionType
    : FUNC '(' typeList ')';

userDefinedType
    : id;

typeList
    : type (',' type)*;

statement
    : simpleStatement ';'
    | breakStatement
    | continueStatement
    | returnStatement
    | exitStatement
    | ifStatement
    | whileStatement
    | doWhileStatement
    | forStatement
    | compoundStatement;

simpleStatement
    : printStatement
    | printlnStatement
    | variableDefinitionStatement
    | assignmentStatement
    | incrementStatement
    | variableDefinitionAndAssignmentStatement
    | callStatement;

compoundStatement
    : '{' statement* '}';

printStatement
    : PRINT expression;

printlnStatement
    : PRINTLN expression;

variableDefinitionStatement
    : type id;

variableDefinitionAndAssignmentStatement
    : type id '=' expression;

assignmentStatement
    : expression ('='|'+='|'-='|'*='|'/='|'%=') expression;

incrementStatement
    : expression ('++'|'--');

callStatement
    : tailedExpression;

ifStatement
    : IF expression compoundStatement elifPart* elsePart?;

elifPart
    : ELIF expression compoundStatement;

elsePart
    : ELSE compoundStatement;

whileStatement
    : WHILE expression compoundStatement;

doWhileStatement
    : DO compoundStatement WHILE expression ';';

forStatement
    : FOR simpleStatement ';' expression ';' simpleStatement compoundStatement;

breakStatement
    : BREAK ';';

continueStatement
    : CONTINUE ';';

returnStatement
    : RETURN expression? ';'
    | OK ';';

exitStatement
    : EXIT expression ';';

expression
    : expression OR orExpression
    | orExpression;

orExpression
    : orExpression AND andExpression
    | andExpression;

andExpression
    : andExpression ('=='|'!='|'<'|'<='|'>'|'>=') comparison
    | comparison;

comparison
    : comparison ('+'|'-') term
    | term;

term
    : term ('*'|'/'|'%') factor
    | factor;

factor
    : unaryExpression
    | tailedExpression
    | readExpression
    | intLiteral
    | byteLiteral
    | floatLiteral
    | boolLiteral
    | complexLiteral
    | idExpression
    | '(' expression ')';

unaryExpression
    : ('-'|NOT) factor;

tailedExpression
    : idExpression (callExpressionTail|arrayExpressionTail|fieldAccessExpressionTail)
    | tailedExpression (callExpressionTail|arrayExpressionTail|fieldAccessExpressionTail);

callExpressionTail
    : '(' argumentList? ')';

argumentList
    : expression (',' expression)*;

arrayExpressionTail
    : '[' expression ']';

fieldAccessExpressionTail
    : '.' id;

readExpression
    : READ;

intLiteral
    : INT;

byteLiteral
    : ASCII_CHAR | ESCAPED_ASCII_CHAR | INT;

floatLiteral
    : FLOAT | INT;

boolLiteral
    : TRUE | FALSE;

idExpression
    : id;

complexLiteral
    : arrayLiteral
    | structLiteral;

arrayLiteral
    : '[' expressionList ']';

expressionList
    : expression (',' expression)*;

structLiteral
    : '{' (structLiteralField ',')* structLiteralField? '}';

structLiteralField
    : id '=' expression;

id
    : ID;

/*
 * Lexing rules
 */

// type keywords
VOID_TYPE           : 'void';
INT_TYPE            : 'int';
BYTE_TYPE           : 'byte';
FLOAT_TYPE          : 'float';
BOOL_TYPE           : 'bool';
ARR                 : 'arr';
FUNC                : 'func';

// other keywords
PRINT               : 'print';
PRINTLN             : 'println';
READ                : 'read';
IF                  : 'if';
ELIF                : 'elif';
ELSE                : 'else';
WHILE               : 'while';
DO                  : 'do';
FOR                 : 'for';
BREAK               : 'break';
CONTINUE            : 'continue';
RETURN              : 'return';
OK                  : 'ok';
EXIT                : 'exit';
NOT                 : 'not';
OR                  : 'or';
AND                 : 'and';
STRUCT              : 'struct';

TRUE                : 'true';    
FALSE               : 'false';
FLOAT               : [0-9]* '.' [0-9]+;
INT                 : [0-9]+;
ID                  : [a-zA-Z_][a-zA-Z0-9_]*;
ASCII_CHAR          : '\'' . '\'';
ESCAPED_ASCII_CHAR  : '\'' '\\' . '\'';
COMMENT             : '//' .*? '\n' -> skip;
WHITESPACE          : (' '|'\t')+ -> skip ;
NEWLINE             : ('\r'? '\n' | '\r')+ -> skip ;
