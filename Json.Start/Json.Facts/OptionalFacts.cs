﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class OptionalFacts
    {
        OptionalJson a = new OptionalJson(new Character('a'));
        OptionalJson sign = new OptionalJson(new Character('-'));

        [Fact]
        public void CheckWhenIsOnlyOnePatternPresentShouldRemainBC()
        {
            Assert.True(a.Match("abc").Success());
            Assert.Equal("bc", a.Match("abc").RemainingText());
        }

        [Fact]
        public void CheckWhenThereAreMultiplePatternsPresentShouldRemainABC()
        {
            Assert.True(a.Match("aabc").Success());
            Assert.Equal("abc", a.Match("aabc").RemainingText());
        }

        [Fact]
        public void CheckWhenThereIsNoPatternPresentShouldRemainBC()
        {
            Assert.True(a.Match("bc").Success());
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }

        [Fact]
        public void CheckWhenThereIsAnEmptyStringShouldRemainEmptyString()
        {
            Assert.True(a.Match("").Success());
            Assert.Equal("", a.Match("").RemainingText());
        }

        [Fact]
        public void CheckWhenThereIsNullShouldRemainNull()
        {
            Assert.True(a.Match(null).Success());
            Assert.Null(a.Match(null).RemainingText());
        }

        [Fact]
        public void CheckWhenThereIsNoSignShouldReturn123()
        {
            Assert.True(sign.Match("123").Success());
            Assert.Equal("123", sign.Match("123").RemainingText());
        }

        [Fact]
        public void CheckWheneThereIsSignShouldRemain123()
        {
            Assert.True(sign.Match("-123").Success());
            Assert.Equal("123", sign.Match("-123").RemainingText());
        }
    }
}
