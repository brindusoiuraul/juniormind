using Xunit;

namespace Colectii
{
    public class ListTests
    {
        [Fact]
        public void TestForCountWhenTheArrayHasNoElements()
        {
            var list = new List<int>();
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void CheckForAddMethodAndGetAndSetWithIntDataType()
        {
            var list = new List<int>
            {
                [0] = 8,
                [1] = 15,
                [2] = 2,
                [3] = 14
            };

            Assert.Equal(8, list[0]);
            Assert.Equal(15, list[1]);
            Assert.Equal(2, list[2]);
            Assert.Equal(14, list[3]);

            list[2] = 12;
            Assert.Equal(12, list[2]);
        }

        [Fact]
        public void CheckForContainsMethod()
        {
            var list = new List<string> { "Andrei", "Mihai", "Ionel" };

            Assert.True(list.Contains("Mihai"));
            Assert.False(list.Contains("George"));
        }

        [Fact]
        public void CheckForIndexOfMethod()
        {
            var list = new List<char> { 'a', 'e', 'i', 'o', 'u' };

            Assert.Equal(0, list.IndexOf('a'));
            Assert.Equal(-1, list.IndexOf('c'));
        }

        [Fact]
        public void CheckForInsertMethod()
        {
            var list = new List<double> { 12.35, 16.72 };

            list.Insert(1, 13.55);

            Assert.Equal(12.35, list[0]);
            Assert.Equal(13.55, list[1]);
            Assert.Equal(16.72, list[2]);
        }

        [Fact]
        public void CheckForClearMethod()
        {
            var list = new List<int> { 1, 2, 3, 4 };

            Assert.Equal(4, list.Count);

            list.Clear();

            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void CheckForRemoveMethod()
        {
            var list = new List<string> { "Alin", "George", "Andreea", "Ioana" };

            list.Remove("George");

            Assert.Equal("Alin", list[0]);
            Assert.Equal("Andreea", list[1]);
            Assert.Equal("Ioana", list[2]);
        }

        [Fact]
        public void CheckForRemoveAt()
        {
            var list = new List<char> { 'w', 'x', 'y', 'z' };

            list.RemoveAt(2);

            Assert.Equal('w', list[0]);
            Assert.Equal('x', list[1]);
            Assert.Equal('z', list[2]);
        }

        [Fact]
        public void CheckIfItIsIterable()
        {
            var objectArray = new List<int> { 13, 21, 18 };

            Assert.Equal(13, objectArray[0]);
            Assert.Equal(21, objectArray[1]);
            Assert.Equal(18, objectArray[2]);
        }
    }
}
