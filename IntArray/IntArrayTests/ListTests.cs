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
    }
}
