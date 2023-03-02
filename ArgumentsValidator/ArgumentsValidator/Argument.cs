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
        readonly string? value;

        public Argument(string name, string? value = null, string? alias = null)
        {
            this.name = name;
            this.alias = alias;
            this.value = value;
        }
    }
}
