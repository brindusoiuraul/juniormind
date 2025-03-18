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

        public void Write(Stream stream, string message, bool encrypt = false, bool compress = false)
        {
            CheckForStreamValidation(stream);
            ValidateData(message);

            IData data = SelectProcesses(encrypt, compress);

            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8, 1024, leaveOpen: true))
            {
                writer.Write(data.ProcessData(message));
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

        private IData SelectProcesses(bool encrypt, bool compress)
        {
            IData data = new PlainData();

            if (encrypt)
            {
                data = new EncryptData(data);
            }

            if (compress)
            {
                data = new CompressData(data);
            }

            return data;
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