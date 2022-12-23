using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    internal interface IPattern
    {
        public bool Match(string text);
    }
}
