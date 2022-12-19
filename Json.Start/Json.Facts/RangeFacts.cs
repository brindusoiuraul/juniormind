using Xunit;

namespace Json.Facts
{
    public class RangeFacts
    {
        [Fact]
        public void CheckMatchFunctionShouldReturnTrue()
        {
            var digit = new Range('a', 'f');

            Assert.True(digit.Match("abc"));
            Assert.True(digit.Match("fab"));
            Assert.True(digit.Match("bcd"));
        }
    }
}
