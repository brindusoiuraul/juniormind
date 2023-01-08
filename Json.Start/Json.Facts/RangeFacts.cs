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
            Assert.True(digit.Match("abc").Success());
        }

        [Fact]
        public void CheckForStringThatStartsWithFShouldReturnTrue()
        {
            Assert.True(digit.Match("fab").Success());
        }

        [Fact]
        public void CheckForStringThatStartsWithBShouldReturnTrue()
        {
            Assert.True(digit.Match("bcd").Success());
        }

        [Fact]
        public void CheckForStringThatStartsWithANumberShouldReturnFalse()
        {
            Assert.False(digit.Match("1ab").Success());
        }

        [Fact]
        public void CheckForNullShouldReturnFalse()
        {
            Assert.False(digit.Match(null).Success());
        }

        [Fact]
        public void CheckForEmptyStringShouldReturnFalse()
        {
            Assert.False(digit.Match("").Success());
        }
    }
}
