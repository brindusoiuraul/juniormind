using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsValidator
{
    public class Match : IMatch
    {
        readonly bool success;
        readonly string[] remainingArgs;

        public Match(bool success, string[] remainingArgs)
        {
            this.success = success;
            this.remainingArgs = remainingArgs;
        }

        public bool Success() => success;

        public string[] RemainingArgs() => remainingArgs;
    }
}
