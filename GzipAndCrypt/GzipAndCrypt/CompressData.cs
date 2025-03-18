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

        public override string ProcessData(string data) => Convert.ToBase64String(CompressString(data));

        private static byte[] CompressString(string text)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(text);

            using (MemoryStream outputStream = new MemoryStream())
            using (GZipStream gzipStream = new GZipStream(outputStream, CompressionMode.Compress))
            {
                gzipStream.Write(inputBytes, 0, inputBytes.Length);
                gzipStream.Flush();
                return outputStream.ToArray();
            }
        }
    }
}
