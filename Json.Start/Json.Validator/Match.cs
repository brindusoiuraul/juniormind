using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Match : IMatch
    {
        readonly bool succes;
        readonly string remainingText;

        public Match(bool succes, string remainingText)
        {
            this.succes = succes;
            this.remainingText = remainingText;
        }

        public bool Success()
        {
            return this.succes;
        }

        public string RemainingText()
        {
            return this.remainingText;
        }
    }
}
