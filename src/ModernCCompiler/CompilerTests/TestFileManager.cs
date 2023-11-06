namespace CompilerTests
{
    internal static class TestFileManager
    {
        private static readonly string _projectPath = "C:\\LocalFiles\\ModernC\\src\\ModernCCompiler\\CompilerTests"; // TODO handle this better
        
        public static string GetTestDir()
        {
            var baseDir = _projectPath;
            if (baseDir == null)
            {
                throw new Exception("Base test directory is null");
            }

            return Path.Combine(baseDir, "TestFiles");
        }

        public static string GetTestInputDir()
        {
            var testDir = GetTestDir();
            return Path.Combine(testDir, "In");
        }

        public static string ReadTestInput(string id)
        {
            var testInputDir = GetTestInputDir();
            var filePath = Path.Combine(testInputDir, $"test{id}.mc");
            return File.ReadAllText(filePath);
        }


        public static IEnumerable<(string Id, string Contents)> EnumerateTestInput()
        {
            var inputDir = GetTestInputDir();
            foreach (var file in Directory.EnumerateFiles(inputDir))
            {
                var id = Path.GetFileName(file).Replace("test", "").Replace(".mc", "");
                yield return (id, File.ReadAllText(file));
            }
        }

        public static string GetTestOutputDir(string testType)
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

            return testTypeDir;
        }

        public static void WriteTestOutput(string testType, string id, string output)
        {
            var testOutputDir = GetTestOutputDir(testType);
            var filePath = Path.Combine(testOutputDir, $"test{id}.out");
            File.WriteAllText(filePath, output);
        }
    }
}
