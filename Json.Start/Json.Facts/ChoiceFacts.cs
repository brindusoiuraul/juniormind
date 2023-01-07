using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class ChoiceFacts
    {
        Choice digit = new Choice(
            new Character('0'),
            new Range('1', '9')
        );

        [Fact]
        public void CheckStringWhenCharacterMatchIsCorrectShouldReturnTrue()
        {
            Assert.True(digit.Match("012"));
        }

        [Fact]
        public void CheckStringWhenRangeMatchIsCorrectShouldReturnTrue()
        {
            Assert.True(digit.Match("12"));
        }

        [Fact]
        public void CheckStringWhenRangeMatchIsCorrectButIsLastNumberFromTheRangeShouldReturnTrue()
        {
            Assert.True(digit.Match("92"));
        }

        [Fact]
        public void CheckStringWithInexistentPatternShouldReturnFalse()
        {
            Assert.False(digit.Match("a9"));
        }

        [Fact]
        public void CheckForEmptyStringShouldReturnFalse()
        {
            Assert.False(digit.Match(""));
        }

        [Fact]
        public void CheckForNullShouldReturnFalse()
        {
            Assert.False(digit.Match(null));
        }

        [Fact]
        public void CheckForCorrectCharPatternShouldReturnTrue()
        {
            Choice hex = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')
                )
            );

            Assert.True(hex.Match("012"));
        }

        [Fact]
        public void CheckForCorrectRangePatternUpperCaseLetters()
        {
            Choice hex = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')
                )
            );

            Assert.True(hex.Match("A9"));
        }
    }
}
