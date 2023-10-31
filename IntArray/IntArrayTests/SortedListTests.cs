using System;
using Xunit;

namespace IntArray
{
    public class SortedListTests
    {
        [Fact]
        public void TestGet()
        {
            var list = new SortedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            Assert.Equal(2, list[1]);
        }
    }
}
