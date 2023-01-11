using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class NumberFacts
    {
        [Fact]
        public void CheckForZeroShouldReturnTrue()
        {
            var number = new Number();
            Assert.True(number.Match("0").Success());
        }

        [Fact]
        public void CheckIfContainsLettersShouldReturnFalse()
        {
            var number = new Number();
            Assert.False(number.Match("a").Success());
        }

        [Fact]
        public void CheckIfNumberCanHaveASingleDigitShouldReturnTrue()
        {
            var number = new Number();
            Assert.True(number.Match("7").Success());
        }

        [Fact]
        public void CheckIfNumberHasMultipleDigitsShouldReturnTrue()
        {
            var number = new Number();
            Assert.True(number.Match("70").Success());
        }

        [Fact]
        public void CheckIfNumberIsNullShouldReturnFalse()
        {
            var number = new Number();
            Assert.False(number.Match(null).Success());
        }

        [Fact]
        public void CheckIfNumberIsAnEmptyStringShouldReturnFalse()
        {
            var number = new Number();
            Assert.False(number.Match("").Success());
        }

        [Fact]
        public void CheckIfNumberIsNegativeShouldReturnTrue()
        {
            var number = new Number();
            Assert.True(number.Match("-26").Success());
        }

        [Fact]
        public void CheckIfNumberCanBeMinusZeroShouldReturnTrue()
        {
            var number = new Number();
            Assert.True(number.Match("-0").Success());
        }

        [Fact]
        public void CheckIfNumberIsFractionalShouldReturnTrue()
        {
            var number = new Number();
            Assert.True(number.Match("12.34").Success());
        }

        [Fact]
        public void FractionCanHaveLeadingZeroesShouldReturnTrue()
        {
            var number = new Number();
            Assert.True(number.Match("0.00000001").Success());
            Assert.True(number.Match("10.00000001").Success());
        }

        [Fact]
        public void CheckForExponentShouldReturnTrue()
        {
            var number = new Number();
            Assert.True(number.Match("12e3").Success());
        }

        [Fact]
        public void TheExponentCanBeCapitalEShouldReturnTrue()
        {
            var number = new Number();
            Assert.True(number.Match("12E3").Success());
        }

        [Fact]
        public void ExponentCanBePositiveShouldReturnTrue()
        {
            var number = new Number();
            Assert.True(number.Match("12e+3").Success());
        }

        [Fact]
        public void ExponentCanBeNegativeShouldReturnTrue()
        {
            var number = new Number();
            Assert.True(number.Match("61e-9").Success());
        }

        [Fact]
        public void CanHaveFractionAndExponentShouldReturnTrue()
        {
            var number = new Number();
            Assert.True(number.Match("12.34E3").Success());
        }
    }
}
