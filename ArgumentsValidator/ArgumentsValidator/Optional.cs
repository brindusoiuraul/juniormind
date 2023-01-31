using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsValidator
{
    public class OptionalJson : IPattern
    {
        readonly IPattern pattern;

        public OptionalJson(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            return new Match(true, pattern.Match(text).RemainingText());
        }
    }
}
