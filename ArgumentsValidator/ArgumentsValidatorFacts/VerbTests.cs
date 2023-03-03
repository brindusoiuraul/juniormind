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

        [Fact]
        public void CheckForValidVerbJustWithAliasShouldReturnTrue()
        {
            Verb verb = new Verb("commit", new Argument("message", "m"));
            string[] commands = { "commit", "-m" };

            Assert.True(verb.Match(commands).Success());
        }

        [Fact]
        public void CheckForInvalidVerbWithIncorrectArgumentName()
        {
            Verb verb = new Verb("commit", new Argument("message", "m"));
            string[] commands = { "commit", "-message" };

            Assert.False(verb.Match(commands).Success());
        }

        [Fact]
        public void CheckForInvalidVerbWithIncorrectAlias()
        {
            Verb verb = new Verb("commit", new Argument("message", "m"));
            string[] commands = { "commit", "-n" };

            Assert.False(verb.Match(commands).Success());
        }

        [Fact]
        public void CheckForValidVerbWithMultipleArgumentsShouldReturnTrue()
        {
            Verb verb = new Verb("commit", new Argument("message", "m"), new Argument("ammend", "a"));
            string[] commands = { "commit", "--ammend" };
            string[] commands2 = { "commit", "-m" };

            Assert.True(verb.Match(commands).Success());
            Assert.True(verb.Match(commands2).Success());
        }
    }
}