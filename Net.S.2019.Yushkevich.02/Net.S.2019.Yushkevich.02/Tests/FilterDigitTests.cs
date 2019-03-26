using NUnit.Framework;
using System.Collections.Generic;

namespace Net.S._2019.Yushkevich._02.Tests
{
    [TestFixture]
    class FilterDigitTests
    {
        private static IEnumerable<TestCaseData> DataCases
        {
            get
            {
                yield return new TestCaseData(arg1: new List<int> { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 },arg2: 7 ,arg3: new List<int> { 7, 70, 17  });
                yield return new TestCaseData(arg1: new List<int> { 7 }, arg2: 7, arg3: new List<int> { 7 });
                yield return new TestCaseData(arg1: new List<int> { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, arg2: 5, arg3: new List<int> { 5, 15});
                yield return new TestCaseData(arg1: new List<int> { 7, 1, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, arg2: 2, arg3: new List<int> {});
                yield return new TestCaseData(arg1: new List<int> { 1 }, arg2: 7, arg3: new List<int> { });

            }
        }
        [TestCaseSource(nameof(DataCases))]
        public void FilterDigitTest(List<int> actual,int digit ,List<int> expected)
        {
            Day2Methods.FilterDigit(ref actual, digit);
            Assert.AreEqual(expected, actual);
        }
    }
}
