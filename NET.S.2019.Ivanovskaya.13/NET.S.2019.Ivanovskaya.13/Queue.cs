using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue
{
    public class Queue<T> : IEnumerable<T>
    {
        private T[] _array;
        private const int defaultCapacity = 10;
        private int capacity;
        private int head;
        private int tail;

        public Queue()
        {
            capacity = defaultCapacity;
            this._array = new T[defaultCapacity];
            this.Count = 0;
            this.head = -1;
            this.tail = 0;
        }

        public bool isEmpty() => Count == 0;

        public void Enqueue(T newElement)
        {
            if (newElement == null)
            {
                throw new ArgumentNullException(nameof(newElement) + "Can't be null");
            }

            if (this.Count == this.capacity)
            {
                T[] newQueue = new T[2 * capacity];
                Array.Copy(_array, 0, newQueue, 0, _array.Length);
                _array = newQueue;
                capacity *= 2;
            }
            Count++;
            _array[tail++ % capacity] = newElement;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            Count--;
            return _array[++head % capacity];
        }

        public IEnumerator<T> GetEnumerator() => new QueueIterator<T>(_array);

        IEnumerator IEnumerable.GetEnumerator() => new QueueIterator<T>(_array);

        public int Count { get; private set; }
    }
}
