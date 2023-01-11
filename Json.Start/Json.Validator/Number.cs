using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Number : IPattern
    {
        readonly IPattern pattern;

        public Number()
        {
            var sign = new Any("-+");
            var exp = new Any("eE");
            var dot = new Character('.');
            var digit = new Range('1', '9');

            var number = new Sequence(
                new Optional(sign),
                new Choice(
                    new Character('0'),
                    new OneOrMore(digit)));

            var fraction = new Optional(
                new Sequence(
                    dot,
                    new OneOrMore(digit)));

            var exponent = new Optional(
                    new Sequence(
                        exp,
                        sign,
                        new OneOrMore(digit)));

            this.pattern = new Sequence(number, fraction, exponent);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
