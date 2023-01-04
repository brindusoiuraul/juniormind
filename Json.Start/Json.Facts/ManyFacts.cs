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
    }
}
