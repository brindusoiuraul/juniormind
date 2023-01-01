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
    }
}
