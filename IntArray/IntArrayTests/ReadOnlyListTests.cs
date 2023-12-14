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

        [Fact]
        public void CheckForGetIndexProperty()
        {
            string[] names = new string[] { "Raul", "Alexandru", "Mihai" };

            ReadOnlyList<string> readOnlyNames = new ReadOnlyList<string>(names);
            Assert.Equal("Alexandru", readOnlyNames[1]);
        }
    }
}
