using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ArgumentsValidator
{
    public class ValidatorFacts
    {
       [Fact]
       public void CheckForCorrectPatternShouldReturnTrue()
        {
            var validator = new Validator();
            string[] args = { "commit", "--message", "abc" };

            Assert.True(validator.Validate(args));
        }

        [Fact]
        public void CheckForIncorrectPatternShouldReturnFalse()
        {
            var validator = new Validator();
            string[] args = { "--message", "commit", "abc" };

            Assert.False(validator.Validate(args));
        }
    }
}
