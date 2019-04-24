using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDay12.Matrix
{
    public class DiagMatrix<T> : SquareMatrix<T>
    {
        public DiagMatrix()
        {
        }

        public DiagMatrix(int size) : base(size)
        {
        }

        public DiagMatrix(T[,] array)
        {
            this.Size = array.GetLength(0);
            this._matrix = new T[Size, Size];
            for (int i = 0; i < this.Size; i++)
            {
                this._matrix[i, i] = array[i, i];
            }
        }
    }
}
