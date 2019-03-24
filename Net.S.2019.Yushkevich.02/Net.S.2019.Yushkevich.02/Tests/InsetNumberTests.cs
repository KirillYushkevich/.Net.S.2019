
using System.Collections.Generic;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Net.S._2019.Yushkevich._02.Tests
{
    [TestFixture]
    class nUnitTests
    {
        private static IEnumerable<TestCaseData> DataCases
        {
            get
            {
                yield return new TestCaseData(arg1: new int[] { 15, 15, 0, 0 }, arg2: 15);
                yield return new TestCaseData(arg1: new int[] { 8, 15, 0, 0 }, arg2: 9);
                yield return new TestCaseData(arg1: new int[] { 8, 15, 3, 8 }, arg2: 120);
            }
        }
        [TestCaseSource(nameof(DataCases))]
        public void InsertNumberTests(int[] actual, int expected)
        {
            int result = Day2Methods.InsertNumber(actual[0], actual[1], actual[2], actual[3]);

            NUnit.Framework.Assert.AreEqual(expected, result);
        }
    }
    [TestClass()]
    class MsUnitTests
    {
        [TestMethod]
        public void InsertNumberTests1()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(new int[] { 3, 3, 0, 0 }, 3);
        }
    }
}
