using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GzipAndCrypt
{
    public class EncryptData : PlainDataDecorator
    {
        public EncryptData(IData data) : base(data)
        {
        }

        public override string ProcessData(string input)
        {
            return Encrypt(base.ProcessData(input));
        }

        private string Encrypt(string input)
        {
            byte[] data = Encoding.UTF8.GetBytes(input);

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(data[i] + 1);
            }

            return Convert.ToBase64String(data);
        }
    }
}
