using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class StringJson : IPattern
    {
        readonly IPattern pattern;

        public StringJson()
        {
            throw new NotImplementedException();
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
