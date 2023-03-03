using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsValidator
{
    public class Argument : IArgument
    {
        readonly string name;
        readonly string? alias;
        readonly IArgument[] options;

        public Argument(string name, string? alias = null, params IArgument[] options)
        {
            this.name = "--" + name;
            this.alias = "-" + alias;
            this.options = options;
        }

        public IMatch Match(string[] args)
        {
            if (name != args[0] && alias != args[0])
            {
                return new Match(false, args);
            }

            return new Match(true, args[1..]);
        }
    }
}
