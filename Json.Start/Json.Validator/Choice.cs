using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Choice : IPattern
    {
        readonly IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            var match = new Match(false, text);

            foreach (var pattern in patterns)
            {
                if (pattern.Match(match.RemainingText()).Success())
                {
                    return new Match(true, match.RemainingText());
                }
            }

            return new Match(false, text);
        }
    }
}
