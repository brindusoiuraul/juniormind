﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class ChoiceFacts
    {
        Choice digit = new Choice(
            new Character('0'),
            new Range('1', '9')
        );

        [Fact]
        public void CheckStringWhenCharacterMatchIsCorrectShouldReturnTrue()
        {
            Assert.True(digit.Match("012").Success());
        }

        [Fact]
        public void CheckStringWhenRangeMatchIsCorrectShouldReturnTrue()
        {
            Assert.True(digit.Match("12").Success());
        }

        [Fact]
        public void CheckStringWhenRangeMatchIsCorrectButIsLastNumberFromTheRangeShouldReturnTrue()
        {
            Assert.True(digit.Match("92").Success());
        }

        [Fact]
        public void CheckStringWithInexistentPatternShouldReturnFalse()
        {
            Assert.False(digit.Match("a9").Success());
        }

        [Fact]
        public void CheckForEmptyStringShouldReturnFalse()
        {
            Assert.False(digit.Match("").Success());
        }

        [Fact]
        public void CheckForNullShouldReturnFalse()
        {
            Assert.False(digit.Match(null).Success());
        }

        [Fact]
        public void CheckForCorrectCharPatternShouldReturnTrue()
        {
            Choice hex = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')
                )
            );

            Assert.True(hex.Match("012").Success());
        }

        [Fact]
        public void CheckForCorrectRangePatternUpperCaseLetters()
        {
            Choice hex = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')
                )
            );

            Assert.True(hex.Match("A9").Success());
        }

        [Fact]
        public void AddNewRangePatternInChoiceShouldReturnTrue()
        {
            Choice hex = new Choice(
                digit,
                new Choice(
                    new Range('a', 'F'),
                    new Range('A', 'F')));

            hex.Add(new Range('x', 'z'));

            Assert.True(hex.Match("yfa").Success());
        }
    }
}
