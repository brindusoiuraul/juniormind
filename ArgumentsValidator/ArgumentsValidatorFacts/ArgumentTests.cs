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
        public void CheckValidArgumentWithNameShouldReturnTrue()
        {
            Argument argument = new Argument("message", "m");
            string[] commands = { "--message" };

            Assert.True(argument.Match(commands).Success());
        }

        [Fact]
        public void CheckInvalidArgumentWithInvalidName()
        {
            Argument argument = new Argument("message", "m");
            string[] commands = { "--m" };
            
            Assert.False(argument.Match(commands).Success());
        }

        [Fact]
        public void CheckValidArgumentWithValidAlias()
        {
            Argument argument = new Argument("message", "m");
            string[] commands = { "-m" };

            Assert.True(argument.Match(commands).Success());
        }
    }
}
