using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class OptionalFacts
    {
        Optional a = new Optional(new Character('a'));
        Optional sign = new Optional(new Character('-'));

        [Fact]
        public void CheckForOneExistentPatternShouldReturnTrueAndRemainingTextShouldBeBC()
        {
            Assert.True(a.Match("abc").Success());
            Assert.Equal("bc", a.Match("abc").RemainingText());
        }

        [Fact]
        public void CheckForExistingCharPatternShouldReturnTrueAndRemainingTextShouldBeABC()
        {
            Assert.True(a.Match("aabc").Success());
            Assert.Equal("abc", a.Match("aabc").RemainingText());
        }

        [Fact]
        public void CheckForNonExistingPatternShouldReturnTrueAndRemainingTextShouldBeBC()
        {
            Assert.True(a.Match("bc").Success());
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }

        [Fact]
        public void CheckForEmptyStringShouldReturnTrueAndRemainingTextShouldBeAnEmptyString()
        {
            Assert.True(a.Match("").Success());
            Assert.Equal("", a.Match("").RemainingText());
        }

        [Fact]
        public void CheckForNullShouldReturnTrueAndRemainingStringShouldBeNull()
        {
            Assert.True(a.Match(null).Success());
            Assert.Null(a.Match(null).RemainingText());
        }

        [Fact]
        public void CheckForNonExistingSignShouldReturnTrueAndRemainingTextShouldBe123()
        {
            Assert.True(sign.Match("123").Success());
            Assert.Equal("123", sign.Match("123").RemainingText());
        }

        [Fact]
        public void CheckForExistingSignShouldReturnTrueAndRemainingTextShouldBe123()
        {
            Assert.True(sign.Match("-123").Success());
            Assert.Equal("123", sign.Match("-123").RemainingText());
        }
    }
}
