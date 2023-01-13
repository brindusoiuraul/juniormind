using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Value : IPattern
    {
        readonly IPattern pattern;

        public Value()
        {
            StringJson jsonString = new StringJson();
            Number jsonNumber = new Number();

            var value = new Choice(
                jsonString,
                jsonNumber,
                new TextJson("true"),
                new TextJson("false"),
                new TextJson("null"));

            this.pattern = value;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
