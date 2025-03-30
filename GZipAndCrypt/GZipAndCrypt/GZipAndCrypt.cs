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

            if (compress)
            {
                using var processedStream = new GZipStream(stream, CompressionMode.Compress, leaveOpen: true);
                WriteToStream(processedStream, input);
            }
            else
            {
                WriteToStream(stream, input);
            }

            stream.Position = 0;
        }

        public string Read(Stream stream, bool compressed = false, bool encrypted = false)
        {
            ArgumentNullException.ThrowIfNull(stream);

            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        private static void WriteToStream(Stream stream, string input)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(input);

            stream.Write(dataBytes, 0, dataBytes.Length);
            stream.Flush();
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