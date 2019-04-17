using System.Collections.Generic;
using NUnit.Framework;
using System;

namespace HomeworkDay10.Tests
{
    public class SortServiceTests
    {
        #region DataCases
        private static IEnumerable<TestCaseData> OrdeSumDataCases
        {
            get
            {
                yield return new TestCaseData(
                   arg1: new int[][]
                   {
                    new int[] { 1, 8, 9},
                    new int[] { 4, 5, 12,},
                    new int[] { 3, 6, 11},
                    new int[] { 2, 7, 10 },
                   },
                   arg2: new int[][]
                   {
                    new int[] { 1, 8, 9},
                    new int[] { 2, 7, 10 },
                    new int[] { 3, 6, 11},
                    new int[] { 4, 5, 12,},
                   });
            }
        }
        private static IEnumerable<TestCaseData> OrdeSumDescendingDataCases
        {
            get
            {
                yield return new TestCaseData(
                arg1: new int[][]
                {
                    new int[] { 1, 8, 9},
                    new int[] { 4, 5, 12,},
                    new int[] { 3, 6, 11},
                    new int[] { 2, 7, 10 },
                },
                arg2: new int[][]
                {
                    new int[] { 4, 5, 12,},
                    new int[] { 3, 6, 11},
                    new int[] { 2, 7, 10 },
                    new int[] { 1, 8, 9},                         
                });
            }
        }
        private static IEnumerable<TestCaseData> OrdeMaxDataCases
        {
            get
            {
                yield return new TestCaseData(
                arg1: new int[][]
                {
                    new int[] { 1, 8, 9},
                    new int[] { 4, 5, 12,},
                    new int[] { 3, 6, 11},
                    new int[] { 2, 7, 10 },
                },
                 arg2: new int[][]
                 {
                    new int[] { 1, 8, 9},
                    new int[] { 2, 7, 10 },
                    new int[] { 3, 6, 11},
                    new int[] { 4, 5, 12,},
                 });
            }
        }
        private static IEnumerable<TestCaseData> OrdeMaxDescandingDataCases
        {
            get
            {
                yield return new TestCaseData(
                 arg1: new int[][]
                 {
                    new int[] { 1, 8, 9},
                    new int[] { 4, 5, 12,},
                    new int[] { 3, 6, 11},
                    new int[] { 2, 7, 10 },
                 },
                 arg2: new int[][]
                {
                    new int[] { 4, 5, 12,},
                    new int[] { 3, 6, 11},
                    new int[] { 2, 7, 10 },
                    new int[] { 1, 8, 9},
                });
               
            }
        }
        private static IEnumerable<TestCaseData> OrdeMinDataCases
        {
            get
            {
                yield return new TestCaseData(
                arg1: new int[][]
                {
                    new int[] { 1, 8, 9},
                    new int[] { 4, 5, 12,},
                    new int[] { 3, 6, 11},
                    new int[] { 2, 7, 10 },
                },
                arg2: new int[][]
                {
                    new int[] { 1, 8, 9},
                    new int[] { 2, 7, 10 },
                    new int[] { 3, 6, 11},
                    new int[] { 4, 5, 12,},      
                });
            }
        }
        private static IEnumerable<TestCaseData> OrdeMinDescandingDataCases
        {
            get
            {
                yield return new TestCaseData(
                arg1: new int[][]
                {
                    new int[] { 1, 8, 9},
                    new int[] { 4, 5, 12,},
                    new int[] { 3, 6, 11},
                    new int[] { 2, 7, 10 },
                },
                arg2: new int[][]
                {
                    new int[] { 4, 5, 12,},
                    new int[] { 3, 6, 11},
                    new int[] { 2, 7, 10 },
                    new int[] { 1, 8, 9},
                });
            }
        }
        #endregion
        [TestCaseSource(nameof(OrdeSumDataCases))]
        public void OrderBySumTest(int[][] actual, int[][] expected)
        {
            InterfaceSortService.Sort(InterfaceSortService.SortMode.Sum, false, actual);
            Assert.AreEqual(actual, expected);
        }

        [TestCaseSource(nameof(OrdeMaxDataCases))]
        public void OrderByMaxTest(int[][] actual, int[][] expected)
        {
            InterfaceSortService.Sort(InterfaceSortService.SortMode.Max, false, actual);
            Assert.AreEqual(actual, expected);
        }

        [TestCaseSource(nameof(OrdeMinDataCases))]
        public void OrderByMinTest(int[][] actual, int[][] expected)
        {
            InterfaceSortService.Sort(InterfaceSortService.SortMode.Min, false, actual);
            Assert.AreEqual(actual, expected);
        }

        [TestCaseSource(nameof(OrdeSumDescendingDataCases))]
        public void OrderBySumDescendingTest(int[][] actual, int[][] expected)
        {
            InterfaceSortService.Sort(InterfaceSortService.SortMode.Sum, true, actual);
            Assert.AreEqual(actual, expected);
        }

        [TestCaseSource(nameof(OrdeMaxDescandingDataCases))]
        public void OrderByMaxDescendingTest(int[][] actual, int[][] expected)
        {
            InterfaceSortService.Sort(InterfaceSortService.SortMode.Max, true, actual);
            Assert.AreEqual(actual, expected);
        }

        [TestCaseSource(nameof(OrdeMinDescandingDataCases))]
        public void OrderByMinDescendingTest(int[][] actual, int[][] expected)
        {
            InterfaceSortService.Sort(InterfaceSortService.SortMode.Min, true, actual);
            Assert.AreEqual(actual, expected);
        }


    }
}
