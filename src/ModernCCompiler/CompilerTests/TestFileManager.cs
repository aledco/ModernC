namespace CompilerTests
{
    /// <summary>
    /// The test file manager.
    /// </summary>
    public static class TestFileManager
    {
        private static readonly string _projectPath;
        
        /// <summary>
        /// Initializes the <see cref="TestFileManager"/>.
        /// </summary>
        static TestFileManager()
        {
            string startupPath = AppDomain.CurrentDomain.BaseDirectory;
            var pathItems = startupPath.Split(Path.DirectorySeparatorChar);
            var pos = pathItems.Reverse().ToList().FindIndex(x => string.Equals("bin", x));
            _projectPath = String.Join(Path.DirectorySeparatorChar.ToString(), pathItems.Take(pathItems.Length - pos - 1));
        }

        /// <summary>
        /// Gets the test directory.
        /// </summary>
        /// <returns>The path to the test directory.</returns>
        /// <exception cref="Exception"></exception>
        public static string GetTestDir()
        {
            var baseDir = _projectPath ?? throw new Exception("Base test directory is null");
            return Path.Combine(baseDir, "TestFiles");
        }

        /// <summary>
        /// Gets the test input directory.
        /// </summary>
        /// <param name="testType">The test type.</param>
        /// <returns>The path.</returns>
        public static string GetTestInputDir(string testType)
        {
            var testDir = GetTestDir();
            return Path.Combine(testDir, "In", testType);
        }
        
        /// <summary>
        /// Enumerates the test input.
        /// </summary>
        /// <param name="testType">The test type.</param>
        /// <returns>An enumerable of id, content pairs.</returns>
        public static IEnumerable<(string Id, string Contents)> EnumerateTestInput(string testType)
        {
            var inputDir = GetTestInputDir(testType);
            foreach (var file in Directory.EnumerateFiles(inputDir, "*.mc"))
            {
                var id = Path.GetFileName(file).Replace("test", "").Replace(".mc", "");
                yield return (id, File.ReadAllText(file));
            }
        }

        /// <summary>
        /// Enumerats the full tests.
        /// </summary>
        /// <returns>An enumerable of id, path pairs.</returns>
        public static IEnumerable<(string Id, string Path)> EnumerateFullTests()
        {
            var inputDir = GetTestInputDir("Full");
            foreach (var testDir in Directory.EnumerateDirectories(inputDir))
            {
                yield return (testDir.Split(Path.DirectorySeparatorChar).Last().Replace("test", ""), testDir);
            }
        }

        /// <summary>
        /// Gets the test output dir.
        /// </summary>
        /// <param name="testType">The test type.</param>
        /// <param name="component">The component.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Writes the test output.
        /// </summary>
        /// <param name="testType">The test type.</param>
        /// <param name="component">The component.</param>
        /// <param name="id">The id.</param>
        /// <param name="output">The output.</param>
        public static void WriteTestOutput(string testType, string component, string id, string output)
        {
            var testOutputDir = GetTestOutputDir(testType, component);
            var filePath = Path.Combine(testOutputDir, $"test{id}.out");
            File.WriteAllText(filePath, output);
        }

        /// <summary>
        /// Gets the test reference dir.
        /// </summary>
        /// <param name="testType">The test type.</param>
        /// <returns>The path.</returns>
        public static string GetTestReferenceDir(string testType)
        {
            var testDir = GetTestDir();
            return Path.Combine(testDir, "Ref", testType);
        }

        /// <summary>
        /// Gets the test reference.
        /// </summary>
        /// <param name="testType">The test type.</param>
        /// <param name="id">The id.</param>
        /// <returns>The test reference.</returns>
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

        /// <summary>
        /// Gets the test input stream.
        /// </summary>
        /// <param name="testType">The test type.</param>
        /// <param name="id">The id.</param>
        /// <returns>The test input stream.</returns>
        public static StringReader GetTestInputStream(string testType, string id)
        {
            var inputDir = GetTestInputDir(testType);
            var inFile = Path.Combine(inputDir, $"test{id}.in");
            return new StringReader(NormalizeText(File.ReadAllText(inFile)));
        }

        /// <summary>
        /// Normalizes text.
        /// </summary>
        /// <param name="output">The output.</param>
        /// <returns>The normalized output.</returns>
        public static string NormalizeText(string output)
        {
            return output
                .Replace("\r\n", "\n")
                .Replace("\t", "    ")
                .Trim();
        }
    }
}
