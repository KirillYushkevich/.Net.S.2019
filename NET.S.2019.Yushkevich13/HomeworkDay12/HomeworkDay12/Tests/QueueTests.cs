using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using HomeworkDay12.Queue;

namespace HomeworkDay12.Tests
{
    class QueueTests
    {
        private static IEnumerable<TestCaseData> testCaseData
        {
            get
            {
                yield return new TestCaseData(
                arg: new int[] { 1, 2, 3, 4 });
            }
        }

        [Test]
        public void IsEmptyTest()
        {
            GenericQueue<int> queue = new GenericQueue<int>();
            Assert.AreEqual(true, queue.IsEmpty());
            queue.Enqueue(1);
            Assert.AreEqual(false, queue.IsEmpty());
        }

        [TestCaseSource(nameof(testCaseData))]
        public void EnqueTest(int[] arg)
        {
            GenericQueue<int> queue = new GenericQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            Assert.AreEqual(queue.ToArray(), arg);
        }

        [TestCaseSource(nameof(testCaseData))]
        public void DequeueTest(int[] arg)
        {
            GenericQueue<int> queue = new GenericQueue<int>(arg);
            queue.Dequeue();
            queue.Dequeue();
            Assert.AreEqual(new int[] { 3, 4 }, queue.ToArray());
        }

        [TestCaseSource(nameof(testCaseData))]
        public void PeekTest(int[] arg)
        {
            GenericQueue<int> queue = new GenericQueue<int>(arg);
            queue.Dequeue();
            queue.Dequeue();
            Assert.AreEqual(3, queue.Peek());
        }

        [TestCaseSource(nameof(testCaseData))]
        public void ClearTest(int[] arg)
        {
            GenericQueue<int> queue = new GenericQueue<int>(arg);
            queue.Clear();
            Assert.AreEqual(true, queue.IsEmpty());
        }

        public void EnumeratorTest()
        {
            GenericQueue<int> queue = new GenericQueue<int>(Enumerable.Range(1, 1000).ToList());
            int i = 1;
            foreach (int elem in queue)
            {
                Assert.AreEqual(i, elem);
                i++;
            }
        }
    }
}
