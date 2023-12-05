using Compiler.ErrorHandling;
using Compiler.ParseAbstraction;
using Compiler.TreeWalking.CodeGeneration.VirtualMachine;
using Compiler.TreeWalking.TypeCheck;
using Compiler.Utils;
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
            ErrorHandler.ThrowExceptions = true;
        }

        [TestCleanup]
        public void Cleanup()
        {
            Globals.Clear();
        }

        [TestMethod]
        public void TestAllPassing()
        {
            var testType = "Passing";
            foreach (var (Id, Contents) in TestFileManager.EnumerateTestInput(testType))
            {
                Console.WriteLine(Id);
                var tree = Parser.Parse(Contents);
                GlobalTypeChecker.Walk(tree);
                LocalTypeChecker.Walk(tree);
                var instructions = CodeGenerator.Walk(tree);

                var asmOut = Machine.ToCode(instructions);
                TestFileManager.WriteTestOutput(_component, testType, Id, asmOut);

                var outStream = new StringWriter();
                Machine.Run(instructions, Console.In, outStream);

                var expected = TestFileManager.GetTestReference(testType, Id);
                Assert.IsNotNull(expected);
                var actual = TestFileManager.NormalizeText(outStream.ToString());
                Assert.AreEqual(expected, actual);

                Globals.Clear();
            }
        }

        [TestMethod]
        public void TestAllReading()
        {
            var testType = "Reading";
            foreach (var (Id, Contents) in TestFileManager.EnumerateTestInput(testType))
            {
                Console.WriteLine(Id);
                var tree = Parser.Parse(Contents);
                GlobalTypeChecker.Walk(tree);
                LocalTypeChecker.Walk(tree);
                var instructions = CodeGenerator.Walk(tree);

                var asmOut = Machine.ToCode(instructions);
                TestFileManager.WriteTestOutput(_component, testType, Id, asmOut);

                var inStream = TestFileManager.GetTestInputStream(testType, Id);
                var outStream = new StringWriter();
                Machine.Run(instructions, inStream, outStream);

                var expected = TestFileManager.GetTestReference(testType, Id);
                Assert.IsNotNull(expected);
                var actual = TestFileManager.NormalizeText(outStream.ToString());
                Assert.AreEqual(actual, expected);

                Globals.Clear();
            }
        }
    }
}
