using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeworkDay12.Matrix;

namespace HomeworkDay12.Tests
{
    class MatrixTests
    {
        [Test]
        public void SummTestInt()
        {
            int[,] aData =
            {
            { 1, 2, 3},
            { 1, 2, 3},
            { 1, 2, 3}
            };
            int[,] expected =
            {
            { 2, 4, 6},
            { 2, 4, 6},
            { 2, 4, 6}
            };
            SquareMatrix<int> a = new SquareMatrix<int>(aData);
            SquareMatrix<int> b = new SquareMatrix<int>(aData);
            var result = MatrixCalculator<int>.AddMatrix(a, b);
            Assert.AreEqual(result, new SquareMatrix<int>(expected));
        }

        [Test]
        public void SummTestString()
        {
            string[,] aData =
            {
            { "1", "2", "3"},
            { "1", "2", "3"},
            { "1", "2", "3"},
            };
            string[,] expected =
            {
            { "11", "22", "33"},
            { "11", "22", "33"},
            { "11", "22", "33"},
            };
            string summString(string c,string d)
            {
                return c + d;
            }
            SquareMatrix<string> a = new SquareMatrix<string>(aData);
            SquareMatrix<string> b = new SquareMatrix<string>(aData);
            var result = MatrixCalculator<string>.AddMatrix(a, b,summString);
            Assert.AreEqual(result, new SquareMatrix<string>(expected));
        }
    }
}
