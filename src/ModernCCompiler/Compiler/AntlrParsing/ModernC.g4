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
    | variableDefinitionStatement
    | assignmentStatement
    | incrementStatement
    | variableDefinitionAndAssignmentStatement
    | callStatement;

printStatement
    : 'print' expression;

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
BOOL_TYPE           : 'bool';

TRUE                : 'true';    
FALSE               : 'false';
INT                 : [0-9]+;
ID                  : [a-zA-Z_][a-zA-Z0-9_]*;
WHITESPACE          : (' '|'\t')+ -> skip ;
NEWLINE             : ('\r'? '\n' | '\r')+ -> skip ;