using System;
using System.Collections;
using System.Collections.Generic;

namespace IntArray
{
    public class List<T> : IEnumerable<T>
    {
        private T[] objectArray;

        public List()
        {
            objectArray = new T[4];
        }

        public int Count { get; private set; }

        public virtual T this[int index]
        {
            get => objectArray[index];
            set => objectArray[index] = value;
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

        public virtual void Add(T element) => Insert(Count, element);

        public bool Contains(T element) => IndexOf(element) != -1;

        public int IndexOf(T element)
        {
            for (int index = 0; index < Count; index++)
            {
                if (objectArray[index].Equals(element))
                {
                    return index;
                }
            }

            return -1;
        }

        public virtual void Insert(int index, T element)
        {
            Count++;
            EnlargeArray();
            ShiftRight(index);
            objectArray[index] = element;
        }

        public void Clear()
        {
            Count = 0;
            Array.Resize(ref objectArray, 4);
        }

        public bool Remove(T element)
        {
            int index = IndexOf(element);

            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
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