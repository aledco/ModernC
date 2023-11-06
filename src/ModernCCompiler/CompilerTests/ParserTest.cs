using Compiler.ParseAbstraction;

namespace CompilerTests;

[TestClass]
public class ParserTest
{
    private static TestContext? _testContext;

    [ClassInitialize]
    public static void SetupTests(TestContext testContext)
    {
        _testContext = testContext;
    }

    [TestMethod]
    public void Test001()
    {
        var input = GetTestInput();
        var tree = Parser.Parse(input);
        Assert.IsNotNull(tree);
    }

    private static string GetTestInput()
    {
        if (_testContext == null)
        {
            throw new Exception("Test contex is null");
        }

        var testNumber = _testContext.TestName.Replace("Test", "");
        return TestFileManager.ReadTestInput(testNumber);
    }
}