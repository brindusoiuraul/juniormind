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

            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException(nameof(input));
            }

            byte[] dataBytes = Encoding.UTF8.GetBytes(input);

            stream.Write(dataBytes, 0, dataBytes.Length);
            stream.Flush();
            stream.Seek(0, SeekOrigin.Begin);
        }

        public string Read(Stream stream, bool compressed = false, bool encrypted = false)
        {
            throw new NotImplementedException();
        }
    }
}