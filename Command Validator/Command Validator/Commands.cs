using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Validator
{
    public class Commands
    {
        readonly Command[] commands;
        
        public Commands(Command[] commands)
        {
            this.commands = commands;
        }

        public Command[] GetCommands()
        {
            return this.commands;
        }
    }
}
