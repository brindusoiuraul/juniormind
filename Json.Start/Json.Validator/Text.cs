using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Text : IPattern
    {
        readonly string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            if (text == "" || text == null)
            {
                return new Match(false, text);
            }

            return text[0..prefix.Length] == prefix ?
                new Match(true, text[prefix.Length..]) :
                new Match(false, text);
        }
    }
}
