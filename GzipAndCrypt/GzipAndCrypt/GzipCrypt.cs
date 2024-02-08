using System;
using System.IO;
using System.Text;

namespace GzipAndCrypt
{
    public class GzipCrypt
    {
        private readonly Stream stream;

        public GzipCrypt(Stream constructorStream)
        {
            stream = constructorStream;
        }

        public void Write(string text, bool compress, bool crypt)
        {
            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            stream.Write(textBytes, 0, textBytes.Length);
        }
    }
}