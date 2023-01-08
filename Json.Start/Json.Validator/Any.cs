using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Any
    {
        readonly string accepted;

        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string text)
        {
            if (text == "" || text == null)
            {
                return new Match(false, text);
            }

            return accepted.Contains(text[0]) ? new Match(true, text[1..]) : new Match(false, text);
        }
    }
}
