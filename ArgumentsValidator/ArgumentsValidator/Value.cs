﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsValidator
{
    public class Value
    {
        readonly string? name;

        public Value(string? name = null)
        {
            this.name = name;
        }
    }
}