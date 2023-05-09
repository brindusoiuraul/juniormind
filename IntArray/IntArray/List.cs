using System;
using System.Collections;
using System.Collections.Generic;

namespace IntArray
{
    public class List<T> : IEnumerable<T>
    {
        private T[] list;

        public List()
        {
            list = new T[4];
        }

        public int Count { get; set; }

        public virtual T this[int index]
        {
            get => this[index];
            set => this[index] = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int index = 0; index < Count; index++)
            {
                yield return this[index];
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
                if (list[index].Equals(element))
                {
                    return index;
                }
            }

            return -1;
        }

        public void Insert(int index, T element)
        {
            Count++;
            EnlargeArray();
            ShiftRight(index);
            list[index] = element;
        }

        public void Clear()
        {
            Count = 0;
            Array.Resize(ref list, 4);
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
            Array.Resize(ref list, list.Length - 1);
        }

        private void EnlargeArray()
        {
            if (Count < list.Length)
            {
                return;
            }

            Array.Resize(ref list, list.Length * 2);
        }

        private void ShiftRight(int index)
        {
            for (int objectArrayIndex = list.Length - 1; objectArrayIndex > index; objectArrayIndex--)
            {
                list[objectArrayIndex] = list[objectArrayIndex - 1];
            }
        }

        private void ShiftLeft(int startIndex)
        {
            for (int objectArrayIndex = startIndex; objectArrayIndex < list.Length - 1; objectArrayIndex++)
            {
                list[objectArrayIndex] = list[objectArrayIndex + 1];
            }
        }
    }
}