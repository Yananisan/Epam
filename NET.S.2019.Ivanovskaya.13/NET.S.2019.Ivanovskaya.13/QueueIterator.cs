using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue
{
    internal class QueueIterator<T> : IEnumerator<T>
    {
        private T[] values;
        int pointer = -1;

        public QueueIterator(T[] array) => values = array ?? throw new ArgumentNullException(nameof(array));

        public T Current
        {
            get
            {
                if (pointer != -1)
                {
                    return values[pointer];
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current => (object)Current;

        public bool MoveNext()
        {
            if (pointer < (values.Length - 1))
            {
                pointer++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset() => pointer = -1;

        public void Dispose() { }
    }
}
