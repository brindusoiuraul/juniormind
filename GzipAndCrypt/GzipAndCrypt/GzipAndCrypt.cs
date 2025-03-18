using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            IData data = SelectProcessesForStreamWriting(encrypt, compress);

            WriteToStream(stream, data, message);
        }

        public string Read(Stream stream, bool encrypted = false, bool compressed = false)
        {
            CheckForStreamValidation(stream);

            ReadFromStream(stream, out string readDataFromStream);

            return SelectProcessesForStreamReading(encrypted, compressed).ProcessData(readDataFromStream);
        }

        private IData SelectProcessesForStreamReading(bool encrypted, bool compressed)
        {
            IData readData = new PlainData();

            readData = compressed ? new DecompressData(readData) : readData;
            readData = encrypted ? new DecryptData(readData) : readData;

            return readData;
        }

        private IData SelectProcessesForStreamWriting(bool encrypt, bool compress)
        {
            IData data = new PlainData();

            data = encrypt ? new EncryptData(data) : data;
            data = compress ? new CompressData(data) : data;

            return data;
        }

        private void WriteToStream(Stream stream, IData data, string message)
        {
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8, 1024, leaveOpen: true))
            {
                writer.Write(data.ProcessData(message));
                writer.Flush();

                stream.Position = 0;
            }
        }

        private void ReadFromStream(Stream stream, out string readDataFromStream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                readDataFromStream = reader.ReadToEnd();
                reader.Close();
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