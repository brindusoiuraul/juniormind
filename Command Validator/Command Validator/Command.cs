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

        public Command(string command, string value = "none")
        {
            this.argument = command;
            this.value = value;
        }
    }
}
