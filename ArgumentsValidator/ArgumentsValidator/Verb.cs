using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsValidator
{
    public class Verb : IArguments
    {
        readonly Argument[] argumentsPattern;
        readonly IPattern pattern;

        public Verb(params Argument[] argumentsPattern)
        {
            this.argumentsPattern = argumentsPattern;
            this.pattern = new OneOrMore(new Range('a', 'z'));
        }

        public ICheck CheckArg(string[] arguments)
        {
            if (!pattern.Match(arguments[0]).Success())
            {
                return new Check(false, arguments[1..]);
            }

            foreach (Argument argument in argumentsPattern)
            {
                if (!argument.CheckArg(arguments).Success())
                {
                    return new Check(false, arguments);
                }
            }

            return new Check(true, arguments);
        }
    }
}
