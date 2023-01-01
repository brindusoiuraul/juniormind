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
            if (accepted.Contains(text[0]))
            {
                return new Match(true, text[1..]);
            }

            return new Match(false, text);
        }
    }
}
