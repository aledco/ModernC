using Compiler.ParseAbstraction;
using System.Text.Json;

namespace CompilerTests;

[TestClass]
public class ParserTest
{
    private readonly string _outputType = "Parser";

    [TestMethod]
    public void TestAllInputs()
    {
        foreach (var (Id, Contents) in TestFileManager.EnumerateTestInput())
        {
            var tree = Parser.Parse(Contents);
            Assert.IsNotNull(tree);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var treeJson = JsonSerializer.Serialize(tree, options: options);
            TestFileManager.WriteTestOutput(_outputType, Id, treeJson);
        }
    }
}