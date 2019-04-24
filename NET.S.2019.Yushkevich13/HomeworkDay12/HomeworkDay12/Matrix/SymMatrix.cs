using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDay12.Matrix
{
    public class SymMatrix<T> : SquareMatrix<T>
    {
        public SymMatrix(int size) : base(size)
        {
        }

        public SymMatrix()
        {
        }

        public SymMatrix(T[,] array)
        {
            this.Size = array.GetLength(0);
            this._matrix = new T[Size, Size];
            for (int i = 0; i < this.Size; i++)
            {
                this._matrix[i, i] = array[i, i];
                for (int j = 0; j < this.Size; j++)
                {
                    this._matrix[i, j] = array[i, j];
                    this._matrix[j, i] = array[i, j];
                }
            }
        }
    }
}
