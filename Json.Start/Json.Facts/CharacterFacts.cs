using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class CharacterFacts
    {
        Character x = new Character('x');

        [Fact]
        public void CheckForStringWithXAtTheStartShouldReturnTrue()
        {
            Assert.True(x.Match("xavier").Success());
        }

        [Fact]
        public void CheckForStringWithoutXAtTheStartShouldReturnFalse()
        {
            Assert.False(x.Match("Fiora").Success());
        }

        [Fact]
        public void CheckForNullShouldReturnFalse()
        {
            Assert.False(x.Match(null).Success());
        }

        [Fact]
        public void CheckForEmptyStringShouldReturnFalse()
        {
            Assert.False(x.Match("").Success());
        }
    }
}
