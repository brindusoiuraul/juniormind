using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class OneOrMoreFacts
    {
        OneOrMore a = new OneOrMore(new Range('0', '9'));

        [Fact]
        public void CheckWhenPatternAppearsMultipleTimesShouldReturnTrueAndRemainsEmpty()
        {
            Assert.True(a.Match("123").Success());
            Assert.Equal("", a.Match("123").RemainingText());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckWhenPatternAppearsOneTimeShouldReturnTrueAndRemainsA()
        {
            Assert.True(a.Match("1a").Success());
            Assert.Equal("a", a.Match("1a").RemainingText());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckWhenPatternDoesNotAppearShouldReturnFalseAndReturnBC()
        {
            Assert.False(a.Match("bc").Success());
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckForEmptyStringShouldReturnFalseAndRemainsEmptyString()
        {
            Assert.False(a.Match("").Success());
            Assert.Equal("", a.Match("").RemainingText());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckForNullShouldReturnFalseAndRemainsNull()
        {
            Assert.False(a.Match(null).Success());
            Assert.Null(a.Match(null).RemainingText());
        }
    }
}
