using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Validator
{
    public class Command
    {
        readonly string argument;
        readonly string value;
        readonly string alias;

        public Command(string command, string value = "none", string alias = "none")
        {
            this.argument = command;
            this.value = value;
            this.alias = alias;
        }

        public string GetArgument()
        {
            return this.argument;
        }

        public string GetValue()
        {
            return this.value;
        }

        public string GetAlias()
        {
            return this.alias;
        }
    }
}
