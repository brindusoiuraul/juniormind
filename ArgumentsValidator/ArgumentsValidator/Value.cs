using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsValidator
{
    public class Value : IArguments
    {
        readonly IPattern pattern;

        public Value()
        {
            this.pattern = new OneOrMore(new Choice(new Range('a', 'z'), new Range('0', '9')));
        }

        public ICheck CheckArg(string[] arguments)
        {
            return
                pattern.Match(arguments[0]).Success() ?
                new Check(true, arguments[1..]) :
                new Check(false, arguments[1..]);
        }
    }
}
