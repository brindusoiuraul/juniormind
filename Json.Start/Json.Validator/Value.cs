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
            var elements = new List(element, new Character(','));
            var member = new Sequence(whiteSpace, jsonString, new Character(':'), element);
            var members = new List(member, new Character(','));

            var array = new Sequence(
                new Character('['),
                elements,
                whiteSpace,
                new Character(']'));

            var objectJson = new Sequence(
                new Character('{'),
                members,
                whiteSpace,
                new Character('}'));

            value.Add(array);
            value.Add(objectJson);

            this.pattern = element;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}