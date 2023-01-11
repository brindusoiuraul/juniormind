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
        public void CheckForCorrectJSONStringJustLowerCaseShouldReturnTrue()
        {
            var jsonString = new StringJson();
            Assert.True(jsonString.Match(Quoted("xyz")).Success());
        }

        [Fact]
        public void CheckForCorrectJSONStringUsingJustUpperCaseLettersShouldReturnTrue()
        {
            var jsonString = new StringJson();
            Assert.True(jsonString.Match(Quoted("XYZ")).Success());
        }

        [Fact]
        public void CheckForCorrectJSONStringUsingLowerCaseAndUpperCaseLettersShouldReturnTrue()
        {
            var jsonString = new StringJson();
            Assert.True(jsonString.Match(Quoted("xYz")).Success());
        }

        [Fact]
        public void CheckIfDoesNotStartWithQuotesShouldReturnFalse()
        {
            var jsonString = new StringJson();
            Assert.False(jsonString.Match("xyz\"").Success());
        }

        [Fact]
        public void CheckIfDoesNotEndsWithQuotesShouldReturnFalse()
        {
            var jsonString = new StringJson();
            Assert.False(jsonString.Match("\"xyz").Success());
        }

        [Fact]
        public void CheckForNullShouldReturnFalse()
        {
            var jsonString = new StringJson();
            Assert.False(jsonString.Match(null).Success());
        }

        [Fact]
        public void CheckForEmptyStringShouldReturnFalse()
        {
            var jsonString = new StringJson();
            Assert.False(jsonString.Match(string.Empty).Success());
        }

        [Fact]
        public void CheckForEmptyDoubleQuotedStringShouldReturnTrue()
        {
            var jsonString = new StringJson();
            Assert.True(jsonString.Match(Quoted(string.Empty)).Success());
        }

        public string Quoted(string text)
            => $"\"{text}\"";
    }
}
