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
                using var compressedStream = new GZipStream(stream, CompressionMode.Compress, leaveOpen: true);
                WriteToStream(compressedStream, input);
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

            if (compressed)
            {
                using var deprocessedStream = new GZipStream(stream, CompressionMode.Decompress);

                using var reader = new StreamReader(deprocessedStream);
                return reader.ReadToEnd();
            }
            else
            {
                using var reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
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