using NUnit.Framework;
using System.Collections.Generic;

namespace HomeworkDay4.Tests
{
    class PolynomialTests
    {
        #region DataCases
        private static IEnumerable<TestCaseData> PolynomialMultiplyByNumberDataCases
        {
            get
            {
                yield return new TestCaseData(arg1: new Polynomial(new List<double> { 1, 1, 0, -2 }), arg2: 2, arg3: new Polynomial(new List<double> { 2, 2, 0, -4 }));
                yield return new TestCaseData(arg1: new Polynomial(new List<double> { 2, 3, 1, 4 }), arg2: 2, arg3: new Polynomial(new List<double> { 4, 6, 2, 8 }));
            }
        }
        private static IEnumerable<TestCaseData> PolynomialMultiplyByPolynomialDataCases
        {
            get
            {
                yield return new TestCaseData(arg1: new Polynomial(new List<double> { 1, 1, 0, -2 }), arg2: new Polynomial(new List<double> { 1, 1, 0, -2 }), arg3: new Polynomial(new List<double> { 4, 0, -4, -4, 1, 2, 1 }));
                yield return new TestCaseData(arg1: new Polynomial(new List<double> { 1, 0, 1, 0, -3, -3, 8, 2, -5 }), arg2: new Polynomial(new List<double> { 3, 0, 5, 0, -4, -9, 21 }), arg3: new Polynomial(new List<double> { 3, 8, -8, -18, 26, -18, 58, 49, -93, -143, 170, 87, -105 }));
            }
        }
        private static IEnumerable<TestCaseData> PolynomialAddPolynomialDataCases
        {
            get
            {
                yield return new TestCaseData(arg1: new Polynomial(new List<double> { 1, 1, 0, -2 }), arg2: new Polynomial(new List<double> { 1, 1, 0, -2 }), arg3: new Polynomial(new List<double> { 2, 2, 0, -4 }));
                yield return new TestCaseData(arg1: new Polynomial(new List<double> { 1, 0, -3, -3, 8, 2, -5 }), arg2: new Polynomial(new List<double> { 3, 0, 5, 0, -4, -9, 21 }), arg3: new Polynomial(new List<double> { 4, 0, 2, -3, 4, -7, 17 }));
            }
        }
        private static IEnumerable<TestCaseData> PolynomialSubstractPolynomialDataCases
        {
            get
            {
                yield return new TestCaseData(arg1: new Polynomial(new List<double> { 1, 1, 0, -2 }), arg2: new Polynomial(new List<double> { 1, 1, 0, -2 }), arg3: new Polynomial(new List<double> { 0, 0, 0, 4 }));
                yield return new TestCaseData(arg1: new Polynomial(new List<double> { 1, 0, -3, -3, 8, 2, -5 }), arg2: new Polynomial(new List<double> { 3, 0, 5, 0, -4, -9, 21 }), arg3: new Polynomial(new List<double> { -2, 0, -8, -3, 12, 11, -26 }));
            }
        }
        private static IEnumerable<TestCaseData> PolynomialEqualsPolynomialDataCases
        {
            get
            {
                yield return new TestCaseData(arg1: new Polynomial(new List<double> { 1, 1, 0, -2 }), arg2: new Polynomial(new List<double> { 1, 1, 0, -2 }), arg3: true);
                yield return new TestCaseData(arg1: new Polynomial(new List<double> { 1, 0, 1, 0, -3, -3, 8, 2, -5 }), arg2: new Polynomial(new List<double> { 3, 0, 5, 0, -4, -9, 21 }), arg3: false);
            }
        }
        private static IEnumerable<TestCaseData> PolynomialNotPolynomialDataCases
        {
            get
            {
                yield return new TestCaseData(arg1: new Polynomial(new List<double> { 1, 1, 0, -2 }), arg2: new Polynomial(new List<double> { 1, 1, 0, -2 }), arg3: false);
                yield return new TestCaseData(arg1: new Polynomial(new List<double> { 1, 0, 1, 0, -3, -3, 8, 2, -5 }), arg2: new Polynomial(new List<double> { 3, 0, 5, 0, -4, -9, 21 }), arg3: true);
            }
        }
        #endregion

        [TestCaseSource(nameof(PolynomialMultiplyByNumberDataCases))]
        public void PolynomialMultiplayByNumberTest(Polynomial actual, int number, Polynomial expected)
        {
            Polynomial result = actual * number;
            Assert.AreEqual(expected, result);
        }

        [TestCaseSource(nameof(PolynomialMultiplyByPolynomialDataCases))]
        public void PolynomialMultiplayByPolynomialTest(Polynomial actual, Polynomial secondPoly, Polynomial expected)
        {

            Polynomial result = actual * secondPoly;
            Assert.AreEqual(expected, result);
        }

        [TestCaseSource(nameof(PolynomialAddPolynomialDataCases))]
        public void PolynomialAddTest(Polynomial actual, Polynomial secondPoly, Polynomial expected)
        {
            Polynomial result = actual + secondPoly;
            Assert.AreEqual(expected, result);
        }

        [TestCaseSource(nameof(PolynomialSubstractPolynomialDataCases))]
        public void PolynomialSubstractTest(Polynomial actual, Polynomial secondPoly, Polynomial expected)
        {
            Polynomial result = actual - secondPoly;
            Assert.AreEqual(expected, result);
        }

        [TestCaseSource(nameof(PolynomialEqualsPolynomialDataCases))]
        public void PolynomialEqualsTest(Polynomial actual, Polynomial secondPoly, bool expected)
        {
            bool result = actual == secondPoly;
            Assert.AreEqual(expected, result);
        }

        [TestCaseSource(nameof(PolynomialNotPolynomialDataCases))]
        public void PolynomialNotTest(Polynomial actual, Polynomial secondPoly, bool expected)
        {
            bool result = actual != secondPoly;
            Assert.AreEqual(expected, result);
        }
    }
}
