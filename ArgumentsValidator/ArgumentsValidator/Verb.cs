using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsValidator
{
    public class Verb
    {
        readonly string name;
        readonly string argument;

        public Verb(string name, string argument)
        {
            this.name = name;
            this.argument = argument;
        }
    }
}
