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

        [Fact]
        public void CheckPatternMatchForNumberRangeAndLetterRangeShouldReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                );

            var hex = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')
                    )
                );

            Assert.True(hex.Match("012"));
            Assert.True(hex.Match("12"));
            Assert.True(hex.Match("92"));
            Assert.True(hex.Match("a9"));
            Assert.True(hex.Match("f8"));
            Assert.True(hex.Match("A9"));
            Assert.True(hex.Match("F8"));
        }

        [Fact]
        public void CheckPatternMatchForNumberRangeAndLetterRangeShouldReturnFalse()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                );

            var hex = new Choice(digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')
                    )
                );

            Assert.False(hex.Match("g8"));
            Assert.False(hex.Match("G8"));
            Assert.False(hex.Match(""));
            Assert.False(hex.Match(null));
        }
    }
}
