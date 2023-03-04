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

        [Fact]
        public void CheckValidArgumentWithASingleOptionShouldReturnTrue()
        {
            Argument argument = new Argument("message", "m", new Argument("ammend", "a"));
            string[] commands = { "--message", "--ammend" };

            Assert.True(argument.Match(commands).Success());
        }

        [Fact]
        public void CheckForValidArgumentWithMultipleOptionsShouldReturnTrue()
        {
            Argument argument = new Argument("message", "m", new Argument("ammend", "a"), new Argument("color", "c"));
            string[] commands = { "--message", "-c" };

            Assert.True(argument.Match(commands).Success());
        }

        [Fact]
        public void CheckForInvalidArgumentWithAnOptionShouldReturnFalse()
        {
            Argument argument = new Argument("message", "m", new Argument("ammend", "a"));
            string[] commands = { "--message", "--color" };

            Assert.False(argument.Match(commands).Success());
        }

        [Fact]
        public void CheckForInvalidArgumentWithMultipleOptionsShouldReturnFalse()
        {
            Argument argument = new Argument("message", "m", new Argument("ammend", "a"), new Argument("setcolor", "s"));
            string[] commands = { "--message", "--color" };

            Assert.False(argument.Match(commands).Success());
        }
    }
}
