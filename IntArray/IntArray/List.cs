using System;
using System.Collections;
using System.Collections.Generic;

namespace IntArray
{
    public class List<T> : IList<T>
    {
        private T[] objectArray;

        public List()
        {
            objectArray = new T[4];
        }

        public int Count { get; protected set; }

        public bool IsReadOnly { get; set; }

        public virtual T this[int index]
        {
            get
            {
                CheckForIndexOutsideBounds(index);

                return objectArray[index];
            }

            set
            {
                ThrowCommonExceptions(index);

                objectArray[index] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return objectArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public virtual void Add(T item)
        {
            CheckForNotSupportedException();
            EnlargeArray();
            objectArray[Count++] = item;
        }

        public bool Contains(T item) => IndexOf(item) != -1;

        public int IndexOf(T item)
        {
            for (int index = 0; index < Count; index++)
            {
                if (objectArray[index].Equals(item))
                {
                    return index;
                }
            }

            return -1;
        }

        public virtual void Insert(int index, T item)
        {
            ThrowCommonExceptions(index);

            Count++;
            EnlargeArray();
            ShiftRight(index);
            objectArray[index] = item;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(Convert.ToString(null), "Array is null");
            }

            CheckForIndexOutsideBounds(arrayIndex);

            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("Not enough space.");
            }

            int copyArrayIndex = 0;

            for (int currentObjectArrayIndex = arrayIndex; currentObjectArrayIndex < Count; currentObjectArrayIndex++)
            {
                array[copyArrayIndex] = objectArray[currentObjectArrayIndex];
                copyArrayIndex++;
            }
        }

        public void Clear()
        {
            CheckForNotSupportedException();
            Count = 0;
            Array.Resize(ref objectArray, 4);
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            ThrowCommonExceptions(index);

            ShiftLeft(index);
            Count--;
            Array.Resize(ref objectArray, objectArray.Length - 1);
        }

        protected void EnlargeArray()
        {
            if (Count < objectArray.Length)
            {
                return;
            }

            Array.Resize(ref objectArray, objectArray.Length * 2);
        }

        private void ShiftRight(int index)
        {
            for (int objectArrayIndex = objectArray.Length - 1; objectArrayIndex > index; objectArrayIndex--)
            {
                objectArray[objectArrayIndex] = objectArray[objectArrayIndex - 1];
            }
        }

        private void ShiftLeft(int startIndex)
        {
            for (int objectArrayIndex = startIndex; objectArrayIndex < objectArray.Length - 1; objectArrayIndex++)
            {
                objectArray[objectArrayIndex] = objectArray[objectArrayIndex + 1];
            }
        }

        private void CheckForIndexOutsideBounds(int index)
        {
            if (index >= 0 && index < Count)
            {
                return;
            }

            throw new ArgumentOutOfRangeException(nameof(index), "Index is outside the range");
        }

        private void CheckForNotSupportedException()
        {
            if (!IsReadOnly)
            {
                return;
            }

            throw new NotSupportedException("The list is Read-Only.");
        }

        private void ThrowCommonExceptions(int index)
        {
            CheckForNotSupportedException();
            CheckForIndexOutsideBounds(index);
        }
    }
}