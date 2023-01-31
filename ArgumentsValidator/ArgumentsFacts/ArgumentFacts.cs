using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ArgumentsValidator
{
    public class ArgumentFacts
    {
        [Fact]
        public void TestForCorrectArgumentShouldReturnTrue()
        {
            var argument = new Argument();

            Assert.True(argument.Match("--name").Success());
            Assert.Equal("", argument.Match("--name").RemainingText());
        }

        [Fact]
        public void TestForCorrectAbreviatedArgumentShouldReturnTrue()
        {
            var argument = new Argument();

            Assert.True(argument.Match("-n").Success());
            Assert.Equal("", argument.Match("-n").RemainingText());
        }
        
        [Fact]
        public void TestForIncorrectArgumentShouldReturnFalse()
        {
            var argument = new Argument();

            Assert.False(argument.Match("+name").Success());
        }
    }
}
