using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsValidator
{
    public interface IMatch
    {
        public bool Success();

        public string[] RemainingArgs();
    }
}
