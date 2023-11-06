namespace CompilerTests;

using Compiler.ParseAbstraction;

[TestClass]
public class ParserTest
{
    [TestMethod]
    public void TestAll()
    {
        foreach (var file in Directory.GetFiles("C:\\LocalFiles\\ModernC\\src\\CompilerTests\\Tests\\")) // TODO get path better
        {
            var input = File.ReadAllText(file);
            var tree = Parser.Parse(input);

            Assert.IsNotNull(tree);
        }
    }
}