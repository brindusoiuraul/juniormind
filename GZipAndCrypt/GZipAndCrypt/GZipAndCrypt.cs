using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace GZipAndCrypt
{
    public class GZipAndCrypt
    {
        public GZipAndCrypt()
        {
        }

        public void Write(Stream stream, string text, bool compress = false, bool encrypt = false)
        {
            ArgumentNullException.ThrowIfNull(stream);

            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Input text cannot be null or empty!", nameof(text));
            }

            byte[] dataBytes = Encoding.UTF8.GetBytes(text);

            stream.Write(dataBytes, 0, dataBytes.Length);
            stream.Flush();

            stream.Position = 0;
        }

        public string Read(Stream stream, bool compressed = false, bool encrypted = false)
        {
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}