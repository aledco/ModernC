using Compiler.ParseAbstraction;
using Compiler.TreeWalking;
using System.Text.Json;

namespace CompilerTests;

/// <summary>
/// Tests the top level type checker.
/// </summary>
[TestClass]
public class TopLevelTypeCheckTest
{
    private readonly string _component = "TopLevelTypeCheck";

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
            var topLevelTypeChecker = new TopLevelTypeChecker();
            topLevelTypeChecker.Walk(tree);
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
        }
    }

    /// <summary>
    /// Top Level Semantic Errors tests should throw an exception.
    /// </summary>
    [TestMethod]
    public void TestAllTopLevelSemanticErrors()
    {
        var testType = "TopLevelSemanticErrors";
        foreach (var (_, Contents) in TestFileManager.EnumerateTestInput(testType))
        {
            var tree = Parser.Parse(Contents);

            var topLevelTypeChecker = new TopLevelTypeChecker();
            try
            {
                topLevelTypeChecker.Walk(tree);
                Assert.Fail();
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }
    }

    /// <summary>
    /// Local Semantic Errors should pass through the top level type checker.
    /// </summary>
    [TestMethod]
    public void TestAllLocalSemanticErrors()
    {
        var testType = "LocalSemanticErrors";
        foreach (var (Id, Contents) in TestFileManager.EnumerateTestInput(testType))
        {
            var tree = Parser.Parse(Contents);
            var topLevelTypeChecker = new TopLevelTypeChecker();
            topLevelTypeChecker.Walk(tree);
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
            TestFileManager.WriteTestOutput(_component, testType, Id, treeJson);
        }
    }
}