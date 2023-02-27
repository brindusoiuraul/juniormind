using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgumentsValidator
{
    public class Check : ICheck
    {
        readonly bool success;
        readonly string[] remainingArguments;

        public Check(bool success, string[] remainingArguments)
        {
            this.success = success;
            this.remainingArguments = remainingArguments;
        }

        public bool Success()
        {
            return success;
        }

        public string[] RemainingArguments()
        {
            return remainingArguments;
        }
    }
}
