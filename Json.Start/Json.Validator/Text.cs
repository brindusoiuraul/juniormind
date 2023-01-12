using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class TextJson : IPattern
    {
        readonly string prefix;

        public TextJson(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            return
                !string.IsNullOrEmpty(text) && text.StartsWith(prefix) ?
                new Match(true, text[prefix.Length..]) :
                new Match(false, text);
        }
    }
}
