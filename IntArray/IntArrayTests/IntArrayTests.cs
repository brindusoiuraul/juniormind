using Xunit;

namespace IntArray
{
    public class IntArrayTests
    {
        [Fact]
        public void AddElementTest()
        {
            IntArray intArray = new IntArray();
            Assert.Equal(0, intArray.Count());

            intArray.Add(1);
            Assert.Equal(1, intArray.Count());
        }

        [Fact]
        public void CountTest()
        {
            IntArray intArray = new IntArray();
            intArray.Add(1);
            intArray.Add(2);
            intArray.Add(3);

            Assert.Equal(3, intArray.Count());
        }

        [Fact]
        public void ElementTest()
        {
            IntArray intArray = new IntArray();
            intArray.Add(1);
            intArray.Add(2);
            intArray.Add(3);
            intArray.Add(4);
            intArray.Add(5);

            Assert.Equal(4, intArray.Element(3));
        }
    }
}