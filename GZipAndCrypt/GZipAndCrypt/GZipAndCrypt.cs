using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace GZipAndCrypt
{
    public class GZipAndCrypt
    {
        public GZipAndCrypt()
        {
        }

        public void Write(Stream stream, string input, bool compress = false, bool encrypt = false)
        {
            ArgumentNullException.ThrowIfNull(stream);

            ValidateInput(input);

            WriteToStream(stream, input);
        }

        public string Read(Stream stream, bool compressed = false, bool encrypted = false)
        {
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        private static void WriteToStream(Stream stream, string input)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(input);

            stream.Write(dataBytes, 0, dataBytes.Length);
            stream.Flush();

            stream.Position = 0;
        }

        private static void ValidateInput(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return;
            }

            throw new ArgumentException("Input text cannot be null or empty!", nameof(input));
        }
    }
}