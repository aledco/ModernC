using Compiler.Models.NameResolution;
using System.Text.Json.Serialization;

namespace Compiler.Models.Tree
{
    public class FunctionDefinition : AbstractSyntaxTree
    {
        public IdNode Id { get; }
        public IList<Parameter> Parameters { get; }
        public TypeNode ReturnType { get; }
        public CompoundStatement Body { get; }

        public Scope? FunctionScope { get; set; }

        public int Size { get; set; }
        public List<string> RegisterPool { get; set; }

        [JsonIgnore]
        public string EnterLabel
        {
            get
            {
                if (Id.Symbol == null)
                {
                    throw new Exception("Symbol was null");
                }

                return Id.Symbol.Name;
            }
        }

        [JsonIgnore]
        public string ReturnLabel
        {
            get
            {
                if (Id.Symbol == null)
                {
                    throw new Exception("Symbol was null");
                }

                return $"{Id.Symbol.Name}_return";
            }
        }

        public FunctionDefinition(Span span, IdNode id, IList<Parameter> parameters, TypeNode returnType, CompoundStatement body) : base(span)
        {
            ReturnType = returnType;
            Id = id;
            Parameters = parameters;
            Body = body;
            RegisterPool = new List<string>();
        }
    }
}
