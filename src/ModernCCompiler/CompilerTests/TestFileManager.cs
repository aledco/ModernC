using System.Reflection;

namespace CompilerTests
{
    internal static class TestFileManager
    {
        public static string GetTestDir()
        {
            var baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
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

        public static string ReadTestInput(string fileNumber)
        {
            var testInputDir = GetTestInputDir();
            var filePath = Path.Combine(testInputDir, $"test{fileNumber}.mc");
            return File.ReadAllText(filePath);
        }

        public static string GetTestOutputDir(string testType)
        {
            var testDir = GetTestDir();
            var outputDir = Path.Combine(testDir, $"{testType}Out");
            if (!Directory.Exists(outputDir)) 
            {
                Directory.CreateDirectory(outputDir);
            }

            return outputDir;
        }

        public static void WriteTestOutput(string testType, string fileNumber, string output)
        {
            var testOutputDir = GetTestOutputDir(testType);
            var filePath = Path.Combine(testOutputDir, $"test{fileNumber}.out");
            File.WriteAllText(filePath, output);
        }
    }
}
