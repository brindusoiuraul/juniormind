using Xunit;

namespace Json.Facts
{
    public class RangeFacts
    {
        [Fact]
        public void CheckMatchFunctionShouldReturnTrue()
        {
            var digit = new Range('a', 'f');

            Assert.True(digit.Match("abc").Success());
            Assert.True(digit.Match("fab").Success());
            Assert.True(digit.Match("bcd").Success());
        }

        [Fact]
        public void CheckMatchFunctionShouldReturnFalse()
        {
            var digit = new Range('a', 'f');

            Assert.False(digit.Match("1ab").Success());
        }
    }
}
