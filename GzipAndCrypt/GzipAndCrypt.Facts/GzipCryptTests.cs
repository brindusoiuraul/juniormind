using System.Text;
using Xunit;
using static System.Net.Mime.MediaTypeNames;

namespace GzipAndCrypt
{
    public class GzipCryptTests
    {
        [Fact]
        public void CheckForStreamdWrite()
        {
            MemoryStream stream = new MemoryStream();
            GzipCrypt gzipCrypt = new GzipCrypt(stream);

            gzipCrypt.Write("This is a test text.", false, false);

            stream.Seek(0, SeekOrigin.Begin);

            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);

            string content = Encoding.UTF8.GetString(buffer);

            Assert.Equal("This is a test text.", content);
        }

        [Fact]
        public void CheckForStreamWriteShouldNotBeEqual()
        {
            MemoryStream stream = new MemoryStream();
            GzipCrypt gzipCrypt = new GzipCrypt(stream);

            gzipCrypt.Write("Raul", false, false);

            stream.Seek(0, SeekOrigin.Begin);

            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);

            string content = Encoding.UTF8.GetString(buffer);

            Assert.NotEqual("", content);
        }

        [Fact]
        public void CheckForWriteMethodEncodingArgumentException()
        {
            MemoryStream stream = new MemoryStream();
            GzipCrypt gzipCrypt = new GzipCrypt(stream);

            var exception = Assert.Throws<ArgumentNullException>(() => gzipCrypt.Write(null, false, false));
            Assert.Equal("Parameter cannot be null. (Parameter 'text')", exception.Message);
        }

        [Fact]
        public void CheckForNotSupportedExceptionWhenStreamIsReadOnly()
        {
            MemoryStream stream = new MemoryStream(new byte[] { 1, 2, 3 }, false);
            GzipCrypt gzipCrypt = new GzipCrypt(stream);

            var exception = Assert.Throws<NotSupportedException>(() => gzipCrypt.Write("This is a test text", false, false));
            Assert.Equal("The stream is ReadOnly.", exception.Message);
        }

        [Fact]
        public void CheckForWhenStreamIsDisposed()
        {
            MemoryStream stream = new MemoryStream(new byte[] { 1, 2, 3 }, false);
            GzipCrypt gzipCrypt = new GzipCrypt(stream);

            stream.Dispose();

            var exception = Assert.Throws<ObjectDisposedException>(() => gzipCrypt.Write("This is a test text", false, false));
            Assert.Equal("The stream is Disposed.\r\nObject name: 'stream'.", exception.Message);
        }
    }
}