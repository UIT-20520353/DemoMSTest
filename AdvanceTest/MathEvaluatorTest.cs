using AdvanceDemo;
using System.Reflection;

namespace AdvanceTest
{
    [TestClass]
    public class MathEvaluatorTest
    {
        private MathEvaluator _mathEvaluator = new MathEvaluator();

        [TestMethod]
        public void TestWithValidValue()
        {
            double expected = 23;
            double actual = _mathEvaluator.EvaluateExpression("6 * 4 - 1");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWithInvalidValue()
        {
            Assert.ThrowsException<ArgumentException>(() => _mathEvaluator.EvaluateExpression("6 * 4 ds 1"));
        }

        [TestMethod]
        [DataRow("4 + 5 - 2", 7)]
        [DataRow("12 * 5 / 3 + 5 - 7", 18)]
        [DataRow("3/2+1", 2.5)]
        public void TestEvaluateExpressionWithValidDataRow(string input, double expected)
        {
            double actualOutput = _mathEvaluator.EvaluateExpression(input);
            Assert.AreEqual(expected, actualOutput);
        }

        [TestMethod]
        public void TestEvaluateExpressionWithValidFiles()
        {
            for (int i = 1; i <= 3; i++)
            {
                string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"../../../../DataTest/Valid/Test{i}.txt");

                string[] lines = File.ReadAllLines(filePath);
                string input = lines[0];
                double expectedOutput = Double.Parse(lines[1]);

                double actualOutput = _mathEvaluator.EvaluateExpression(input);

                Assert.AreEqual(expectedOutput, actualOutput, $"Failed at Test{i}.txt");
            }
        }

        [TestMethod]
        public void TestEvaluateExpressionWithInvalidFiles()
        {
            for (int i = 1; i <= 3; i++)
            {
                string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"../../../../DataTest/Invalid/Test{i}.txt");

                string[] lines = File.ReadAllLines(filePath);
                string input = lines[0];

                Assert.ThrowsException<ArgumentException>(() => _mathEvaluator.EvaluateExpression(input), $"Failed at Test{i}.txt");
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            _mathEvaluator.Dispose();
        }
    }
}