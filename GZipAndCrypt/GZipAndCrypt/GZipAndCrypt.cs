using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace GZipAndCrypt
{
    public class GZipAndCrypt
    {
        readonly Aes AesEncryptor = Aes.Create();

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
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(input);
            writer.Flush();

            FlushCryptoStreamFinalBlock(stream);
        }

        private void FlushCryptoStreamFinalBlock(Stream stream)
        {
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