﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsValidator
{
    public class Value : IArgument
    {
        readonly string? name;

        public Value(string? name = null)
        {
            this.name = name;
        }

        public IMatch Match(string[] args)
        {
            if (name == null && args[0][0] != '-')
            {
                return new Match(true, args[1..]);
            }

            return name == args[0] ? new Match(true, args[1..]) : new Match(false, args);
        }
    }
}
