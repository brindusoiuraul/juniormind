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
        Sequence ab = new Sequence(
            new Character('a'),
            new Character('b')
        );

        [Fact]
        public void CheckForStringWhichSequenceOfPatternsIsCorrectShouldReturnTrue()
        {
            Assert.True(ab.Match("abcd").Success());
            Assert.Equal("cd", ab.Match("abcd").RemainingText());
        }

        [Fact]
        public void CheckForStringWhichJustOnePatternIsCorrectShouldReturnFalse()
        {
            Assert.False(ab.Match("ax").Success());
            Assert.Equal("ax", ab.Match("ax").RemainingText());
        }

        [Fact]
        public void CheckForStringWhichNoPatternIsCorrectShouldReturnFalse()
        {
            Assert.False(ab.Match("def").Success());
            Assert.Equal("def", ab.Match("def").RemainingText());
        }

        [Fact]
        public void CheckForEmptyStringShouldReturnFalse()
        {
            Assert.False(ab.Match("").Success());
            Assert.Equal("", ab.Match("").RemainingText());
        }

        [Fact]
        public void CheckForNullShouldReturnFalse()
        {
            Assert.False(ab.Match(null).Success());
            Assert.Null(ab.Match(null).RemainingText());
        }

        [Fact]
        public void CheckForASequenceAndAPatternShouldReturnTrue()
        {
            Sequence abc = new Sequence(
                ab,
                new Character('c')
            );

            Assert.True(abc.Match("abcd").Success());
            Assert.Equal("d", abc.Match("abcd").RemainingText());
        }

        [Fact]
        public void CheckForASequenceAndAPatternShouldReturnFalse()
        {
            Sequence abc = new Sequence(
                ab,
                new Character('c')
            );

            Assert.False(abc.Match("def").Success());
            Assert.Equal("def", abc.Match("def").RemainingText());
        }

        [Fact]
        public void CheckForValidHexSequenceShouldReturnTrue()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );

            Assert.True(hexSeq.Match("u1234").Success());
            Assert.Equal("", hexSeq.Match("u1234").RemainingText());
        }

        [Fact]
        public void CheckForInvalidHexSequenceShouldReturnFalse()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );

            Assert.False(hexSeq.Match("abc").Success());
            Assert.Equal("abc", hexSeq.Match("abc").RemainingText());
        }
    }
}
