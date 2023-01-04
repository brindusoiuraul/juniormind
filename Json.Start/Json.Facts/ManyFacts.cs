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

        [Fact]
        public void CheckForABCShouldReturnTrueAndRemainingTextShouldBeBC()
        {
            Assert.True(a.Match("abc").Success());
            Assert.Equal("bc", a.Match("abc").RemainingText());
        }

        [Fact]
        public void CheckForAAAABCShouldReturnTrueAndRemainingTextShouldBeBC()
        {
            Assert.True(a.Match("aaaabc").Success());
            Assert.Equal("bc", a.Match("aaaabc").RemainingText());
        }

        [Fact]
        public void CheckForNonExistingPatterShouldReturnTrueAndRemainingTextShouldBeBC()
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
        public void CheckForNullShouldReturnTrueAndRemainingTextShouldBeNull()
        {
            Assert.True(a.Match(null).Success());
            Assert.Null(a.Match(null).RemainingText());
        }
    }
}
