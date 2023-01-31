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
        public void CheckCorrectVerbShouldReturnTrue()
        {
            var verb = new Verb();
            Assert.True(verb.Match("git").Success());
        }
    }
}
