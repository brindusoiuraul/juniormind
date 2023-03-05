using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsValidator
{
    public class Validator : IArgument
    {
        readonly Verb[] verbs;

        public Validator(params Verb[] verbs)
        {
            this.verbs = verbs;
        }

        public IMatch Match(string[] args)
        {
            foreach (Verb verb in verbs)
            {
                if (verb.Match(args).Success())
                {
                    return verb.Match(args);
                }
            }

            return new Match(false, args);
        }
    }
}
