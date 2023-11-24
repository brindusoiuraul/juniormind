using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntArray
{
    public class SortedListTests
    {
        [Fact]
        public void CheckForRandomOrder()
        {
            var list = new SortedList<int> { 5, 1, 4, 3 };

            Assert.Equal(1, list[0]);
            Assert.Equal(3, list[1]);
            Assert.Equal(4, list[2]);
            Assert.Equal(5, list[3]);
        }
    }
}
