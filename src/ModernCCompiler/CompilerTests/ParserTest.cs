namespace CompilerTests;

/// <summary>
/// Tests the parser.
/// </summary>
[TestClass]
public class ParserTest
{
    private readonly string _component = "Parse";

    [TestInitialize]
    public void Setup()
    {
        ErrorHandler.ThrowExceptions = true;
    }

    [TestCleanup]
    public void Cleanup()
    {
        GlobalManager.Clear();
    }

    /// <summary>
    /// Passing tests should produce non null abstract syntax trees.
    /// </summary>
    [TestMethod]
    public void TestAllPassing()
    {
        var testType = "Passing";
        foreach (var (id, contents) in TestFileManager.EnumerateTestInput(testType))
        {
            Console.WriteLine(id);
            var tree = Parser.Parse(contents);
            Assert.IsNotNull(tree);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var treeJson = JsonSerializer.Serialize(tree, options: options);
            TestFileManager.WriteTestOutput(_component, testType, id, treeJson);

            GlobalManager.Clear();
        }
    }

    /// <summary>
    /// Type Error tests should produce non null abstract syntax trees.
    /// </summary>
    [TestMethod]
    public void TestAllSemanticErrors()
    {
        var testType = "GlobalSemanticErrors";
        foreach (var (id, contents) in TestFileManager.EnumerateTestInput(testType))
        {
            var tree = Parser.Parse(contents);
            Assert.IsNotNull(tree);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var treeJson = JsonSerializer.Serialize(tree, options: options);
            TestFileManager.WriteTestOutput(_component, testType, id, treeJson);

            GlobalManager.Clear();
        }

        testType = "LocalSemanticErrors";
        foreach (var (id, contents) in TestFileManager.EnumerateTestInput(testType))
        {
            var tree = Parser.Parse(contents);
            Assert.IsNotNull(tree);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var treeJson = JsonSerializer.Serialize(tree, options: options);
            TestFileManager.WriteTestOutput(_component, testType, id, treeJson);

            GlobalManager.Clear();
        }
    }
}