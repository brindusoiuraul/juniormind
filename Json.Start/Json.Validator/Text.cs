using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Text
    {
        readonly string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            return Equals(text[0..prefix.Length], prefix) ? new Match(true, text[prefix.Length..]) : new Match(false, text);
        }
    }
}
