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

        public override string ToString()
        {
            var parameters = "[";
            foreach (var parameter in Parameters)
            {
                parameters += parameter.ToString() + ", ";
            }

            parameters += "]";
            return $"ParameterList(Span={Span}, Parameters={parameters})";
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
