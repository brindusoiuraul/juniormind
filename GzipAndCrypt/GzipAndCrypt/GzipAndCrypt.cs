using System;
using System.IO;

namespace GzipAndCrypt
{
    public class GzipAndCrypt
    {
        public GzipAndCrypt()
        {
        }

        public string Read(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream), "Stream cannot be Null!");
            }

            if (!stream.CanRead)
            {
                throw new ArgumentException("Stream is not Readable. Please introduce a readable stream!");
            }

            string readDataFromStream;

            using (StreamReader reader = new StreamReader(stream))
            {
                readDataFromStream = reader.ReadToEnd();
                reader.Close();
            }

            return readDataFromStream;
        }
    }
}