grammar ModernC;

/*
 * Parsing rules
 */
program
    : functionDefinition functionDefinition* EOF; // TODO add global statements

functionDefinition
    : type id '(' parameterList? ')' compoundStatement;

parameterList
    : parameter (',' parameter)*;

parameter
    : type id;

type
    : VOID_TYPE
    | primitiveType; // TODO add pointer, array, struct, enum, function, and typedef

primitiveType
    : INT_TYPE 
    | BOOL_TYPE;

compoundStatement
    : '{' statement* returnStatement? '}';

statement
    : printStatement
    | variableDefinitionStatement
    | assignmentStatement
    | variableDefinitionAndAssignmentStatement;

printStatement
    : 'print' expression ';';

variableDefinitionStatement
    : type id ';';

variableDefinitionAndAssignmentStatement
    : type id '=' expression ';';

assignmentStatement
    : expression '=' expression ';';

returnStatement
    : 'return' expression? ';';

expression
    : expression ('+'|'-'|'or') term // todo might want to make productions for each operator class and have asn ast node for operator
    | term;

term
    : term ('*'|'/'|'and') factor
    | factor;

factor
    : unaryExpression
    | intLiteral
    | boolLiteral
    | idExpression
    | '(' expression ')';

unaryExpression
    : ('-'|'not') factor;

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