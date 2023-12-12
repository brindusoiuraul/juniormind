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

        public int Count { get; private set; }

        public bool IsReadOnly { get; }

        public virtual T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException($"{index} is not a valid index in the collection.");
                }

                return objectArray[index];
            }

            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException($"{index} is not a valid index in the collection.");
                }

                if (IsReadOnly)
                {
                    throw new NotSupportedException("The collection is Read-Only");
                }

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

        public virtual void Add(T item) => Insert(Count, item);

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
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException($"{index} is not a valid index in the collection");
            }

            if (IsReadOnly)
            {
                throw new NotSupportedException("The collection is Read-Only");
            }

            Count++;
            EnlargeArray();
            ShiftRight(index);
            objectArray[index] = item;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{array} Given array cannot be null.");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException($"{arrayIndex}; Index must be greater than 0.");
            }

            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("Insufficient space");
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
            if (IsReadOnly)
            {
                throw new NotSupportedException("The collection is Read-Only");
            }

            Count = 0;
            Array.Resize(ref objectArray, 4);
        }

        public bool Remove(T item)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("The collection is Read-Only");
            }

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
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException($"{index} is not a valid index in the collection");
            }

            if (IsReadOnly)
            {
                throw new NotSupportedException("The collection is Read-Only");
            }

            ShiftLeft(index);
            Count--;
            Array.Resize(ref objectArray, objectArray.Length - 1);
        }

        private void EnlargeArray()
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
    }
}