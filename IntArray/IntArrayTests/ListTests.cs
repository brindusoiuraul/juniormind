using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntArrayTests
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

            Assert.Throws<ArgumentOutOfRangeException>(() => testList[3]);
        }
    }
}
