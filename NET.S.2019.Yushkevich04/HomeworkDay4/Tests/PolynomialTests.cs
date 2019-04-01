using NUnit.Framework;

namespace HomeworkDay4.Tests
{
    class PolynomialTests
    {
        [Test]
        public void PolynomialMultiplayByNumberTest()
        {
            Polynomial actual = new Polynomial(4);
            actual[3] = 1;
            actual[2] = 1;
            actual[1] = 0;
            actual[0] = -2;
            Polynomial expected = new Polynomial(4);
            expected[3] = 2;
            expected[2] = 2;
            expected[1] = 0;
            expected[0] = -4;
            int number = 2;
            Polynomial result = actual * number;
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void PolynomialMultiplayByPolynomialTest()
        {
            Polynomial actual = new Polynomial(4);
            actual[3] = 1;
            actual[2] = 1;
            actual[1] = 0;
            actual[0] = -2;
            Polynomial expected = new Polynomial(7);
            expected[6] = 4;
            expected[5] = 0;
            expected[4] = -4;
            expected[3] = -4;
            expected[2] = 1;
            expected[1] = 2;
            expected[0] = 1;
            Polynomial result = actual * actual;
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void PolynomialAddTest()
        {
            Polynomial actual = new Polynomial(4);
            actual[3] = 1;
            actual[2] = 1;
            actual[1] = 0;
            actual[0] = -2;
            Polynomial expected = new Polynomial(4);
            expected[3] = 2;
            expected[2] = 2;
            expected[1] = 0;
            expected[0] = -4;
            Polynomial result = actual + actual;
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void PolynomialSubstractTest()
        {
            Polynomial actual = new Polynomial(4);
            actual[3] = 1;
            actual[2] = 1;
            actual[1] = 0;
            actual[0] = -2;
            Polynomial expected = new Polynomial(4);
            expected[3] = 0;
            expected[2] = 0;
            expected[1] = 0;
            expected[0] = 0;
            Polynomial result = actual - actual;
            Assert.AreEqual(expected, result);
        }
    }
}
