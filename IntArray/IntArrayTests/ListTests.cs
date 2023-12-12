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
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            var emptyList = new int[3];

            list.CopyTo(emptyList, 2);

            Assert.Equal(3, emptyList[0]);
            Assert.Equal(4, emptyList[1]);
            Assert.Equal(5, emptyList[2]);
        }
    }
}
