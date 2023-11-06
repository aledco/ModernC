using System.Collections;

namespace Compiler.Models.Tree
{
    public class ParameterList : AbstractSyntaxTree, IEnumerable<Parameter>
    {
        public IEnumerable<Parameter> Parameters { get; }

        public ParameterList(Span span, IEnumerable<Parameter> parameters) : base(span)
        {
            Parameters = parameters;
        }

        public IEnumerator<Parameter> GetEnumerator()
        {
            return Parameters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Parameters.GetEnumerator();
        }
    }
}
