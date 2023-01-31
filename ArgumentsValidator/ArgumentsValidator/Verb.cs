using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsValidator
{
    public class Verb : IPattern
    {
        readonly IPattern pattern;

        public Verb()
        {
            var letter = new Range('a', 'z');
            this.pattern = new OneOrMore(letter);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
