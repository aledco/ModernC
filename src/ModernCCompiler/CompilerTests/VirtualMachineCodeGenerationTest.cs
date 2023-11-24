using Compiler.ErrorHandling;
using Compiler.ParseAbstraction;
using Compiler.TreeWalking.CodeGeneration.VirtualMachine;
using Compiler.TreeWalking.TypeCheck;
using Compiler.VirtualMachine;

namespace CompilerTests
{
    [TestClass]
    public class VirtualMachineCodeGenerationTest
    {
        private readonly string _component = "VirtualMachineCodeGeneration";

        [TestInitialize]
        public void Setup()
        {
            ErrorHandler.Testing = true;
        }

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

                var asmOut = Machine.ToCode(instructions);
                TestFileManager.WriteTestOutput(_component, testType, Id, asmOut);

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
