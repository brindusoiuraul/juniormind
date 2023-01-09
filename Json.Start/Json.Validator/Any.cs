using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Any : IPattern
    {
        readonly string accepted;

        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string text)
        {
            return
                !string.IsNullOrEmpty(text) && accepted.Contains(text[0]) ?
                new Match(true, text[1..]) :
                new Match(false, text);
        }
    }
}
