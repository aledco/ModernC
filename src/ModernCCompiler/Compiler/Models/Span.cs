namespace Compiler.Models
{
    /// <summary>
    /// The span.
    /// </summary>
    public class Span
    {
        /// <summary>
        /// Gets the start position.
        /// </summary>
        public Position Start { get; }

        /// <summary>
        /// Gets the end position.
        /// </summary>
        public Position End { get; }

        /// <summary>
        /// Instantiates a new instance of a <see cref="Span"/>.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        public Span(Position start, Position end)
        {
            Start = start;
            End = end;
        }

        /// <summary>
        /// Instantiates a new instance of a <see cref="Span"/>.
        /// </summary>
        /// <param name="a">The a coordinate.</param>
        /// <param name="b">The b coordinate.</param>
        /// <param name="c">The c coordinate.</param>
        /// <param name="d">The d coordinate.</param>
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
