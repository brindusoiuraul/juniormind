namespace GZipAndCrypt
{
    public class GZipAndCryptTests
    {
        [Fact]
        public void CheckForWriteShouldBeEqual()
        {
            MemoryStream stream = new MemoryStream();
            GZipAndCrypt gzipAndCrypt = new GZipAndCrypt();

            gzipAndCrypt.Write(stream, "testData");

            string readData = string.Empty;

            using (StreamReader reader = new StreamReader(stream))
            {
                readData = reader.ReadToEnd();
                reader.Close();
            }

            Assert.Equal("testData", readData);
        }

        [Fact]
        public void CheckForReadShouldBeEqual()
        {
            MemoryStream stream = new MemoryStream();
            GZipAndCrypt gzipAndCrypt = new GZipAndCrypt();

            gzipAndCrypt.Write(stream, "testData");

            string readData = gzipAndCrypt.Read(stream);

            Assert.Equal("testData", readData);
        }

        [Fact]
        public void CheckForWriteMethodWhenStreamIsNull()
        {
            MemoryStream stream = null;
            GZipAndCrypt gzipAndCrypt = new GZipAndCrypt();

            Assert.Throws<ArgumentNullException>(() => gzipAndCrypt.Write(stream, "testData"));
        }

        [Fact]
        public void CheckForWriteMethodWhenGivenDataIsNull()
        {
            MemoryStream stream = new MemoryStream();
            GZipAndCrypt gzipAndCrypt = new GZipAndCrypt();

            Assert.Throws<ArgumentException>(() => gzipAndCrypt.Write(stream, null));
        }

        [Fact]
        public void CheckForWriteMethodWhenGivenDataIsEmpty()
        {
            MemoryStream stream = new MemoryStream();
            GZipAndCrypt gzipAndCrypt = new GZipAndCrypt();

            var exception = Assert.Throws<ArgumentException>(() => gzipAndCrypt.Write(stream, ""));
            Assert.Equal("Input text cannot be null or empty! (Parameter 'input')", exception.Message);
        }

        [Fact]
        public void CheckForReadMethodWhenGivenStreamIsNull()
        {
             MemoryStream stream = null;
             GZipAndCrypt gZipAndCrypt = new GZipAndCrypt();

            Assert.Throws<ArgumentNullException>(() => gZipAndCrypt.Read(stream));
        }

        [Fact]
        public void CompressionCheckShouldBeEqual()
        {
            MemoryStream stream = new MemoryStream();
            GZipAndCrypt gZipAndCrypt = new GZipAndCrypt();

            gZipAndCrypt.Write(stream, "testData", true, false);

            Assert.Equal("�\b\0\0\0\0\0\0\n*I-.qI,I\0\0\0��\0`��9\b\0\0\0", gZipAndCrypt.Read(stream));
        }
    }
}