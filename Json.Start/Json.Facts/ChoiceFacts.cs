using Xunit;

namespace Json.Facts
{
    public class ChoiceFacts
    {
        [Fact]
        public void CheckPatternMatchCharacterClassShouldReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));

            Assert.True(digit.Match("012"));
        }
    }
}
