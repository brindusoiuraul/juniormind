using System;
using System.Collections;
using System.Collections.Generic;

namespace IntArray
{
    public class SortedList<T> : List<T>
        where T : IComparable<T>
    {
        public SortedList()
        {
        }

        public override T this[int index]
        {
            get => this[index];
            set
            {
                if (ElementOrDefault(index - 1, value).CompareTo(value) > 0 || value.CompareTo(ElementOrDefault(index, value)) > 0)
                {
                    return;
                }

                base[index] = value;
            }
        }

        public override void Add(T element)
        {
            Insert(Count, element);
            Sort();
        }

        private void Sort()
        {
            int size = Count;

            for (int index = size / 2 - 1; index >= 0; index--)
            {
                Heapify(size, index);
            }

            for (int index = size - 1; index >= 0; index--)
            {
                Swap(0, index);
                Heapify(index, 0);
            }
        }

        private void Heapify(int size, int index)
        {
            int largest = index;
            int left = 2 * index + 1;
            int right = 2 * index + 2;

            if (left < size && base[left].CompareTo(base[largest]) > 0)
            {
                largest = left;
            }

            if (right < size && base[right].CompareTo(base[largest]) > 0)
            {
                largest = right;
            }

            if (largest == index)
            {
                return;
            }

            Swap(index, largest);
            Heapify(size, largest);
        }

        private void Swap(int firstIndex, int secondIndex) =>
            (base[firstIndex], base[secondIndex]) = (base[secondIndex], base[firstIndex]);

        private T ElementOrDefault(int index, T value) =>
            index < 0 || index >= Count ? value : base[index];
    }
}
