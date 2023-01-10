using System;
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
            this.pattern = new Character('0');
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
