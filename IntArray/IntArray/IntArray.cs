﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntArray
{
    public class IntArray
    {
        int[] intArray;

        public IntArray()
        {
            this.intArray = new int[0];
        }

        public void Add(int element)
        {
            Array.Resize(ref intArray, intArray.Length + 1);
            intArray[^1] = element;
        }

        public int Count()
        {
            return intArray.Length;
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
            return intArray.Contains(element);
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

            for (int intArrayIndex = intArray.Length - 1; intArrayIndex > index; intArrayIndex--)
            {
                intArray[intArrayIndex] = intArray[intArrayIndex - 1];
            }

            intArray[index] = element;
        }

        public void Clear()
        {
            Array.Resize(ref intArray, 0);
        }

        public void Remove(int element)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
    }
}
