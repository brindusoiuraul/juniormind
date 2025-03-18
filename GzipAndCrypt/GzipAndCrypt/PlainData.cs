using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GzipAndCrypt
{
    public class PlainData : IData
    {
        public string ProcessData(string data) => data;
    }
}
