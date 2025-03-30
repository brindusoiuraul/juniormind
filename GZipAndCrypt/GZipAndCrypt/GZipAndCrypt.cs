using System.IO.Compression;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace GZipAndCrypt
{
    public class GZipAndCrypt
    {
        readonly System.Security.Cryptography.Aes AesEncryptor = System.Security.Cryptography.Aes.Create();

        public GZipAndCrypt()
        {
        }

        public void Write(Stream stream, string input, bool compress = false, bool encrypt = false)
        {
            ArgumentNullException.ThrowIfNull(stream);

            ValidateInput(input);

            if (compress)
            {
                stream = new GZipStream(stream, CompressionMode.Compress);
            }

            if (encrypt)
            {
                stream = new CryptoStream(stream, AesEncryptor.CreateEncryptor(), CryptoStreamMode.Write);
            }

            WriteToStream(stream, input);
        }

        public string Read(Stream stream, bool compressed = false, bool encrypted = false)
        {
            ArgumentNullException.ThrowIfNull(stream);

            if (compressed)
            {
                stream = new GZipStream(stream, CompressionMode.Decompress);
            }

            if (encrypted)
            {
                stream = new CryptoStream(stream, AesEncryptor.CreateDecryptor(), CryptoStreamMode.Read);
            }

            return new StreamReader(stream).ReadToEnd();
        }

        private void WriteToStream(Stream stream, string input)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(input);

            stream.Write(dataBytes, 0, dataBytes.Length);
            stream.Flush();

            if (stream is CryptoStream encryptedStream)
            {
                encryptedStream.FlushFinalBlock();
            }
        }

        private void ValidateInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException(nameof(input));
            }
        }
    }
}