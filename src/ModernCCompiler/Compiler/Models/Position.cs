namespace Compiler.Models
{
    /// <summary>
    /// The position.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Gets the line.
        /// </summary>
        public int Line { get; }

        /// <summary>
        /// Gets the column.
        /// </summary>
        public int Column { get; }

        /// <summary>
        /// Instantiates a new instance of a <see cref="Position"/>.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="column">The column.</param>
        public Position(int line, int column)
        {
            Line = line;
            Column = column;
        }

        public override string ToString()
        {
            return $"{Line}:{Column}";
        }
    }
}
