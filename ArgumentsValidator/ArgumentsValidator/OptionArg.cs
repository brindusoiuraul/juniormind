using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsValidator
{
    public class OptionArg : IArgument
    {
        readonly IArgument option;

        public OptionArg(IArgument option)
        {
            this.option = option;
        }

        public IMatch Match(string[] args)
        {
            return option.Match(args);
        }
    }
}
