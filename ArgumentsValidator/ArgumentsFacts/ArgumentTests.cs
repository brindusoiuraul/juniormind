using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ArgumentsValidator
{
    public class ArgumentTests
    {
        [Fact]
        public void CheckValidArgumentWithoutValueShouldReturnTrue()
        {
            Argument argument = new Argument();
            string[] args = { "--ammend" };

            Assert.True(argument.CheckArg(args).Success());
        }

        [Fact]
        public void CheckValidArgumentWithValueShouldReturnTrue()
        {
            Argument argument = new Argument(new Value());
            string[] args = { "--message", "abc" };

            Assert.True(argument.CheckArg(args).Success());
        }

        [Fact]
        public void CheckInvalidArgumentWithValueAndShouldNotHaveValueShouldReturnFalse()
        {
            Argument argument = new Argument();
            string[] args = { "--message", "abc" };

            Assert.False(argument.CheckArg(args).Success());
        }

        [Fact]
        public void CheckInvalidArgumentWithValueAndShouldReturnHaveJustOneValueShouldReturnFalse()
        {
            Argument argument = new Argument();
            string[] args = { "--message", "abc", "raul" };

            Assert.False(argument.CheckArg(args).Success());
        }
    }
}
