﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Number : IPattern
    {
        readonly IPattern pattern;

        public Number()
        {
            var digit = new Range('1', '9');
            this.pattern = new Choice(new Character('0'), digit);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
