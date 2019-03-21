﻿using System.Collections.Generic;
using NUnit.Framework;

namespace NET.S._2019.Yushkevich._01
{
    [TestFixture]
    class Tests
    {
        private static IEnumerable<TestCaseData> DataCases
        {
            get
            {
                yield return new TestCaseData(arg1: new int[] { 1, 2 }, arg2: new int[] { 1, 2 });
                yield return new TestCaseData(arg1: new int[] { 2, 1 }, arg2: new int[] { 1, 2 });
                yield return new TestCaseData(arg1: new int[] { 1 }, arg2: new int[] { 1 });
                yield return new TestCaseData(arg1: new int[] { 217, 4, 68, 7, 925 }, arg2: new int[] { 4, 7, 68, 217, 925 });
            }
        }
        [TestCaseSource(nameof(DataCases))]
        public void QSortTests(int[] actual, int[] expected)
        {
            actual.QSort(0, actual.Length - 1);

            Assert.AreEqual(expected, actual);
        }
        [TestCaseSource(nameof(DataCases))]
        public void MergeSortTests(int[] actual, int[] expected)
        {
            actual.MergeSort(0, actual.Length - 1);

            Assert.AreEqual(expected, actual);
        }
    }
}
