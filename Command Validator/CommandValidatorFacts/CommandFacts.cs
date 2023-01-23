using Xunit;

namespace Command_Validator
{
    public class CommandFacts
    {
        [Fact]
        public void CheckForArgumentAndNoValue()
        {
            Command command = new Command("--message");
            Assert.Equal("--message", command.GetArgument());
        }

        [Fact]
        public void CheckForArgumentWithValue()
        {
            Command command = new Command("--message", "abc");
            Assert.Equal("--message", command.GetArgument());
            Assert.Equal("abc", command.GetValue());
        }
    }
}