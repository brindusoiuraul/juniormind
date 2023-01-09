using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class List : IPattern
    {
        readonly IPattern pattern;

        public List(IPattern element, IPattern separator)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
