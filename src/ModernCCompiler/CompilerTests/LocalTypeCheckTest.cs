using Compiler.Models.Tree;

namespace CompilerTests;

/// <summary>
/// Tests the local type checker.
/// </summary>
[TestClass]
public class LocalTypeCheckTest
{
    private readonly string _component = "LocalTypeCheck";

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
    /// Passing tests should produce type decorated trees.
    /// </summary>
    [TestMethod]
    public void TestAllPassing()
    {
        var testType = "Passing";
        foreach (var (id, contents) in TestFileManager.EnumerateTestInput(testType))
        {
            var tree = Parser.Parse(contents);
            tree.CheckGlobalSemantics();
            tree.CheckLocalSemantics();
            foreach (var functionDefinition in tree.FunctionDefinitions)
            {
                TestCompoundStatement(functionDefinition.Body);
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

    /// <summary>
    /// Local Semantic Errors should throw an error.
    /// </summary>
    [TestMethod]
    public void TestAllLocalSemanticErrors()
    {
        var testType = "LocalSemanticErrors";
        foreach (var (id, contents) in TestFileManager.EnumerateTestInput(testType))
        {
            Console.WriteLine(id);
            var tree = Parser.Parse(contents);
            tree.CheckGlobalSemantics();
            try
            {
                tree.CheckLocalSemantics();
                Assert.Fail();
            }
            catch
            {
                Assert.IsTrue(true);
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

    private void TestExpression(Expression expression)
    {
        if (expression is IdExpression idExpression)
        {
            Assert.IsNotNull(idExpression.Id.Symbol);
        }
        else if (expression is BinaryOperatorExpression binaryOperatorExpression)
        {
            TestExpression(binaryOperatorExpression.LeftOperand);
            TestExpression(binaryOperatorExpression.RightOperand);
        }
        if (expression is UnaryOperatorExpression unaryOperatorExpression)
        {
            TestExpression(unaryOperatorExpression.Operand);
        }
    }

    private void TestCompoundStatement(CompoundStatement compoundStatement)
    {
        Assert.IsNotNull(compoundStatement.LocalScope);
        foreach (var statement in compoundStatement.Statements)
        {
            if (statement is CompoundStatement compoundStatement2)
            {
                TestCompoundStatement(compoundStatement2);
            }
            else if (statement is VariableDefinitionStatement variableDefinitionStatement)
            {
                Assert.IsNotNull(variableDefinitionStatement.Id.Symbol);
            }
            else if (statement is AssignmentStatement assignmentStatement)
            {
                TestExpression(assignmentStatement.Left);
                TestExpression(assignmentStatement.Right);
            }
            else if (statement is VariableDefinitionAndAssignmentStatement variableDefinitionAndAssignmentStatement)
            {
                Assert.IsNotNull(variableDefinitionAndAssignmentStatement.Id.Symbol);
            }
        }
    }

}