namespace Compiler.Models
{
    internal class Position
    {
        public int Line { get; }
        public int Column { get; }
        public Position(int line, int column)
        {
            this.Line = line;
            this.Column = column;
        }

        public override string ToString()
        {
            return $"{Line}:{Column}";
        }
    }
}
