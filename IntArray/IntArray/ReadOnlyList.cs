using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IntArray
{
    public class ReadOnlyList<T> : IList<T>
    {
        private readonly IList<T> readOnlyList;
        private readonly string exceptionMessage = "Cannot alter the list (The list is Read-Only)!!!";

        public ReadOnlyList(IList<T> readOnlyList)
        {
            this.readOnlyList = readOnlyList;
        }

        public int Count { get => readOnlyList.Count; }

        public bool IsReadOnly => true;

        public T this[int index]
        {
            get => readOnlyList[index];
            set => throw new NotSupportedException(exceptionMessage);
        }

        public void Add(T item) => throw new NotSupportedException(exceptionMessage);

        public void Clear() => throw new NotSupportedException(exceptionMessage);

        public bool Contains(T item) => readOnlyList.IndexOf(item) != -1;

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(Convert.ToString(null), "Array is null");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Index is outside the range");
            }

            int currentCopyArrayIndex = 0;

            for (int index = arrayIndex; index < Count; index++)
            {
                array[currentCopyArrayIndex] = readOnlyList[index];
                currentCopyArrayIndex++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int index = 0; index < Count; index++)
            {
                yield return readOnlyList[index];
            }
        }

        public int IndexOf(T item)
        {
            for (int index = 0; index < Count; index++)
            {
                if (readOnlyList[index].Equals(item))
                {
                    return index;
                }
            }

            return -1;
        }

        public void Insert(int index, T item) => throw new NotSupportedException(exceptionMessage);

        public bool Remove(T item) => throw new NotSupportedException(exceptionMessage);

        public void RemoveAt(int index) => throw new NotSupportedException(exceptionMessage);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
