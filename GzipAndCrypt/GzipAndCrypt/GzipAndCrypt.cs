using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GzipAndCrypt
{
    public class GzipAndCrypt
    {
        public GzipAndCrypt()
        {
        }

        public void Write(Stream stream, string message, bool encrypt = false)
        {
            CheckForStreamValidation(stream);

            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8, 1024, leaveOpen: true))
            {
                writer.Write(message);
                writer.Flush();

                stream.Position = 0;
            }
        }

        public string Read(Stream stream)
        {
            CheckForStreamValidation(stream);

            string readDataFromStream;

            using (StreamReader reader = new StreamReader(stream))
            {
                readDataFromStream = reader.ReadToEnd();
                reader.Close();
            }

            return readDataFromStream;
        }

        public string EncryptData(string data)
        {
            ValidateData(data);

            byte[] keyBytes = SHA256.HashData(Encoding.UTF8.GetBytes("raul-decorator-pattern-project"));
            byte[] iv = new byte[16];

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = iv;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] plainBytes = Encoding.UTF8.GetBytes(data);
                        cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                        cryptoStream.FlushFinalBlock();
                        return Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
            }
        }

        private void CheckForStreamValidation(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream), "Stream cannot be Null!");
            }

            if (stream.CanRead)
            {
                return;
            }

            throw new ArgumentException("Stream is not Readable. Please introduce a readable stream!");
        }

        private void ValidateData(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                return;
            }

            throw new ArgumentException("Input text cannot be null or empty!", nameof(data));
        }
    }
}