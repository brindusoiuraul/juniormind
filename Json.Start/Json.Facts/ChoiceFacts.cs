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

        [Fact]
        public void CheckPatternMatchRangeClassShouldReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));

            Assert.True(digit.Match("12"));
        }


        [Fact]
        public void CheckPatternMatchRangeClassShouldReturnTrueT2()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));

            Assert.True(digit.Match("92"));
        }

        [Fact]
        public void CheckPatternMatchCharacterOrRangeClassShouldReturnFalse()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));

            Assert.False(digit.Match("a9"));
        }

        [Fact]
        public void CheckPatternMatchCharacterOrRangeClassForEmptyStringShouldReturnFalse()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));

            Assert.False(digit.Match(""));
        }

        [Fact]
        public void CheckPatternMatchCharacterOrRangeClassForNullShouldReturnFalse()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));

            Assert.False(digit.Match(null));
        }
    }
}
