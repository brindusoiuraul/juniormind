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

            Assert.False(ab.Match("ax").Success());
            Assert.Equal("ax", ab.Match("ax").RemainingText());

            Assert.False(ab.Match("def").Success());
            Assert.Equal("def", ab.Match("def").RemainingText());

            Assert.False(ab.Match("").Success());
            Assert.Equal("", ab.Match("").RemainingText());

            Assert.False(ab.Match("null").Success());
            Assert.Equal("null", ab.Match("null").RemainingText());
        }

        [Fact]
        public void CheckForABC()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            var abc = new Sequence(
                ab,
                new Character('c')
            );

            Assert.True(abc.Match("abcd").Success());
            Assert.Equal("d", abc.Match("abcd").RemainingText());
        }
    }
}
