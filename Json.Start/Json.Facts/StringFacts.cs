using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class StringFacts
    {
        [Fact]
        public void CheckForCorrectJSONStringShouldReturnTrue()
        {
            var jsonString = new StringJson();
            Assert.True(jsonString.Match(Quoted("xyz")).Success());
        }

        public string Quoted(string text)
            => $"\"{text}\"";
    }
}
