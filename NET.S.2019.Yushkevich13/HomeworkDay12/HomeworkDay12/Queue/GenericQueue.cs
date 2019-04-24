using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HomeworkDay12.Queue
{
    public class GenericQueue<T> : IEnumerable<T>
    {
        private List<T> _list;

        private Comparer<T> _comparer;

        public GenericQueue()
        {
            _list = new List<T>();
        }

        public GenericQueue(ICollection<T> collection, Comparer<T> comparer = null)
        {
            List<T> temp = collection.ToList<T>();
            _list = temp;

            if (comparer is null)
            {
                _comparer = Comparer<T>.Default;
            }
            else
            {
                _comparer = comparer;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool IsEmpty()
        {
            if (_list.Count == 0)
            {
                return true;
            }

            return false;
        }

        public void Enqueue(T item)
        {
            _list.Add(item);
        }

        public T Dequeue()
        {
            if (!IsEmpty())
            {
                T removed = _list[0];
                _list.Remove(removed);
                return removed;
            }
            else
            {
                throw new InvalidOperationException("empty queue");
            }
        }

        public T Peek()
        {
            return _list[0];
        }

        public void Clear()
        {
            _list.Clear();
        }

        private class QueueEnumerator : IEnumerator<T>
        {
            private GenericQueue<T> _q;

            private int _index;

            public QueueEnumerator(GenericQueue<T> q)
            {
                _q = q;
                _index = -1;    
            }

            public T Current => _q._list[_index];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                _index++;
                if (_index == _q._list.Count)
                {
                    return false;
                }

                return true;
            }

            public void Reset()
            {
                _index = -1;
            }
        }
    }
}
