using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class RangeFacts
    {
        Range digit = new Range('a', 'f');

        [Fact]
        public void CheckForStringThatStartsWithAShouldReturnTrue()
        {
            Assert.True(digit.Match("abc"));
        }

        [Fact]
        public void CheckForStringThatStartsWithFShouldReturnTrue()
        {
            Assert.True(digit.Match("fab"));
        }

        [Fact]
        public void CheckForStringThatStartsWithBShouldReturnTrue()
        {
            Assert.True(digit.Match("bcd"));
        }

        [Fact]
        public void CheckForStringThatStartsWithANumberShouldReturnFalse()
        {
            Assert.False(digit.Match("1ab"));
        }

        [Fact]
        public void CheckForNullShouldReturnFalse()
        {
            Assert.False(digit.Match(null));
        }

        [Fact (Skip = "Locked test")]
        public void CheckForEmptyStringShouldReturnFalse()
        {
            Assert.False(digit.Match(""));
        }
    }
}
