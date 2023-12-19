namespace Compiler.Input
{
    /// <summary>
    /// The file reader.
    /// </summary>
    public class FileReader
    {
        private readonly string _path;

        /// <summary>
        /// Instantiates a new instance of a <see cref="FileReader"/>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <exception cref="Exception"></exception>
        public FileReader(string path) 
        {
            if (!File.Exists(path))
            {
                throw new Exception($"{path} does not exist");
            }

            _path = path;
        }

        /// <summary>
        /// Reads input from the file.
        /// </summary>
        /// <returns>The file content.</returns>
        public string Read()
        {
            return File.ReadAllText(_path);
        }
    }
}
