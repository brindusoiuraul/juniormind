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
        Text False = new Text("false");
        Text Empty = new Text("");

        [Fact]
        public void CheckForExistingPrefixShouldReturnTrue()
        {
            Assert.True(True.Match("true").Success());
            Assert.Equal("", True.Match("true").RemainingText());
        }

        [Fact]
        public void CheckForExistingPrefixShouldReturnTrueAndRemainShouldBeX()
        {
            Assert.True(True.Match("trueX").Success());
            Assert.Equal("X", True.Match("trueX").RemainingText());
        }

        [Fact]
        public void CheckForNonExistingPrefixShouldReturnFalseAndRemainShouldBeFalse()
        {
            Assert.False(True.Match("false").Success());
            Assert.Equal("false", True.Match("false").RemainingText());
        }

        [Fact]
        public void CheckForEmptyStringShouldReturnFalseAndRemainShouldBeAnEmptyString()
        {
            Assert.False(True.Match("").Success());
            Assert.Equal("", True.Match("").RemainingText());
        }

        [Fact]
        public void CheckForNullShouldReturnFalseAndRemainShouldBeNull()
        {
            Assert.False(True.Match(null).Success());
            Assert.Null(True.Match(null).RemainingText());
        }

        [Fact]
        public void CheckForExistingPrefixShouldReturnTrueAndRemainingShouldBeAnEmptyString()
        {
            Assert.True(False.Match("false").Success());
            Assert.Equal("", False.Match("false").RemainingText());
        }

        [Fact]
        public void CheckForExistingPrefixShouldReturnTrueAndRemainingShouldBeX()
        {
            Assert.True(False.Match("falseX").Success());
            Assert.Equal("X", False.Match("falseX").RemainingText());
        }

        [Fact]
        public void CheckAnEmptyStringShouldReturnTrue()
        {
            Assert.True(Empty.Match("true").Success());
            Assert.Equal("true", Empty.Match("true").RemainingText());
        }
        
        [Fact]
        public void CheckForEmptyStringWithNullShouldReturnFalse()
        {
            Assert.False(Empty.Match(null).Success());
            Assert.Null(Empty.Match(null).RemainingText());
        }
    }
}
