namespace Compiler.Input
{
    public class FileReader : IReader
    {
        private readonly string _path;
        public FileReader(string path) 
        {
            if (!File.Exists(path))
            {
                throw new Exception($"{path} does not exist");
            }

            _path = path;
        }

        public string Read()
        {
            return File.ReadAllText(_path);
        }
    }
}
