using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GzipAndCrypt
{
    public class CompressData : PlainDataDecorator
    {
        public CompressData(IData data) : base(data)
        {
        }

        public override string ProcessData(string input) => Compress(base.ProcessData(input));

        private string Compress(string input)
        {
            byte[] data = Encoding.UTF8.GetBytes(input);

            using (var memoryStream = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
                {
                    gzipStream.Write(data, 0, data.Length);
                }

                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }
    }
}
