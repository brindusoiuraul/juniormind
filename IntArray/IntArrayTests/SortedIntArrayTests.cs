using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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
    }
}
