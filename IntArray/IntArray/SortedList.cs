using System;
using System.Collections;
using System.Collections.Generic;

namespace IntArray
{
    public class SortedList<T> : List<T>
        where T : IComparable<T>
    {
        public override T this[int index]
        {
            set
            {
                if (!CanModify(index - 1, index + 1, value))
                {
                    return;
                }

                base[index] = value;
            }
        }

        public override void Add(T element)
        {
            base.Insert(Count, element);
            Sort();
        }

        public override void Insert(int index, T element)
        {
            if (!CanModify(index - 1, index, element))
            {
                return;
            }

            base.Insert(index, element);
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

            if (left < size && base[left].CompareTo(base[largest]) == 1)
            {
                largest = left;
            }

            if (right < size && base[right].CompareTo(base[largest]) == 1)
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

        private bool CanModify(int firstIndex, int secondIndex, T element) =>
            ElementOrDefault(firstIndex, element).CompareTo(element) <= 0 && element.CompareTo(ElementOrDefault(secondIndex, element)) <= 0;

        private T ElementOrDefault(int index, T value) =>
            index < 0 || index >= Count ? value : base[index];
    }
}