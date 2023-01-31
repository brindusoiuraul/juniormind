using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsValidator
{
    public class Argument : IPattern
    {
        readonly IPattern pattern;

        public Argument()
        {
            var minusSign = new Character('-');
            var letter = new Range('a', 'z');
            var letters = new OneOrMore(letter);

            this.pattern = new Sequence(new Many(minusSign), letters);
        }

        public IMatch Match(string text)
        {
            return this.pattern.Match(text);
        }
    }
}
