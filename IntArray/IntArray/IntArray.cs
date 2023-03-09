using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntArray
{
    public class IntArray
    {
        readonly int[] intArray;

        public IntArray()
        {
            this.intArray = new int[1];
        }

        public void Add(int element)
        {
            intArray[^1] = element;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Element(int index)
        {
            throw new NotImplementedException();
        }

        public void SetElement(int index, int element)
        {
            throw new NotImplementedException();
        }

        public bool Contains(int element)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(int element)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, int element)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
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
