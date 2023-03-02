﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsValidator
{
    public class Verb
    {
        readonly string name;
        readonly List<Argument> arguments;

        public Verb(string name, List<Argument> arguments)
        {
            this.name = name;
            this.arguments = arguments;
        }
    }
}
