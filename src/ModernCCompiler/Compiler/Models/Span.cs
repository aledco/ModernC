namespace Compiler.Models
{
    public class Span
    {
        public Position Start { get; }
        public Position End { get; }

        public Span(Position start, Position end)
        {
            Start = start;
            End = end;
        }

        public Span(int a, int b, int c, int d) 
        {
            Start = new Position(a, b);
            End = new Position(c, d);
        }

        public override string ToString()
        {
            return Start.ToString();
        }

        public static Span operator+(Span span, Span other)
        {
            return new Span(span.Start, other.End);
        }
    }
}
