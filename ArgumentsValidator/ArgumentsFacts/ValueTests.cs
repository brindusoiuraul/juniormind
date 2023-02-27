using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ArgumentsValidator
{
    public class ValueTests
    {
        [Fact]
        public void CheckForCorrectValueShouldReturnTrueAndShouldNotRemainAnything()
        {
            Value value = new Value();
            string[] args = { "raul" };
            Assert.True(value.CheckArg(args).Success());
            Assert.Equal(new string[0], value.CheckArg(args).RemainingArguments());
        }
    }
}
