using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntArray
{
    public class ReadOnlyList<T> : IList<T>
    {
        private readonly IList<T> readOnlyList;

        public ReadOnlyList(IList<T> readOnlyList)
        {
            this.readOnlyList = readOnlyList;
        }

        public int Count { get => readOnlyList.Count; }

        public bool IsReadOnly => true;

        public T this[int index]
        {
            get => readOnlyList[index];
            set => throw new NotSupportedException("Cannot alter the list (The list is Read-Only)!!!");
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
