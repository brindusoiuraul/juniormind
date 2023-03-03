using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsValidator
{
    public class Verb : IArgument
    {
        readonly string name;
        readonly Argument[] arguments;

        public Verb(string name, params Argument[] arguments)
        {
            this.name = name;
            this.arguments = arguments;
        }

        public bool Match(string[] args)
        {
            if (args[0] != name)
            {
                return false;
            }

            args = args[1..];

            foreach (Argument argument in arguments)
            {
                if (argument.Match(args))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
