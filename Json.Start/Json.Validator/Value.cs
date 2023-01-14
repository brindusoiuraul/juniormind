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

            var whiteSpace = new Many(new Any("\n\r\t "));
            var element = new Sequence(whiteSpace, value, whiteSpace);

            this.pattern = element;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
