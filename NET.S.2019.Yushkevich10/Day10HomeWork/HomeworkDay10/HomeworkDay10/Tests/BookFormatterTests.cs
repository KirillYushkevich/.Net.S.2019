using HomeworkDay10;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Day10HomeWork.Tests
{
    class BookFormatterTests
    {
        private static Book b = new Book("9788497821292", "Ray Bradbury", "The Martian Chronicles", "Mass Market Paperback", 1950, 222, 8);

        private static IEnumerable<TestCaseData> BookFormaterTestDataCases
        {
            get
            {
                yield return new TestCaseData(
                arg1: "T",
                arg2: "Title:" + b.Title + "\n");

                yield return new TestCaseData(
                arg1: "A",
                arg2: "Author:" + b.Author + "\n");

               yield return new TestCaseData(
               arg1: "PB",
               arg2: "Publisher:" + b.Publisher + "\n");

            }
        }

        [Test]
        public static void BookFormatTest()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Author:" + b.Author + "\n");
            sb.Append("Title:" + b.Title + "\n");
            Assert.AreEqual(sb.ToString(), b.ToString("Short", null));
            sb.Append("Publisher:" + b.Publisher + "\n");
            sb.Append("Publish Year:" + b.PublishYear + "\n");
            Assert.AreEqual(sb.ToString(), b.ToString("Medium", null));
        }

        [TestCaseSource(nameof(BookFormaterTestDataCases))]
        public void BookFormatterTest(string format,string expected)
        {
            Assert.AreEqual(expected, string.Format(new BookFormater(), "{0:" + format + "}", b));
        }

    }
}