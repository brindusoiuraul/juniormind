using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GzipAndCrypt
{
    public abstract class PlainDataDecorator : IData
    {
        protected IData plainData;

        protected PlainDataDecorator(IData data)
        {
            plainData = data;
        }

        public virtual string ProcessData(string input) => plainData.ProcessData(input);
    }
}
