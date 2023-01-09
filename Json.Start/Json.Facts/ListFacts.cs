using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class ListFacts
    {
        List a = new List(new Range('0', '9'), new Character(','));

        [Fact(Skip = "Test Locked")]
        public void CheckWhenStringIsEliminatedCompletelyShouldReturnTrueAndRemainEmptyString()
        {
            Assert.True(a.Match("1,2,3").Success());
            Assert.Equal("", a.Match("1,2,3").RemainingText());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckWhenThereIsASeparatorInPlusShouldReturnTrueAndRemainsTheSeparator()
        {
            Assert.True(a.Match("1,2,3,").Success());
            Assert.Equal(",", a.Match("1,2,3,").RemainingText());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckWhenThereIsNoSeparatorShouldReturnTrueAndRemainsA()
        {
            Assert.True(a.Match("1a").Success());
            Assert.Equal("a", a.Match("1a").RemainingText());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckWhenThereIsNoElementNorSeparatorShouldReturnTrueAndTestShouldBeUntouched()
        {
            Assert.True(a.Match("abc").Success());
            Assert.Equal("abc", a.Match("abc").RemainingText());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckForEmptyStringShouldReturnTrueAndRemainAnEmptyString()
        {
            Assert.True(a.Match("").Success());
            Assert.Equal("", a.Match("").RemainingText());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckForNullShouldReturnTrueAndRemainingShouldBeNull()
        {
            Assert.True(a.Match(null).Success());
            Assert.Null(a.Match(null).RemainingText());
        }
    }
}
