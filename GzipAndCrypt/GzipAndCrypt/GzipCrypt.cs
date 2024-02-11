using System;
using System.IO;
using System.IO.Compression;
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

            if (!stream.CanWrite)
            {
                #pragma warning disable CA2201 // Do not raise reserved exception types
                throw new Exception("Stream does not support writing.");
                #pragma warning restore CA2201 // Do not raise reserved exception types
            }

            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            stream.Write(textBytes, 0, textBytes.Length);
        }

        public string Read(bool compressed, bool encrypted)
        {
            stream.Seek(0, SeekOrigin.Begin);

            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);

            return Encoding.UTF8.GetString(buffer);
        }
    }
}