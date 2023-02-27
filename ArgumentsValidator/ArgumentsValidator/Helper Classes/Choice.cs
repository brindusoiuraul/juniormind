using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsValidator
{
    public class Choice : IPattern
    {
        private IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public void Add(IPattern pattern)
        {
            Array.Resize(ref patterns, patterns.Length + 1);
            patterns[patterns.Length - 1] = pattern;
        }

        public IMatch Match(string text)
        {
            IMatch match = new Match(false, text);

            foreach (IPattern pattern in patterns)
            {
                match = pattern.Match(match.RemainingText());

                if (match.Success())
                {
                    return match;
                }
            }

            return new Match(false, text);
        }
    }
}
