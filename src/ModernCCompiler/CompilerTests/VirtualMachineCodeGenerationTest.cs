using Compiler.ParseAbstraction;
using Compiler.TreeWalking.CodeGeneration.VirtualMachine;
using Compiler.TreeWalking.TypeCheck;
using Compiler.VirtualMachine;

namespace CompilerTests
{
    [TestClass]
    public class VirtualMachineCodeGenerationTest
    {
        [TestMethod]
        public void TestAllPassing()
        {
            var testType = "Passing";
            foreach (var (Id, Contents) in TestFileManager.EnumerateTestInput(testType))
            {
                Console.WriteLine(Id);
                var tree = Parser.Parse(Contents);
                TopLevelTypeChecker.Walk(tree);
                LocalTypeChecker.Walk(tree);
                var instructions = CodeGenerator.Walk(tree);
                var outStream = new StringWriter();
                Machine.Run(instructions, outStream);

                var testReference = TestFileManager.GetTestReference(testType, Id);
                if (testReference  != null) 
                {
                    Assert.AreEqual(outStream.ToString().Trim(), testReference.Trim());
                }
            }
        }
    }
}
