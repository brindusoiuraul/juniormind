using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsValidator
{
    public class Argument : IArguments
    {
        readonly IPattern pattern;
        readonly Value? value;

        public Argument(Value? value = null)
        {
            this.value = value;
            this.pattern = new Sequence(
                new Many(new Character('-')),
                new OneOrMore(new Range('a', 'z')));
        }

        public ICheck CheckArg(string[] arguments)
        {
            if (value == null && arguments.Length > 1 && arguments[1][0] != '-')
            {
                return new Check(false, arguments[1..]);
            }

            return pattern.Match(arguments[0]).Success() ?
                new Check(true, arguments[1..]) :
                new Check(false, arguments[1..]);
        }
    }
}
