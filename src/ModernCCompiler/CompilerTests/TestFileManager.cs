namespace CompilerTests
{
    internal static class TestFileManager
    {
        private static readonly string _projectPath;
        
        static TestFileManager()
        {
            string startupPath = AppDomain.CurrentDomain.BaseDirectory;
            var pathItems = startupPath.Split(Path.DirectorySeparatorChar);
            var pos = pathItems.Reverse().ToList().FindIndex(x => string.Equals("bin", x));
            _projectPath = String.Join(Path.DirectorySeparatorChar.ToString(), pathItems.Take(pathItems.Length - pos - 1));
        }

        public static string GetTestDir()
        {
            var baseDir = _projectPath;
            if (baseDir == null)
            {
                throw new Exception("Base test directory is null");
            }

            return Path.Combine(baseDir, "TestFiles");
        }

        public static string GetTestInputDir(string testType)
        {
            var testDir = GetTestDir();
            return Path.Combine(testDir, "In", testType);
        }

        public static string ReadTestInput(string testType, string id)
        {
            var testInputDir = GetTestInputDir(testType);
            var filePath = Path.Combine(testInputDir, $"test{id}.mc");
            return File.ReadAllText(filePath);
        }


        public static IEnumerable<(string Id, string Contents)> EnumerateTestInput(string testType)
        {
            var inputDir = GetTestInputDir(testType);
            foreach (var file in Directory.EnumerateFiles(inputDir, "*.mc"))
            {
                var id = Path.GetFileName(file).Replace("test", "").Replace(".mc", "");
                yield return (id, File.ReadAllText(file));
            }
        }

        public static string GetTestOutputDir(string testType, string component)
        {
            var testDir = GetTestDir();
            var outputDir = Path.Combine(testDir, "Out");
            if (!Directory.Exists(outputDir)) 
            {
                Directory.CreateDirectory(outputDir);
            }

            var testTypeDir = Path.Combine(outputDir, testType);
            if (!Directory.Exists(testTypeDir))
            {
                Directory.CreateDirectory(testTypeDir);
            }

            var componentDir = Path.Combine(testTypeDir, component);
            if (!Directory.Exists(componentDir))
            {
                Directory.CreateDirectory(componentDir);
            }

            return componentDir;
        }

        public static void WriteTestOutput(string testType, string component, string id, string output)
        {
            var testOutputDir = GetTestOutputDir(testType, component);
            var filePath = Path.Combine(testOutputDir, $"test{id}.out");
            File.WriteAllText(filePath, output);
        }

        public static string GetTestReferenceDir(string testType)
        {
            var testDir = GetTestDir();
            return Path.Combine(testDir, "Ref", testType);
        }

        public static string? GetTestReference(string testType, string id)
        {
            var refDir = GetTestReferenceDir(testType);
            var refFile = Path.Combine(refDir, $"test{id}.ref");
            if (Path.Exists(refFile))
            {
                return NormalizeText(File.ReadAllText(refFile));
            }

            return null;
        }

        public static StringReader GetTestInputStream(string testType, string id)
        {
            var inputDir = GetTestInputDir(testType);
            var inFile = Path.Combine(inputDir, $"test{id}.in");
            return new StringReader(NormalizeText(File.ReadAllText(inFile)));
        }

        public static string NormalizeText(string output)
        {
            return output
                .Replace("\r\n", "\n")
                .Replace("\t", "    ")
                .Trim();
        }
    }
}
