using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Sequence : IPattern
    {
        readonly IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            IMatch match = new Match(false, text);

            foreach (IPattern pattern in patterns)
            {
                match = pattern.Match(match.RemainingText());

                if (!match.Success())
                {
                    return new Match(false, text);
                }
            }

            return match;
        }
    }
}
