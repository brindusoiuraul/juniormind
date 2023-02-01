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
            this.patterns = SetPatterns();
        }

        public bool Validate(string[] args)
        {
            if (args == null || args.Length < patterns.Length || args.Length > patterns.Length)
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

        private IPattern[] SetPatterns()
        {
            return new IPattern[] { new Verb(), new Argument(), new Value() };
        }
    }
}