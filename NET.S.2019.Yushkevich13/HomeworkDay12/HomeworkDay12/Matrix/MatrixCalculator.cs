using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDay12.Matrix
{
    public static class  MatrixCalculator<T>
    {
        public static SquareMatrix<T> AddMatrix(SquareMatrix<T> firstMatrix,SquareMatrix<T> secondMatrix,Func<T,T,T> summFunc=null)
        {
            if (summFunc is null)
            {
                var paramA = Expression.Parameter(typeof(T), "first");
                var paramB = Expression.Parameter(typeof(T), "second");
                BinaryExpression body = Expression.Add(paramA, paramB);
                summFunc = Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();
            }
            if(firstMatrix.Size!=secondMatrix.Size)
            {
                throw new Exception("Cant summ matrix");
            }

            T[,] temp = new T[firstMatrix.Size, firstMatrix.Size];
            for(int i=0;i<firstMatrix.Size;i++)
            {
                for(int j=0;j<firstMatrix.Size;j++)
                {
                    temp[i, j] = summFunc(firstMatrix[i, j], secondMatrix[i, j]);
                }
            }
            return new SquareMatrix<T>(temp);
        }
    }
}
