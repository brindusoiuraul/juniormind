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

        [Fact(Skip = "Test Locked")]
        public void CheckIfNumberHasMultipleDigitsShouldReturnTrue()
        {
            var number = new Number();
            Assert.True(number.Match("70").Success());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckIfNumberIsNullShouldReturnFalse()
        {
            var number = new Number();
            Assert.False(number.Match(null).Success());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckIfNumberIsAnEmptyStringShouldReturnFalse()
        {
            var number = new Number();
            Assert.False(number.Match("").Success());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckIfNumberStartsWithZeroShouldReturnFalse()
        {
            var number = new Number();
            Assert.False(number.Match("07").Success());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckIfNumberIsNegativeShouldReturnTrue()
        {
            var number = new Number();
            Assert.True(number.Match("-26").Success());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckIfNumberCanBeMinusZeroShouldReturnTrue()
        {
            var number = new Number();
            Assert.True(number.Match("-0").Success());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckIfNumberIsFractionalShouldReturnTrue()
        {
            var number = new Number();
            Assert.True(number.Match("12.34").Success());
        }

        [Fact(Skip = "Test Locked")]
        public void FractionCanHaveLeadingZeroesShouldReturnTrue()
        {
            var number = new Number();
            Assert.True(number.Match("0.00000001").Success());
            Assert.True(number.Match("10.00000001").Success());
        }

        [Fact(Skip = "Test Locked")]
        public void EndsWithADotShouldReturnFalse()
        {
            var number = new Number();
            Assert.False(number.Match("12.").Success());
        }

        [Fact(Skip = "Test Locked")]
        public void HasTwoFractionPartsShouldReturnFalse()
        {
            var number = new Number();
            Assert.False(number.Match("12.34.56").Success());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckForLettersInDecimalPartShouldReturnFalse()
        {
            var number = new Number();
            Assert.False(number.Match("12.3x").Success());
        }

        [Fact(Skip = "Test Locked")]
        public void CheckForExponentShouldReturnTrue()
        {
            var number = new Number();
            Assert.True(number.Match("12e3").Success());
        }

        [Fact(Skip = "Test Locked")]
        public void TheExponentCanBeCapitalEShouldReturnTrue()
        {
            var number = new Number();
            Assert.True(number.Match("12E3").Success());
        }

        [Fact(Skip = "Test Locked")]
        public void ExponentCanBePositiveShouldReturnTrue()
        {
            var number = new Number();
            Assert.True(number.Match("12e+3").Success());
        }

        [Fact(Skip = "Test Locked")]
        public void ExponentCanBeNegativeShouldReturnTrue()
        {
            var number = new Number();
            Assert.True(number.Match("61e-9").Success());
        }

        [Fact(Skip = "Test Locked")]
        public void CanHaveFractionAndExponentShouldReturnTrue()
        {
            var number = new Number();
            Assert.True(number.Match("12.34E3").Success());
        }

        [Fact(Skip = "Test Locked")]
        public void ExponentDoesNotContainLettersShouldReturnFalse()
        {
            var number = new Number();
            Assert.False(number.Match("22e3x3").Success());
        }

        [Fact(Skip = "Test Locked")]
        public void CanContainTwoExponentShouldReturnFalse()
        {
            var number = new Number();
            Assert.False(number.Match("22e323e33").Success());
        }

        [Fact(Skip = "Test Locked")]
        public void TheExponentCanBeIncompleteShouldReturnFalse()
        {
            var number = new Number();
            Assert.False(number.Match("22e").Success());
            Assert.False(number.Match("22e+").Success());
            Assert.False(number.Match("23E-").Success());
        }

        [Fact(Skip = "Test Locked")]
        public void TheExponentCanBeAfterTheFractionShouldReturnFalse()
        {
            var number = new Number();
            Assert.False(number.Match("22e3.3").Success());
        }
    }
}
