using Compiler.CodeGeneration.VirtualMachine;
using System.Diagnostics;
using VirtualMachine;

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
            GlobalManager.Clear();
        }

        [TestMethod]
        public void TestAllPassing()
        {
            var testType = "Passing";
            foreach (var (id, contents) in TestFileManager.EnumerateTestInput(testType))
            {
                Console.WriteLine(id);
                var tree = Parser.Parse(contents).CheckSemantics();
                var instructions = CodeGenerator.Walk(tree);
                var asmOut = Machine.ToCode(instructions);
                TestFileManager.WriteTestOutput(_component, testType, id, asmOut);

                var outStream = new StringWriter();
                Machine.Run(instructions, Console.In, outStream);

                var expected = TestFileManager.GetTestReference(testType, id);
                Assert.IsNotNull(expected);
                var actual = TestFileManager.NormalizeText(outStream.ToString());
                Assert.AreEqual(expected, actual);

                GlobalManager.Clear();
            }
        }

        [TestMethod]
        public void TestAllReading()
        {
            var testType = "Reading";
            foreach (var (id, contents) in TestFileManager.EnumerateTestInput(testType))
            {
                Console.WriteLine(id);
                var tree = Parser.Parse(contents).CheckSemantics();
                var instructions = CodeGenerator.Walk(tree);

                var asmOut = Machine.ToCode(instructions);
                TestFileManager.WriteTestOutput(_component, testType, id, asmOut);

                var inStream = TestFileManager.GetTestInputStream(testType, id);
                var outStream = new StringWriter();
                Machine.Run(instructions, inStream, outStream);

                var expected = TestFileManager.GetTestReference(testType, id);
                Assert.IsNotNull(expected);
                var actual = TestFileManager.NormalizeText(outStream.ToString());
                Assert.AreEqual(actual, expected);

                GlobalManager.Clear();
            }
        }

        [TestMethod]
        public void TestAllFull() 
        {
            var testType = "Full";
            foreach (var (id, path) in TestFileManager.EnumerateFullTests())
            {
                Console.WriteLine(id);
                var proc = new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mcc.exe"),
                        Arguments = "main.mc -r",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true,
                        WorkingDirectory = path
                    }
                };

                proc.Start();
                var output = proc.StandardOutput.ReadToEnd();
                var error = proc.StandardError.ReadToEnd();
                if (error != null && error.Length > 0)
                {
                    Console.Error.WriteLine(id);
                    Console.Error.WriteLine(error);
                    Console.Error.WriteLine();
                    Assert.Fail();
                }

                var expected = TestFileManager.GetTestReference(testType, id);
                Assert.IsNotNull(expected);
                var actual = TestFileManager.NormalizeText(output);
                Assert.AreEqual(actual, expected);
            }
        }
    }
}
