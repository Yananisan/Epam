using System;

namespace Arrays
{
    public abstract class Arrays<T>
    {
        protected T[,] values;
        public event EventHandler<EventArgsArray> OnChangeArray;

        public T[,] Values => values;


        public Arrays(int capasity)
        {
            if (capasity <= 0)
            {
                throw new ArgumentNullException();
            }

            values = new T[capasity, capasity];
        }

        public T this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0)
                {
                    throw new ArgumentException();
                }

                return values[i, j];
            }
        }

        public abstract void AddElement(int i, int j, T item);

        public void OnChangedArray(int i, int j) => OnChangeArray(this, new EventArgsArray(i, j));
    }
}
