﻿namespace Compiler.Models.Tree
{
    public class ReturnStatement : Statement
    {
        public Expression? Expression { get; }

        public ReturnStatement(Span span, Expression? expression) : base(span)
        {
            Expression = expression;
        }

        public override string ToString()
        {
            return $"ReturnStatement(Span={Span}, Expression={Expression})";
        }
    }
}
