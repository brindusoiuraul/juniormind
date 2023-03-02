using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsValidator
{
    public class Argument
    {
        readonly string name;
        readonly string? alias;
        readonly List<OptionArg>? options;

        public Argument(string name, string? alias = null, List<OptionArg>? options = null)
        {
            this.name = name;
            this.alias = alias;
            this.options = options;
        }
    }
}
