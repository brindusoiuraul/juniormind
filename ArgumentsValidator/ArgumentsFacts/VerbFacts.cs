using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ArgumentsValidator
{
    public class VerbFacts
    {
        [Fact]
        public void CheckForValidVerbShouldReturnTrue()
        {
            Verb verb = new Verb(new Argument(new Value()));
            string[] arguments = { "git", "--message", "abc" };

            Assert.True(verb.CheckArg(arguments).Success());
        }

        [Fact]
        public void CheckForInvalidSimpleVerbShouldReturnFalse()
        {
            Verb verb = new Verb(new Argument());
            string[] arguments = { "git", "--message", "abc" };

            Assert.False(verb.CheckArg(arguments).Success());
        }

        [Fact]
        public void CheckValidVerbWithMultipleArgumentsShouldReturnTrue()
        {
            Verb verb = new Verb(new Argument(new Value()), new Argument());
            string[] arguments = { "git", "--message", "abc", "--ammend" };

            Assert.True(verb.CheckArg(arguments).Success());
        }

        [Fact]
        public void CheckValidVerbWithMultipleArgumentsAndMultipleValuesShouldReturnTrue()
        {
            Verb verb = new Verb(new Argument(new Value()), new Argument(new Value()));
            string[] arguments = { "git", "--message", "abc", "--ammend", "source" };

            Assert.True(verb.CheckArg(arguments).Success());
        }
    }
}
