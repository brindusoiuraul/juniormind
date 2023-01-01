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
    }
}
