using System;
using System.Collections;

namespace IntArray
{
    public class ObjectCollection : IEnumerable
    {
        private object[] objectArray;

        public ObjectCollection()
        {
            objectArray = new object[4];
        }

        public int Count { get; set; }

        public object this[int index]
        {
            get => objectArray[index];
            set => objectArray[index] = value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public ObjectEnumerator GetEnumerator()
        {
            return new ObjectEnumerator(objectArray);
        }

        public void Add(object element) => Insert(Count, element);

        public bool Contains(object element) => IndexOf(element) != -1;

        public int IndexOf(object element)
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

        public void Insert(int index, object element)
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

        public bool Remove(object element)
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