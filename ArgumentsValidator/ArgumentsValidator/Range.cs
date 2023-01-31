using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsValidator
{
    public class Range : IPattern
    {
        readonly char start;
        readonly char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public IMatch Match(string text)
        {
            return
                !string.IsNullOrEmpty(text) && text[0] >= start && text[0] <= end ?
                new Match(true, text[1..]) :
                new Match(false, text);
        }
    }
}
