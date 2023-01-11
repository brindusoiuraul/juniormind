using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class StringJson : IPattern
    {
        readonly IPattern pattern;

        public StringJson()
        {
            var doubleQuote = new Character('"');
            var lowerCaseLetter = new Range('a', 'z');
            var upperCaseLetter = new Range('A', 'Z');

            var letters = new OneOrMore(new Choice(lowerCaseLetter, upperCaseLetter));

            this.pattern = new Sequence(doubleQuote, new OptionalJson(letters), doubleQuote);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
