using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class ValueFacts
    {
        [Fact]
        public void ValidJsonStringShouldReturnTrue()
        {
            var jsonString = new Value();
            Assert.True(jsonString.Match(Quoted("alex\u12E5")).Success());
        }

        [Fact]
        public void InvalidJsonStringShouldReturnFalse()
        {
            var jsonString = new Value();
            Assert.False(jsonString.Match(null).Success());
        }

        [Fact]
        public void CheckForValidJsonNumberShouldReturnTrue()
        {
            var jsonNumber = new Value();
            Assert.True(jsonNumber.Match("123").Success());
        }

        [Fact]
        public void CheckForInvalidJsonNumberShouldReturnFalse()
        {
            var jsonNumber = new Value();
            Assert.False(jsonNumber.Match(null).Success());
        }

        [Fact]
        public void CheckForValidTrueValueShouldReturnTrue()
        {
            var jsonTrueValue = new Value();
            Assert.True(jsonTrueValue.Match("true").Success());
        }

        [Fact]
        public void CheckForInvalidTrueValueShouldReturnFalse()
        {
            var jsonTrueValue = new Value();
            Assert.False(jsonTrueValue.Match("tree").Success());
        }

        [Fact]
        public void CheckForValidFalseValueShouldReturnTrue()
        {
            var jsonFalseValue = new Value();
            Assert.True(jsonFalseValue.Match("false").Success());
        }

        [Fact]
        public void CheckForInvalidFalseValueShouldReturnFalse()
        {
            var jsonFalseValue = new Value();
            Assert.False(jsonFalseValue.Match("fale").Success());
        }

        [Fact]
        public void CheckForValidNullValueShouldReturnTrue()
        {
            var jsonNullValue = new Value();
            Assert.True(jsonNullValue.Match("null").Success());
        }

        [Fact]
        public void CheckForInvalidNullValueShouldReturnFalse()
        {
            var jsonNullValue = new Value();
            Assert.False(jsonNullValue.Match("nul").Success());
        }

        [Fact]
        public void CheckForValidElementShouldReturnTrue()
        {
            var jsonElement = new Value();
            Assert.True(jsonElement.Match(Quoted(" element\u12E5 ")).Success());
        }

        [Fact]
        public void CheckForInvalidElementShouldReturnFalse()
        {
            var jsonElement = new Value();
            Assert.False(jsonElement.Match(" element").Success());
        }

        public string Quoted(string text)
            => $"\"{text}\"";
    }
}
