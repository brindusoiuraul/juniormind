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
            var sign = new Any("-+");
            var dot = new Character('.');
            var digit = new Range('1', '9');
            var number = new Sequence(new Optional(sign), new Choice(new Character('0'), digit));
            var fraction = new Sequence(new Optional(dot), digit);
            this.pattern = number;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
