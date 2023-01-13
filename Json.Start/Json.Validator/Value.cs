using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Value : IPattern
    {
        readonly IPattern pattern;

        public Value()
        {
            this.pattern = new StringJson();
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
