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

        public void Write(string? text, bool compress, bool crypt)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text), "Parameter cannot be null.");
            }

            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            stream.Write(textBytes, 0, textBytes.Length);
        }
    }
}