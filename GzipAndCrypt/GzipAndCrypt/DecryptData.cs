using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace GzipAndCrypt
{
    public class DecryptData : PlainDataDecorator
    {
        public DecryptData(IData data) : base(data)
        {
        }

        public override string ProcessData(string input)
        {
            return Decrypt(base.ProcessData(input));
        }

        private string Decrypt(string input)
        {
            byte[] data = Convert.FromBase64String(input);

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(data[i] - 1);
            }

            return Encoding.UTF8.GetString(data);
        }
    }
}
