using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using HomeworkDay12.BinarySearchTree;

namespace HomeworkDay12.Tests
{
    class GenericBSTTests
    {

        [Test]
        public void InsertTestInt()
        {
            int[] array=new int[] { 7, 4, 8, 9, 5 };
            int[] expected= new int[] { 4, 5, 7, 8, 9,10 };
            GenericBST<int> tree = new GenericBST<int>(array);
            tree.Add(10);
            Assert.AreEqual(tree.Traversing(WalkOrder.In).ToArray(), expected);
        }

        [Test]
        public void InsertTestString()
        {
            string[] array = new string[] { "7", "4", "8", "9", "5" };
            string[] expected = new string[] { "10","4", "5", "7", "8", "9" };
            GenericBST<string> tree = new GenericBST<string>(array);
            tree.Add("10");
            Assert.AreEqual(tree.Traversing(WalkOrder.In).ToArray(), expected);
        }

        [Test]
        public void InsertTestBook()
        {
            Book[] array = { new Book("A", "T"), new Book("B", "TB"), new Book("C", "TC"), new Book("D", "TD"), new Book("E", "TE") };
            Book[] expected = { new Book("A", "T"), new Book("B", "TB"), new Book("C", "TC"), new Book("D", "TD"), new Book("E", "TE"), new Book("G", "TG") };
            GenericBST<Book> tree = new GenericBST<Book>(array);
            tree.Add(new Book("G", "TG"));
            Assert.AreEqual(tree.Traversing(WalkOrder.In).ToArray(), expected);
        }

        [Test]
        public void InOrderTestString()
        {
            string[] array = new string[] { "7", "4", "8", "9", "5" };
            string[] expected = new string[] { "4", "5", "7", "8", "9" };
            GenericBST<string> tree = new GenericBST<string>(array);
            Assert.AreEqual(tree.Traversing(WalkOrder.In).ToArray(), expected);
        }

        [Test]
        public void PostOrderTestString()
        {
            string[] array = new string[] { "7", "4", "8", "9", "5" };
            string[] expected = new string[] { "5", "4", "9", "8", "7" };
            GenericBST<string> tree = new GenericBST<string>(array);
            Assert.AreEqual(tree.Traversing(WalkOrder.Post).ToArray(), expected);
        }

        [Test]
        public void PreOrderTestString()
        {
            string[] array = new string[] { "7", "4", "8", "9", "5" };
            string[] expected = new string[] { "7", "4", "5", "8", "9" };
            GenericBST<string> tree = new GenericBST<string>(array);
            Assert.AreEqual(tree.Traversing(WalkOrder.Pre).ToArray(), expected);
        }

        [Test]
        public void InOrderTestInt()
        {
            int[] array = new int[] { 7, 4, 8, 9, 5 };
            int[] expected = new int[] { 4, 5, 7, 8, 9 };
            GenericBST<int> tree = new GenericBST<int>(array);
            Assert.AreEqual(tree.Traversing(WalkOrder.In).ToArray(), expected);
        }

        [Test]
        public void PostOrderTestInt()
        {
            int[] array = new int[] { 7, 4, 8, 9, 5 };
            int[] expected = new int[] { 5, 4, 9, 8, 7 };
            GenericBST<int> tree = new GenericBST<int>(array);
            Assert.AreEqual(tree.Traversing(WalkOrder.Post).ToArray(), expected);
        }

        [Test]
        public void PreOrderTestInt()
        {
            int[] array = new int[] { 7, 4, 8, 9, 5 };
            int[] expected = new int[] { 7, 4, 5, 8, 9 };
            GenericBST<int> tree = new GenericBST<int>(array);
            Assert.AreEqual(tree.Traversing(WalkOrder.Pre).ToArray(), expected);
        }

    }
}
