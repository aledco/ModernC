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
    : printStatement
    | variableDefinitionStatement
    | assignmentStatement
    | variableDefinitionAndAssignmentStatement
    | callStatement
    | compoundStatement;

printStatement
    : 'print' expression ';';

variableDefinitionStatement
    : type id ';';

variableDefinitionAndAssignmentStatement
    : type id '=' expression ';';

assignmentStatement
    : expression '=' expression ';';

callStatement
    : callExpression ';';

returnStatement
    : 'return' expression? ';';

expression
    : expression ('+'|'-'|'or') term
    | term;

term
    : term ('*'|'/'|'and') factor
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