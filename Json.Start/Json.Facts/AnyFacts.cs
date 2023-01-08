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
        Any e = new Any("eE");
        Any sign = new Any("-+");
        
        [Fact]
        public void CheckForExistingLowerCaseEShouldReturnTrue()
        {
            Assert.True(e.Match("ea").Success());
            Assert.Equal("a", e.Match("ea").RemainingText());
        }

        [Fact (Skip = "Test Locked")]
        public void CheckForUpperCaseEShouldReturnTrue()
        {
            Assert.True(e.Match("Ea").Success());
            Assert.Equal("a", e.Match("Ea").RemainingText());
        }

        [Fact (Skip = "Test Locked")]
        public void CheckForInexistentCharShouldReturnFalse()
        {
            Assert.False(e.Match("a").Success());
            Assert.Equal("a", e.Match("a").RemainingText());
        }

        [Fact (Skip = "Test Locked")]
        public void CheckForEmptyStringShouldReturnFalse()
        {
            Assert.False(e.Match("").Success());
            Assert.Equal("", e.Match("").RemainingText());
        }

        [Fact (Skip = "Test Locked")]
        public void CheckForNullShouldReturnFalse()
        {
            Assert.False(e.Match(null).Success());
            Assert.Null(e.Match(null).RemainingText());
        }

        [Fact (Skip = "Test Locked")]
        public void CheckForExistentPlusSignShouldReturnTrue()
        {
            Assert.True(sign.Match("+3").Success());
            Assert.Equal("3", sign.Match("+3").RemainingText());
        }

        [Fact (Skip = "Test Locked")]
        public void CheckForExistentMinusSignShouldReturnTrue()
        {
            Assert.True(sign.Match("-2").Success());
            Assert.Equal("2", sign.Match("-2").RemainingText());
        }

        [Fact (Skip = "Test Locked")]
        public void CheckForNoSignShouldReturnFalse()
        {
            Assert.False(sign.Match("2").Success());
            Assert.Equal("2", sign.Match("2").RemainingText());
        }
    }
}
