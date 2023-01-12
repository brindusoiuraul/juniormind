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
            var digit = new Range('0', '9');
            var digits = new OneOrMore(digit);

            var number = new Sequence(
                new OptionalJson(sign),
                new Choice(
                    new Character('0'),
                    digits));

            var fraction = new OptionalJson(
                new Sequence(
                    dot,
                    digits));

            var exponent = new OptionalJson(
                    new Sequence(
                        exp,
                        new OptionalJson(sign),
                        digits));

            this.pattern = new Sequence(number, fraction, exponent);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
