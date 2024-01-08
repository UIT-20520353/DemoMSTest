using SimpleProject;

namespace MSTestSimpleProject
{
    [TestClass]
    public class CaculatorTest
    {
        private readonly Caculator _caculator;

        public CaculatorTest()
        {
            _caculator = new Caculator();
        }

        [TestMethod]
        public void TestPlusFunction()
        {
            int expected = 10;
            int actual = _caculator.PlusTwoNumber(3, 7);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDivide() 
        {
            int expected = 6;
            int actual = _caculator.Divide(48, 8);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestMinus()
        {
            int expected = 15;
            int actual = _caculator.MinusTwoNumber(54, 39);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDivideByZero()
        {
            Assert.ThrowsException<ArithmeticException>(() => _caculator.Divide(41, 0));
        }

        [TestMethod]
        public void TestDevideWithDoubleResult()
        {
            double expected = 1.5;
            double actual = _caculator.Divide(3, 2);

            Assert.AreEqual(expected, actual);
        }

    }
}