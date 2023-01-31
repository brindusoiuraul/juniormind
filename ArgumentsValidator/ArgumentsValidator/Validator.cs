using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsValidator
{
    public class Validator
    {
        readonly IPattern[] patterns;

        public Validator(IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public bool Validate(string[] args)
        {
            for (int argIndex = 0; argIndex < args.Length; argIndex++)
            {
                if (!patterns[argIndex].Match(args[argIndex]).Success())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
