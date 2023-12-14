using System;
using Xunit;

namespace IntArray
{
    public class ReadOnlyListTests
    {
        [Fact]
        public void CheckForCount()
        {
            int[] numbers = new int[] { 1, 2, 3 };

            ReadOnlyList<int> readOnlyNumbers = new ReadOnlyList<int>(numbers);
            Assert.Equal(3, readOnlyNumbers.Count);
        }
    }
}
