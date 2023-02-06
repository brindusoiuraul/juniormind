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

        public Validator()
        {
            var verb = new Verb();
            var argument = new Argument();
            var value = new Value();

            this.patterns = new IPattern[] { verb, argument, value };
        }

        public bool Validate(string[] args)
        {
            if (args == null || args.Length > patterns.Length)
            {
                return false;
            }

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