using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsValidator
{
    public class OptionArg
    {
        readonly string name;
        readonly List<Value>? values;

        public OptionArg(string name, List<Value>? values = null)
        {
            this.name = name;
            this.values = values;
        }
    }
}
