namespace GZipAndCrypt
{
    public class GZipAndCryptTests
    {
        [Fact]
        public void CheckForWriteMethodShouldBeEqual()
        {
            MemoryStream stream = new MemoryStream();
            GZipAndCrypt gzipAndCrypt = new GZipAndCrypt();

            gzipAndCrypt.Write(stream, "testData");

            var reader = new StreamReader(stream);

            Assert.Equal("testData", reader.ReadToEnd());
        }

        [Fact]
        public void CheckForWriteMethodWhenStreamIsNull()
        {
            MemoryStream stream = null;
            GZipAndCrypt gzipAndCrypt = new GZipAndCrypt();

            Assert.Throws<ArgumentNullException>(() => gzipAndCrypt.Write(stream, "testData"));
        }

        [Fact]
        public void CheckForWriteMethodWhenInputIsNull()
        {
            MemoryStream stream = new MemoryStream();
            GZipAndCrypt gzipAndCrypt = new GZipAndCrypt();

            Assert.Throws<ArgumentException>(() => gzipAndCrypt.Write(stream, null));
        }

        [Fact]
        public void CheckForWriteMethodWhenInputIsEmpty()
        {
            MemoryStream stream = new MemoryStream();
            GZipAndCrypt gzipAndCrypt = new GZipAndCrypt();

            Assert.Throws<ArgumentException>(() => gzipAndCrypt.Write(stream, string.Empty));
        }

        [Fact]
        public void CheckForReadMethodShouldReturnTrue()
        {
            MemoryStream stream = new MemoryStream();
            GZipAndCrypt gzipAndCrypt = new GZipAndCrypt();

            gzipAndCrypt.Write(stream, "testData");

            Assert.Equal("testData", gzipAndCrypt.Read(stream));
        }

        [Fact]
        public void CheckForReadMethodWhenStreamIsNull()
        {
            MemoryStream stream = null;
            GZipAndCrypt gzipAndCrypt = new GZipAndCrypt();

            Assert.Throws<ArgumentNullException>(() => gzipAndCrypt.Read(stream));
        }
    }
}