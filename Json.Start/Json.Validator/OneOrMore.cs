using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class OneOrMore : IPattern
    {
        readonly IPattern pattern;

        public OneOrMore(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
