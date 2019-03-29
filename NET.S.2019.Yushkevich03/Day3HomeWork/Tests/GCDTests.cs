using NUnit.Framework;

namespace Day3HomeWork.Tests
{
    public class GCDTests
    {
        [TestCase(new int[] { 12, 64, 10 }, ExpectedResult = 2)]
        [TestCase(new int[] { 12, 64, 100, 20 }, ExpectedResult = 4)]
        [TestCase(new int[] { 1, 10 }, ExpectedResult = 1)]
        [TestCase(new int[] { 5, 10 }, ExpectedResult = 5)]
        [TestCase(new int[] { 24, 24 }, ExpectedResult = 24)]
        [TestCase(new int[] { 0, 0 }, ExpectedResult = 0)]
        [TestCase(new int[] { 5, 10 }, ExpectedResult = 5)]
        [TestCase(new int[] { 5, 0 }, ExpectedResult = 5)]
        [TestCase(new int[] { 0, 15 }, ExpectedResult = 15)]
        [TestCase(new int[] { -5, 10 }, ExpectedResult = 5)]
        public static int StandartGCDTests(params int[] actual)
        {
            return GCDService.GCD(actual).Result;
        }

        [TestCase(new int[] { 12, 64, 10 }, ExpectedResult = 2)]
        [TestCase(new int[] { 12, 64, 100, 20 }, ExpectedResult = 4)]
        [TestCase(new int[] { 1, 10 }, ExpectedResult = 1)]
        [TestCase(new int[] { 5, 10 }, ExpectedResult = 5)]
        [TestCase(new int[] { 24, 24 }, ExpectedResult = 24)]
        [TestCase(new int[] { 0, 0 }, ExpectedResult = 0)]
        [TestCase(new int[] { 5, 10 }, ExpectedResult = 5)]
        [TestCase(new int[] { 5, 0 }, ExpectedResult = 5)]
        [TestCase(new int[] { 0, 15 }, ExpectedResult = 15)]
        [TestCase(new int[] { -5, 10 }, ExpectedResult = 5)]
        public static int StainGCDTests(params int[] actual)
        {
            return GCDService.StainGCD(actual).Result;
        }
    }
}
