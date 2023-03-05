using Xunit;

namespace ArgumentsValidator
{
    public class ValidatorTests
    {
        [Fact]
        public void CheckForTwoValidSimpleVerbs()
        {
            Verb commit = new Verb("commit", new Argument("message", "m", new Value()));
            Verb clone = new Verb("clone", new Argument("all", "a"));

            Validator validator = new Validator(commit, clone);

            string[] correctCommitCommand = { "commit", "--message", "abc" };
            string[] correctCloneCommand = { "clone", "-a" };

            Assert.True(validator.Match(correctCommitCommand).Success());
            Assert.True(validator.Match(correctCloneCommand).Success());
        }

        [Fact]
        public void CheckForTwoMoreComplexVerbs()
        {
            var commit = new Verb("commit", new Argument("message", "m", new Argument("setcolor", "s", new Value("red"), new Value("green"), new Value("blue"))));
            var clone = new Verb("clone", new Argument("all", "a"));

            string[] commitCommand = { "commit", "--message", "--setcolor", "green" };
            string[] cloneCommand = { "clone", "-a" };

            Validator validator = new Validator(commit, clone);

            Assert.True(validator.Match(commitCommand).Success());
            Assert.True(validator.Match(cloneCommand).Success());
        }
    }
}
