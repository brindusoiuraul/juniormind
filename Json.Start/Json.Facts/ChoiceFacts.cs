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

            Assert.True(digit.Match("012").Success());
        }

        [Fact]
        public void CheckPatternMatchRangeClassShouldReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));

            Assert.True(digit.Match("12").Success());
        }


        [Fact]
        public void CheckPatternMatchRangeClassShouldReturnTrueT2()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));

            Assert.True(digit.Match("92").Success());
        }

        [Fact]
        public void CheckPatternMatchCharacterOrRangeClassShouldReturnFalse()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));

            Assert.False(digit.Match("a9").Success());
        }

        [Fact]
        public void CheckPatternMatchCharacterOrRangeClassForEmptyStringShouldReturnFalse()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));

            Assert.False(digit.Match("").Success());
        }

        [Fact]
        public void CheckPatternMatchCharacterOrRangeClassForNullShouldReturnFalse()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));

            Assert.False(digit.Match(null).Success());
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

            Assert.True(hex.Match("012").Success());
            Assert.True(hex.Match("12").Success());
            Assert.True(hex.Match("92").Success());
            Assert.True(hex.Match("a9").Success());
            Assert.True(hex.Match("f8").Success());
            Assert.True(hex.Match("A9").Success());
            Assert.True(hex.Match("F8").Success());
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

            Assert.False(hex.Match("g8").Success());
            Assert.False(hex.Match("G8").Success());
            Assert.False(hex.Match("").Success());
            Assert.False(hex.Match(null).Success());
        }
    }
}
