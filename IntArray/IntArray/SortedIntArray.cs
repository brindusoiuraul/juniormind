using System;

namespace IntArray
{
    public class SortedIntArray : IntArray
    {
        public override int this[int index]
        {
            get => base[index];
            set
            {
                if (!CanReplace(index, value))
                {
                    return;
                }

                base[index] = value;
            }
        }

        public override void Add(int element)
        {
            base.Insert(Count, element);
            Sort();
        }

        public override void Insert(int index, int element)
        {
            if (!CanInsert(index, element))
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

            if (left < size && base[left] > base[largest])
            {
                largest = left;
            }

            if (right < size && base[right] > base[largest])
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

        private void Swap(int firstIndex, int secondIndex)
        {
            int temp = base[firstIndex];
            base[firstIndex] = base[secondIndex];
            base[secondIndex] = temp;
        }

        private bool CanInsert(int index, int element)
        {
            return base[index] >= element;
        }

        private bool CanReplace(int index, int element)
        {
            if (Count < 2)
            {
                return true;
            }

            if ((index == 0 && element < base[index + 1]) || (index == Count && element > base[index - 1]))
            {
                return true;
            }

            return element > base[index - 1] && element < base[index + 1];
        }
    }
}