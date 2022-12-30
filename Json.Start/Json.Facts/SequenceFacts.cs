using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class SequenceFacts
    {
        [Fact]
        public void CheckForAB()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            Assert.True(ab.Match("abcd").Success());
            Assert.Equal("cd", ab.Match("abcd").RemainingText());
        }
    }
}
