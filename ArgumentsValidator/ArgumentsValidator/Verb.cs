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

        public IMatch Match(string[] args)
        {
            if (args[0] != name)
            {
                return new Match(false, args);
            }

            foreach (Argument argument in arguments)
            {
                if (argument.Match(args[1..]).Success())
                {
                    return new Match(true, args[1..]);
                }
            }

            return new Match(false, args);
        }
    }
}
