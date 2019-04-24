using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDay12.Matrix
{
    public class SquareMatrix<T> : IEnumerable
    {     
        protected T[,] _matrix;
       
        public SquareMatrix()
        {
            _matrix = new T[0, 0];
        }

        public SquareMatrix(int size)
        {
            Size = size;
            _matrix = new T[size, size];
        }

        public SquareMatrix(T[,] array)
        {
            Size = array.GetLength(0);
            _matrix = new T[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    _matrix[i, j] = array[i, j];
                }
            }
        }         

        public event EventHandler<EleChangesEventArgs> ElementChanged;           

        public int Size { get; protected set; }

        public T this[int i, int j]
        {
            get
            {
                return _matrix[i, j];
            }

            set
            {
                _matrix[i, j] = value;
                OnChanges(new EleChangesEventArgs(i, j, value));
            }
        }

        public IEnumerator GetEnumerator()
        {
            return _matrix.GetEnumerator();
        }

        protected void OnChanges(EleChangesEventArgs e)
        {
            ElementChanged?.Invoke(this, e);
        }

        public class EleChangesEventArgs : EventArgs
        {
            public EleChangesEventArgs(int i, int j, T value)
            {
                this.IndexI = i;
                this.IndexJ = j;
                this.Item = value;
            }

            public int IndexI { get; }

            public int IndexJ { get; }

            public T Item { get; }
        }
    }
}
