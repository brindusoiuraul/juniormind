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
        public void CheckForValidFormatShouldReturnTrue()
        {
            IPattern[] patterns = { new Argument(), new Value() };
            var validator = new Validator(patterns);

            string[] args = { "--name", "raul" };
            Assert.True(validator.Validate(args));
        }

        [Fact]
        public void CheckForInvalidFormatShouldReturnFalse()
        {
            IPattern[] patterns = { new Argument(), new Value() };
            var validator = new Validator(patterns);

            string[] args = { "--name", "--raul" };
            Assert.False(validator.Validate(args));
        }

        [Fact]
        public void CheckForTwoArgumentsAndOneWithAValueShouldReturnTrue()
        {
            IPattern[] patterns = { new Argument(), new Argument(), new Value() };
            var validator = new Validator(patterns);

            string[] args = { "--ammend", "--name", "raul" };
            Assert.True(validator.Validate(args));
        }
    }
}
