using System;

namespace IntArray
{
    public class IntArray
    {
        int[] intArray;

        public IntArray()
        {
            intArray = new int[4];
        }

        public void Add(int element)
        {
            if (Count() == intArray.Length - 1)
            {
                Array.Resize(ref intArray, intArray.Length * 2);
            }

            intArray[Count()] = element;
        }

        public int Count()
        {
            int count = 0;

            while (count < intArray.Length && intArray[count] != 0)
            {
                count++;
            }

            return count;
        }

        public int Element(int index)
        {
            return intArray[index];
        }

        public void SetElement(int index, int element)
        {
            intArray[index] = element;
        }

        public bool Contains(int element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(int element)
        {
            for (int index = 0; index < intArray.Length; index++)
            {
                if (intArray[index] == element)
                {
                    return index;
                }
            }

            return -1;
        }

        public void Insert(int index, int element)
        {
            Array.Resize(ref intArray, intArray.Length + 1);
            ShiftRight(index);
            intArray[index] = element;
        }

        public void Clear()
        {
            Array.Resize(ref intArray, 0);
        }

        public bool Remove(int element)
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
            Array.Resize(ref intArray, intArray.Length - 1);
        }

        private void ShiftLeft(int startIndex)
        {
            for (int intArrayIndex = startIndex; intArrayIndex < intArray.Length - 1; intArrayIndex++)
            {
                intArray[intArrayIndex] = intArray[intArrayIndex + 1];
            }
        }

        private void ShiftRight(int index)
        {
            for (int intArrayIndex = intArray.Length - 1; intArrayIndex > index; intArrayIndex--)
            {
                intArray[intArrayIndex] = intArray[intArrayIndex - 1];
            }
        }
    }
}
