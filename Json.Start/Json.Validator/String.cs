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
            var digit = new Range('0', '9');

            var hexChar = new Choice(
                digit,
                new Range('a', 'f'),
                new Range('A', 'F'));

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(hexChar, hexChar, hexChar, hexChar));

            var escapedChars = new Sequence(
                new Character('\\'),
                new Choice(
                    new Any("\\bnrft/"),
                    hexSeq));

            var allowedChars = new Choice(
                new Range(' ', '!'),
                new Range('#', '['),
                new Range(']', char.MaxValue),
                escapedChars);

            this.pattern = new Sequence(doubleQuote, new Many(allowedChars), doubleQuote);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
