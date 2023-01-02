using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class TextFacts
    {
        Text True = new Text("true");

        [Fact]
        public void CheckForExistingPrefixShouldReturnTrue()
        {
            Assert.True(True.Match("true").Success());
            Assert.Equal("", True.Match("true").RemainingText());
        }
    }
}
