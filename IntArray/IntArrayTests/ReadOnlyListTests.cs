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

        [Fact]
        public void SetIndexPropertyShouldThrowNotSupportedException()
        {
            string[] colors = new string[] { "red", "green", "blue" };

            ReadOnlyList<string> readOnlyColors = new ReadOnlyList<string>(colors);

            var exception = Assert.Throws<NotSupportedException>(() => readOnlyColors[1] = "violet");
            Assert.Equal("Cannot alter the list (The list is Read-Only)!!!", exception.Message);
        }
    }
}
