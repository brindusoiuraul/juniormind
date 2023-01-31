using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ArgumentsValidator
{
    public class ValueFacts
    {
        [Fact]
        public void CheckForCorrectValueShouldReturnTrue()
        {
            var value = new Value();

            Assert.True(value.Match("abc").Success());
            Assert.Equal("", value.Match("abc").RemainingText());
        }
    }
}
