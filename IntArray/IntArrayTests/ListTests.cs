using System;
using Xunit;

namespace IntArray
{
    public class ListTests
    {
        [Fact]
        public void CheckForLengthWhenListHasNoElements()
        {
            List<int> list = new List<int>();
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void CheckForElements()
        {
            List<int> list = new List<int>() { 1, 2, 3 };

            Assert.Equal(1, list[0]);
            Assert.Equal(2, list[1]);
            Assert.Equal(3, list[2]);
        }

        [Fact]
        public void TestForCopyTo()
        {
            List<string> firstName = new List<string> { "Raul", "Alexandru" };
            string[] testArray = new string[2];

            firstName.CopyTo(testArray, 0);

            Assert.Equal("Raul", testArray[0]);
            Assert.Equal("Alexandru", testArray[1]);
        }

        [Fact]
        public void CheckForExceptionWhenIndexIsBiggerThanCount()
        {
            List<int> testList = new List<int>() { 1, 2, 3 };

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => testList[3]);
            Assert.Equal("Index is outside the range (Parameter 'index')", exception.Message);
        }

        [Fact]
        public void CheckForExceptionWhenIndexIsSmallerThanZero()
        {
            List<int> testList = new List<int>() { 4, 5, 6 };

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => testList[-1]);
            Assert.Equal("Index is outside the range (Parameter 'index')", exception.Message);
        }

        [Fact]
        public void CheckForSetWhenIndexIsBiggerThanCount()
        {
            List<int> testList = new List<int> { 7, 8, 9 };

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => testList[4] = 0);
            Assert.Equal("Index is outside the range (Parameter 'index')", exception.Message);
        }

        [Fact]
        public void CheckForSetWhenWindexIsSmallerThanZero()
        {
            List<int> testList = new List<int> { 7, 8, 9 };

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => testList[-2] = 0);
            Assert.Equal("Index is outside the range (Parameter 'index')", exception.Message);
        }

        [Fact]
        public void CheckForIndexGreaterThanCount()
        {
            List<string> testList = new List<string>() { "Raul", "Alexandru" };

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => testList.Insert(4, "Andrei"));
            Assert.Equal("Index is outside the range (Parameter 'index')", exception.Message);
        }

        [Fact]
        public void CheckForIndexLessThanZero()
        {
            List<string> testList = new List<string>() { "Raul", "Alexandru" };

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => testList.Insert(-1, "Andrei"));
            Assert.Equal("Index is outside the range (Parameter 'index')", exception.Message);
        }

        [Fact]
        public void CheckForRemoveAtWhenIndexIsGreaterThanCount()
        {
            List<string> nameList = new List<string>() { "Raul", "Andrei" };

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>  nameList.RemoveAt(5));
            Assert.Equal("Index is outside the range (Parameter 'index')", exception.Message);
        }

        [Fact]
        public void CheckForRemoveAtWhenIndexIsLessThanZero()
        {
            List<string> nameList = new List<string>() { "Raul", "Andrei" };

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => nameList.RemoveAt(-1));
            Assert.Equal("Index is outside the range (Parameter 'index')", exception.Message);
        }

        [Fact]
        public void CheckForCopyToWhenArrayIsNull()
        {
            List<string> nameList = new List<string> { "Raul", "Alexandru" };

            string[] newArray = null;

            var exception = Assert.Throws<ArgumentNullException>(() => nameList.CopyTo(newArray, 0));
            Assert.Equal("Array is null", exception.Message);
        }

        [Fact]
        public void CheckForCopyToWhenArrayIndexIsLessThanZero()
        {
            List<string> nameList = new List<string> { "Raul", "Alexandru" };

            string[] newArray = new string[2];

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => nameList.CopyTo(newArray, -1));
            Assert.Equal("Index is outside the range (Parameter 'index')", exception.Message);
        }

        [Fact]
        public void CheckForCopyToWhenArrayIndexIsBiggerThanCount()
        {
            List<string> nameList = new List<string> { "Raul", "Alexandru" };

            string[] newArray = new string[2];

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => nameList.CopyTo(newArray, 5));
            Assert.Equal("Index is outside the range (Parameter 'index')", exception.Message);
        }

        [Fact]
        public void CheckForWhenTheCollectionItemsAreMoreThanTheSpaceOfTheArray()
        {
            List<string> nameList = new List<string>() { "Brindusoiu", "Raul", "Alexandru" };
            string[] newArray = new string[2];

            var exception = Assert.Throws<ArgumentException>(() => nameList.CopyTo(newArray, 0));
            Assert.Equal("Not enough space.", exception.Message);
        }

        [Fact]
        public void CheckForWhenTheListIsReadOnlyButItTriesToModify()
        {
            List<int> numberList = new List<int>() { 1, 2, 3 };

            var exception = Assert.Throws<NotSupportedException>(() => numberList[1] = 1);
            Assert.Equal("The list is Read-Only.", exception.Message);
        }
    }
}
