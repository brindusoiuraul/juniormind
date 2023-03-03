using Xunit;

namespace ArgumentsValidator
{
    public class VerbTests
    {
        [Fact]
        public void CheckForValidVerbWithOneArgumentShouldReturnTrue()
        {
            Verb verb = new Verb("commit", new Argument("message", "m"));
            string[] commands = { "commit", "--message" };

            Assert.True(verb.Match(commands).Success());
        }
    }
}