namespace CompilerTests;

/// <summary>
/// Tests the top level type checker.
/// </summary>
[TestClass]
public class GlobalTypeCheckTest
{
    private readonly string _component = "GlobalTypeCheck";

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
    /// Passing tests should produce globally type decorated trees.
    /// </summary>
    [TestMethod]
    public void TestAllPassing()
    {
        var testType = "Passing";
        foreach (var (Id, Contents) in TestFileManager.EnumerateTestInput(testType))
        {
            var tree = Parser.Parse(Contents);
            tree.CheckGlobalSemantics();
            Assert.IsNotNull(tree.GlobalScope);
            foreach (var functionDefinition in tree.FunctionDefinitions)
            {
                Assert.IsNotNull(functionDefinition.FunctionScope);
                Assert.IsNotNull(functionDefinition.Id.Symbol);
            }
           

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var treeJson = JsonSerializer.Serialize(tree, options: options);
            TestFileManager.WriteTestOutput(_component, testType, Id, treeJson);

            GlobalManager.Clear();
        }
    }

    /// <summary>
    /// Top Level Semantic Errors tests should throw an exception.
    /// </summary>
    [TestMethod]
    public void TestAllGlobalSemanticErrors()
    {
        
        var testType = "GlobalSemanticErrors";
        foreach (var (id, contents) in TestFileManager.EnumerateTestInput(testType))
        {
            Console.WriteLine(id);
            var tree = Parser.Parse(contents);
            try
            {
                tree.CheckGlobalSemantics();
                Assert.Fail();
            }
            catch
            {
                Assert.IsTrue(true);
            }

            GlobalManager.Clear();
        }
    }

    /// <summary>
    /// Local Semantic Errors should pass through the top level type checker.
    /// </summary>
    [TestMethod]
    public void TestAllLocalSemanticErrors()
    {
        var testType = "LocalSemanticErrors";
        foreach (var (id, contents) in TestFileManager.EnumerateTestInput(testType))
        {
            var tree = Parser.Parse(contents);
            tree.CheckGlobalSemantics();
            Assert.IsNotNull(tree.GlobalScope);
            foreach (var functionDefinition in tree.FunctionDefinitions)
            {
                Assert.IsNotNull(functionDefinition.FunctionScope);
            }

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