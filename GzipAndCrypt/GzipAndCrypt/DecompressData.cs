using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GzipAndCrypt
{
    public class DecompressData : PlainDataDecorator
    {
        public DecompressData(IData data) : base(data)
        {
        }

        public override string ProcessData(string input) => Decompress(base.ProcessData(input));

        private string Decompress(string input)
        {
            byte[] data = Convert.FromBase64String(input);

            using (var memoryStream = new MemoryStream(data))
            using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
            using (var outputStream = new MemoryStream())
            {
                gzipStream.CopyTo(outputStream);
                return Encoding.UTF8.GetString(outputStream.ToArray());
            }
        }
    }
}
