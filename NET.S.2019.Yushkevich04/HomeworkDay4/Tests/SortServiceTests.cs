using System.Collections.Generic;
using NUnit.Framework;
using System;

namespace HomeworkDay4.Tests
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
                    new int[] { 1, 2, 3, 4 },
                    new int[] { 11, 34, 67 },
                    new int[] { 88, 23 },
                    new int[] { 0, 45, 78, 53, 99 }
                },
                arg2: new int[][]
                {
                    new int[] { 1, 2, 3, 4 },
                    new int[] { 88, 23 },
                    new int[] { 11, 34, 67 },
                    new int[] { 0, 45, 78, 53, 99 }
                });

                yield return new TestCaseData(
                arg1: new int[][]
                {
                    new int[] { 5, 7, 254, 0 },
                    new int[] { 641, 34, 37 },
                    new int[] { 88, 223,123 },
                    new int[] { 0, 45, 78, 53, 99 }
                },
                arg2: new int[][]
                {
                   new int[] { 5, 7, 254, 0 },
                   new int[] { 0, 45, 78, 53, 99 },
                   new int[] { 88, 223,123 },
                   new int[] { 641, 34, 37 },
                });

                yield return new TestCaseData(
                arg1: new int[][]
                {
                    new int[] { 1, 1, 1, 1 },
                    new int[] { 1, 1, 1 },
                    new int[] { 1, 1 },
                    new int[] { 1, 1, 1, 1, 1 }
                },
                arg2: new int[][]
                {
                   new int[] { 1, 1 },
                   new int[] { 1, 1, 1 },
                   new int[] { 1, 1, 1, 1 },
                   new int[] { 1, 1, 1, 1, 1 }
                });
            }
        }
        private static IEnumerable<TestCaseData> OrdeSumDescendingDataCases
        {
            get
            {
                yield return new TestCaseData(arg1: new int[][]
                 {
                    new int[] { 1, 2, 3, 4 },
                    new int[] { 11, 34, 67 },
                    new int[] { 88, 23 },
                    new int[] { 0, 45, 78, 53, 99 }
                 },
                 arg2: new int[][]
                 {
                     new int[] { 0, 45, 78, 53, 99 },
                     new int[] { 11, 34, 67 },
                     new int[] { 88, 23 },
                     new int[] { 1, 2, 3, 4 },
                 });

                yield return new TestCaseData(arg1: new int[][]
               {
                   new int[] { 0, 45, 78, 53, 99 },
                   new int[] { 5, 7, 254, 0 },
                   new int[] { 88, 223,123 },
                   new int[] { 641, 34, 37 },

               },
               arg2: new int[][]
               {
                    new int[] { 641, 34, 37 },
                    new int[] { 88, 223,123 },
                    new int[] { 0, 45, 78, 53, 99 },
                    new int[] { 5, 7, 254, 0 },
               });

                yield return new TestCaseData(arg1: new int[][]
               {
                    new int[] { 1, 1, 1, 1 },
                    new int[] { 1, 1, 1 },
                    new int[] { 1, 1 },
                    new int[] { 1, 1, 1, 1, 1 }
               },
               arg2: new int[][]
               {
                   new int[] { 1, 1, 1, 1, 1 },
                   new int[] { 1, 1, 1, 1 },
                   new int[] { 1, 1, 1 },
                   new int[] { 1, 1 },
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
                    new int[] { 1, 2, 3, 4 },
                    new int[] { 11, 34, 67 },
                    new int[] { 88, 23 },
                    new int[] { 0, 45, 78, 53, 99 }
                },
                arg2: new int[][]
                {
                    new int[] { 1, 2, 3, 4 },
                    new int[] { 11, 34, 67 },
                    new int[] { 88, 23 },
                    new int[] { 0, 45, 78, 53, 99 }
                });

                yield return new TestCaseData(
                arg1: new int[][]
                {
                    new int[] { 5, 7, 254, 0 },
                    new int[] { 641, 34, 37 },
                    new int[] { 88, 223,123 },
                    new int[] { 0, 45, 78, 53, 99 }
                },
                arg2: new int[][]
                {
                   new int[] { 0, 45, 78, 53, 99 },
                   new int[] { 88, 223,123 },
                   new int[] { 5, 7, 254, 0 },
                   new int[] { 641, 34, 37 },
                });

                yield return new TestCaseData(
                arg1: new int[][]
                {
                    new int[] { 1, 1, 1, 1 },
                    new int[] { 1, 1, 1 },
                    new int[] { 1, 1 },
                    new int[] { 1, 1, 1, 1, 1 }
                },
                arg2: new int[][]
                {
                   new int[] { 1, 1, 1, 1 },
                   new int[] { 1, 1, 1 },
                   new int[] { 1, 1 },
                   new int[] { 1, 1, 1, 1, 1 }
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
                    new int[] { 1, 2, 3, 4 },
                    new int[] { 11, 34, 67 },
                    new int[] { 88, 23 },
                    new int[] { 0, 45, 78, 53, 99 }
                },
                arg2: new int[][]
                {
                    new int[] { 0, 45, 78, 53, 99 },
                    new int[] { 88, 23 },
                    new int[] { 11, 34, 67 },
                    new int[] { 1, 2, 3, 4 },
                });

                yield return new TestCaseData(
                arg1: new int[][]
                {
                   new int[] { 0, 45, 78, 53, 99 },
                   new int[] { 88, 223,123 },
                   new int[] { 5, 7, 254, 0 },
                   new int[] { 641, 34, 37 },
                },
                arg2: new int[][]
                {
                   new int[] { 641, 34, 37 },
                   new int[] { 5, 7, 254, 0 },
                   new int[] { 88, 223,123 },
                   new int[] { 0, 45, 78, 53, 99 }
                });

                yield return new TestCaseData(
                arg1: new int[][]
                {
                    new int[] { 1, 1, 1, 1 },
                    new int[] { 1, 1, 1 },
                    new int[] { 1, 1 },
                    new int[] { 1, 1, 1, 1, 1 }
                },
                arg2: new int[][]
                {
                   new int[] { 1, 1, 1, 1, 1 },
                   new int[] { 1, 1 },
                   new int[] { 1, 1, 1 },
                   new int[] { 1, 1, 1, 1 },
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
                    new int[] { 1, 2, 3, 4 },
                    new int[] { 11, 34, 67 },
                    new int[] { 88, 23 },
                    new int[] { 0, 45, 78, 53, 99 }
                },
                arg2: new int[][]
                {
                    new int[] { 0, 45, 78, 53, 99 },
                    new int[] { 1, 2, 3, 4 },
                    new int[] { 11, 34, 67 },
                    new int[] { 88, 23 },
                });

                yield return new TestCaseData(
                arg1: new int[][]
                {
                    new int[] { 5, 7, 254, 0 },
                    new int[] { 0, 45, 78, 53, 99 },
                    new int[] { 641, 34, 37 },
                    new int[] { 88, 223,123 },
                },
                arg2: new int[][]
                {
                   new int[] { 5, 7, 254, 0 },
                   new int[] { 0, 45, 78, 53, 99 },
                   new int[] { 641, 34, 37 },
                   new int[] { 88, 223,123 },
                });

                yield return new TestCaseData(
                arg1: new int[][]
                {
                    new int[] { 1, 1, 1, 1 },
                    new int[] { 1, 1, 1 },
                    new int[] { 1, 1 },
                    new int[] { 1, 1, 1, 1, 1 }
                },
                arg2: new int[][]
                {
                   new int[] { 1, 1, 1, 1 },
                   new int[] { 1, 1, 1 },
                   new int[] { 1, 1 },
                   new int[] { 1, 1, 1, 1, 1 }
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
                    new int[] { 1, 2, 3, 4 },
                    new int[] { 11, 34, 67 },
                    new int[] { 88, 23 },
                    new int[] { 0, 45, 78, 53, 99 }
                },
                arg2: new int[][]
                {
                    new int[] { 88, 23 },
                    new int[] { 11, 34, 67 },
                    new int[] { 1, 2, 3, 4 },
                    new int[] { 0, 45, 78, 53, 99 },
                });

                yield return new TestCaseData(
                arg1: new int[][]
                {
                    new int[] { 5, 7, 254, 0 },
                    new int[] { 0, 45, 78, 53, 99 },
                    new int[] { 641, 34, 37 },
                    new int[] { 88, 223,123 },
                },
                arg2: new int[][]
                {
                   new int[] { 88, 223,123 },
                   new int[] { 641, 34, 37 },
                   new int[] { 0, 45, 78, 53, 99 },
                   new int[] { 5, 7, 254, 0 },
                });

                yield return new TestCaseData(
                arg1: new int[][]
                {
                    new int[] { 1, 1, 1, 1 },
                    new int[] { 1, 1, 1 },
                    new int[] { 1, 1 },
                    new int[] { 1, 1, 1, 1, 1 }
                },
                arg2: new int[][]
                {
                   new int[] { 1, 1, 1, 1, 1 },
                   new int[] { 1, 1 },
                   new int[] { 1, 1, 1 },
                   new int[] { 1, 1, 1, 1 },
                });
            }
        }
        #endregion
        [TestCaseSource(nameof(OrdeSumDataCases))]
        public void OrderBySumTest(int[][] actual, int[][] expected)
        {
            var result = JaggedArraySortService.OrderBySum(actual);
            Assert.AreEqual(result, expected);
        }

        [TestCaseSource(nameof(OrdeMaxDataCases))]
        public void OrderByMaxTest(int[][] actual, int[][] expected)
        {
            var result = JaggedArraySortService.OrderByMax(actual);
            Assert.AreEqual(result, expected);
        }

        [TestCaseSource(nameof(OrdeMinDataCases))]
        public void OrderByMinTest(int[][] actual, int[][] expected)
        {
            var result = JaggedArraySortService.OrderByMin(actual);
            Assert.AreEqual(result, expected);
        }

        [TestCaseSource(nameof(OrdeSumDescendingDataCases))]
        public void OrderBySumDescendingTest(int[][] actual, int[][] expected)
        {
            var result = JaggedArraySortService.OrderBySumDescending(actual);
            Assert.AreEqual(result, expected);
        }

        [TestCaseSource(nameof(OrdeMaxDescandingDataCases))]
        public void OrderByMaxDescendingTest(int[][] actual, int[][] expected)
        {
            var result = JaggedArraySortService.OrderByMaxDescending(actual);
            Assert.AreEqual(result, expected);
        }

        [TestCaseSource(nameof(OrdeMinDescandingDataCases))]
        public void OrderByMinDescendingTest(int[][] actual, int[][] expected)
        {
            var result = JaggedArraySortService.OrderByMinDescending(actual);
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void SortServiceExceptionTests()
        {
            Assert.Throws<ArgumentNullException>(() => JaggedArraySortService.OrderByMax(null));
            Assert.Throws<ArgumentNullException>(() => JaggedArraySortService.OrderByMin(null));
            Assert.Throws<ArgumentNullException>(() => JaggedArraySortService.OrderBySum(null));
            Assert.Throws<ArgumentNullException>(() => JaggedArraySortService.OrderByMaxDescending(null));
            Assert.Throws<ArgumentNullException>(() => JaggedArraySortService.OrderByMinDescending(null));
            Assert.Throws<ArgumentNullException>(() => JaggedArraySortService.OrderBySumDescending(null));
            Assert.Throws<ArgumentException>(() => JaggedArraySortService.OrderByMax(new int[0][]));
            Assert.Throws<ArgumentException>(() => JaggedArraySortService.OrderByMin(new int[0][]));
            Assert.Throws<ArgumentException>(() => JaggedArraySortService.OrderBySum(new int[0][]));
            Assert.Throws<ArgumentException>(() => JaggedArraySortService.OrderByMaxDescending(new int[0][]));
            Assert.Throws<ArgumentException>(() => JaggedArraySortService.OrderByMinDescending(new int[0][]));
            Assert.Throws<ArgumentException>(() => JaggedArraySortService.OrderBySumDescending(new int[0][]));
        }
    }
}
