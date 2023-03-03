using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsValidator
{
    public class Validator : IArgument
    {
        readonly Verb verb;

        public Validator(Verb verb)
        {
            this.verb = verb;
        }

        public IMatch Match(string[] args)
        {
            return verb.Match(args);
        }
    }
}
