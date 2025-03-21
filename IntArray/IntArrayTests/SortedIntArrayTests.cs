﻿using Xunit;

namespace IntArray
{
    public class SortedIntArrayTests
    {
        [Fact]
        public void CheckIfElementsAreAssigned()
        {
            var array = new SortedIntArray();
            array[0] = 1;
            Assert.Equal(1, array[0]);
        }

        [Fact]
        public void CheckIfElementsAreSortedAfterAdd()
        {
            var array = new SortedIntArray();
            array.Add(5);
            array.Add(2);
            array.Add(4);
            array.Add(4);

            Assert.Equal(2, array[0]);
            Assert.Equal(4, array[1]);
            Assert.Equal(4, array[2]);
            Assert.Equal(5, array[3]);
        }

        [Fact]
        public void CheckIfElementsAreSortedAfterChangingAnElement()
        {
            var array = new SortedIntArray();
            array.Add(5);
            array.Add(2);
            array.Add(4);
            array.Add(4);

            array[1] = 8;

            Assert.Equal(2, array[0]);
            Assert.Equal(4, array[1]);
            Assert.Equal(4, array[2]);
            Assert.Equal(5, array[3]);
        }

        [Fact]
        public void CheckIfElementsAreModifiedAfterInsertingAnElementOnInvalidPosition()
        {
            var array = new SortedIntArray();
            array.Add(5);
            array.Add(2);
            array.Add(4);
            array.Add(4);

            array.Insert(1, 12);

            Assert.Equal(2, array[0]);
            Assert.Equal(4, array[1]);
            Assert.Equal(4, array[2]);
            Assert.Equal(5, array[3]);
        }

        [Fact]
        public void CheckIfElementsAreModifiedAfterInsertingAnElementOnValidPosition()
        {
            var array = new SortedIntArray();
            array.Add(5);
            array.Add(2);
            array.Add(4);
            array.Add(4);

            array.Insert(0, 1);

            Assert.Equal(1, array[0]);
            Assert.Equal(2, array[1]);
            Assert.Equal(4, array[2]);
            Assert.Equal(4, array[3]);
            Assert.Equal(5, array[4]);
        }
    }
}
