using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class AnyFacts
    {
        [Fact]
        public void CheckForLowerCaseLettersShouldReturnTrue()
        {
            var e = new Any("eE");
            Assert.True(e.Match("ea").Success());
            Assert.Equal("a", e.Match("ea").RemainingText());
        }

        [Fact]
        public void CheckForUppercaseLetterShouldReturnTrue()
        {
            var e = new Any("eE");
            Assert.True(e.Match("Ea").Success());
            Assert.Equal("a", e.Match("Ea").RemainingText());
        }

        [Fact]
        public void CheckForOneLowerCaseLetterShouldReturnFalse()
        {
            var e = new Any("eE");
            Assert.False(e.Match("a").Success());
            Assert.Equal("a", e.Match("a").RemainingText());
        }

        [Fact]
        public void CheckForEmptyStringShouldReturnFalse()
        {
            var e = new Any("eE");
            Assert.False(e.Match("").Success());
            Assert.Equal("", e.Match("").RemainingText());
        }

        [Fact]
        public void CheckForNullStringShouldReturnFalse()
        {
            var e = new Any("eE");
            Assert.False(e.Match(null).Success());
            Assert.Null(e.Match(null).RemainingText());
        }

        [Fact]
        public void CheckForPlusSignShouldReturnTrue()
        {
            var sign = new Any("-+");
            Assert.True(sign.Match("+3").Success());
            Assert.Equal("3", sign.Match("+3").RemainingText());
        }
        
        [Fact]
        public void CheckForMinusSignShouldReturnTrue()
        {
            var sign = new Any("-+");
            Assert.True(sign.Match("-2").Success());
            Assert.Equal("2", sign.Match("-2").RemainingText());
        }

        [Fact]
        public void CheckForNoSignShouldReturnFalse()
        {
            var sign = new Any("-+");
            Assert.False(sign.Match("2").Success());
            Assert.Equal("2", sign.Match("2").RemainingText());
        }
    }
}
