using System.Text;

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
            ArgumentNullException.ThrowIfNull(stream);

            return new StreamReader(stream).ReadToEnd();
        }

        private void WriteToStream(Stream stream, string input)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(input);

            stream.Write(dataBytes, 0, dataBytes.Length);
            stream.Flush();
            stream.Seek(0, SeekOrigin.Begin);
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