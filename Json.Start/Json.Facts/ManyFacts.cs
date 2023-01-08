using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class ManyFacts
    {
        Many a = new Many(new Character('a'));
        Many digits = new Many(new Range('0', '9'));

        [Fact]
        public void CheckWhenPatternIsPresentJustOneTimeAtTheBeginningShoulRemainBC()
        {
            Assert.True(a.Match("abc").Success());
            Assert.Equal("bc", a.Match("abc").RemainingText());
        }

        [Fact]
        public void CheckWhenPatternIsPresentMultipleTimesAtTheBegginingShouldRemainBC()
        {
            Assert.True(a.Match("aaaabc").Success());
            Assert.Equal("bc", a.Match("aaaabc").RemainingText());
        }

        [Fact]
        public void CheckWhenPatternIsNotPresentAtTheBegginingShouldRemainIntact()
        {
            Assert.True(a.Match("bc").Success());
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }

        [Fact(Skip = "Test Locked")]
        public void ChecForEmptyStringShouldRemainEmptyString()
        {
            Assert.True(a.Match("").Success());
            Assert.Equal("", a.Match("").RemainingText());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckForNullShouldRemainNull()
        {
            Assert.True(a.Match(null).Success());
            Assert.Null(a.Match(null).RemainingText());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckForNumberDigitsShouldReturnAB123()
        {
            Assert.True(digits.Match("12345ab123").Success());
            Assert.Equal("ab123", digits.Match("12345ab123").RemainingText());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckForInexistentNumberDigitsPatternShouldRemainAB()
        {
            Assert.True(digits.Match("ab").Success());
            Assert.Equal("ab", digits.Match("ab").RemainingText());
        }
    }
}
