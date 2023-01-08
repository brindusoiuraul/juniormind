using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class TextFacts
    {
        Text True = new Text("true");
        Text empty = new Text("");

        [Fact]
        public void CheckWhenTextIsTheSameAsPrefixShouldReturnTrue()
        {
            Assert.True(True.Match("true").Success());
            Assert.Equal("", True.Match("true").RemainingText());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckWhenTextIsPrefixedByGivenPrefixShouldReturnTrue()
        {
            Assert.True(True.Match("trueX").Success());
            Assert.Equal("X", True.Match("trueX").RemainingText());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckWhenTextIsNotPrefixedByGivenPrefixShouldReturnFalse()
        {
            Assert.False(True.Match("false").Success());
            Assert.Equal("false", True.Match("false").RemainingText());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckForEmptyStringShouldReturnFalse()
        {
            Assert.False(True.Match("").Success());
            Assert.Equal("", True.Match("").RemainingText());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckForNullShouldReturnFalse()
        {
            Assert.False(True.Match(null).Success());
            Assert.Null(True.Match(null).RemainingText());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckWhenPrefixIsEmptyStringAndTextIsNotShouldReturnTrue()
        {
            Assert.True(empty.Match("true").Success());
            Assert.Equal("true", empty.Match("true").RemainingText());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckWhenPrefixIsEmptyStringAndTextIsNullShouldReturnFalse()
        {
            Assert.False(empty.Match(null).Success());
            Assert.Null(empty.Match(null).RemainingText());
        }
    }
}
