grammar ModernC;

/*
 * Parsing rules
 */
program
    : functionDefinition functionDefinition* EOF;

functionDefinition
    : type id '(' parameterList? ')' compoundStatement;

parameterList
    : parameter (',' parameter)*;

parameter
    : type id;

type
    : VOID_TYPE
    | primitiveType
    | functionType;

primitiveType
    : INT_TYPE 
    | BYTE_TYPE
    | FLOAT_TYPE
    | BOOL_TYPE;

functionType
    : 'func' '(' typeList ')';

typeList
    : type (',' type)*;

compoundStatement
    : '{' statement* returnStatement? '}';

statement
    : simpleStatement ';'
    | ifStatement
    | whileStatement
    | forStatement
    | compoundStatement;

simpleStatement
    : printStatement
    | readStatement
    | variableDefinitionStatement
    | assignmentStatement
    | incrementStatement
    | variableDefinitionAndAssignmentStatement
    | callStatement;

printStatement
    : 'print' expression;

readStatement
    : primitiveType? id 'read';

variableDefinitionStatement
    : type id;

variableDefinitionAndAssignmentStatement
    : type id '=' expression;

assignmentStatement
    : expression ('='|'+='|'-='|'*='|'/=') expression;

incrementStatement
    : expression ('++'|'--');

callStatement
    : callExpression;

ifStatement
    : 'if' expression compoundStatement elifPart* elsePart?;

elifPart
    : 'elif' expression compoundStatement;

elsePart
    : 'else' compoundStatement;

whileStatement
    : 'while' expression compoundStatement;

forStatement
    : 'for' simpleStatement ';' expression ';' simpleStatement compoundStatement;

returnStatement
    : 'return' expression? ';';

expression
    : expression 'or' orExpression
    | orExpression;

orExpression
    : orExpression 'and' andExpression
    | andExpression;

andExpression
    : andExpression ('=='|'<'|'<='|'>'|'>=') comparison
    | comparison;

comparison
    : comparison ('+'|'-') term
    | term;

term
    : term ('*'|'/') factor
    | factor;

factor
    : unaryExpression
    | callExpression
    | intLiteral
    | byteLiteral
    | floatLiteral
    | boolLiteral
    | idExpression
    | '(' expression ')';

unaryExpression
    : ('-'|'not') factor;

callExpression
    : idExpression '(' argumentList? ')';

argumentList
    : expression (',' expression)*;

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

id
    : ID;

/*
 * Lexing rules
 */

// types
VOID_TYPE           : 'void';
INT_TYPE            : 'int';
BYTE_TYPE           : 'byte';
FLOAT_TYPE          : 'float';
BOOL_TYPE           : 'bool';

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
