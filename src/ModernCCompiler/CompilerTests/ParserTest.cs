using Compiler.ParseAbstraction;
using System.Text.Json;

namespace CompilerTests;

/// <summary>
/// Tests the parser.
/// </summary>
[TestClass]
public class ParserTest
{
    private readonly string _component = "Parser";

    /// <summary>
    /// Passing tests should produce non null abstract syntax trees.
    /// </summary>
    [TestMethod]
    public void TestAllPassing()
    {
        var testType = "Passing";
        foreach (var (Id, Contents) in TestFileManager.EnumerateTestInput(testType))
        {
            var tree = Parser.Parse(Contents);
            Assert.IsNotNull(tree);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var treeJson = JsonSerializer.Serialize(tree, options: options);
            TestFileManager.WriteTestOutput(_component, testType, Id, treeJson);
        }
    }

    /// <summary>
    /// Parse Error tests should throw an exception while parsing.
    /// </summary>
    [TestMethod]
    public void TestAllParseErrors()
    {
        var testType = "ParseErrors";
        foreach (var (Id, Contents) in TestFileManager.EnumerateTestInput(testType))
        {
            Assert.ThrowsException<Exception>(() => Parser.Parse(Contents));
        }
    }

    /// <summary>
    /// Type Error tests should produce non null abstract syntax trees.
    /// </summary>
    [TestMethod]
    public void TestAllTypeErrors()
    {
        var testType = "TypeErrors";
        foreach (var (Id, Contents) in TestFileManager.EnumerateTestInput(testType))
        {
            var tree = Parser.Parse(Contents);
            Assert.IsNotNull(tree);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var treeJson = JsonSerializer.Serialize(tree, options: options);
            TestFileManager.WriteTestOutput(_component, testType, Id, treeJson);
        }
    }
}