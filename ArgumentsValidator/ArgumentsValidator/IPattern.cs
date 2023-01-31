using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsValidator
{
    public interface IPattern
    {
        public IMatch Match(string text);
    }
}
