using System.Collections;

namespace Compiler.Models.Tree
{
    public class ParameterList : AbstractSyntaxTree
    {
        public IList<Parameter> Parameters { get; }

        public ParameterList(Span span, IList<Parameter> parameters) : base(span)
        {
            Parameters = parameters;
        }

        public ParameterList() : base(new Span(0, 0, 0, 0))
        {
            Parameters = new List<Parameter>();
        }
    }
}
