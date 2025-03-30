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

            stream.Seek(0, SeekOrigin.Begin);

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

            stream.Seek(0, SeekOrigin.Begin);

            Assert.Equal("testData", gzipAndCrypt.Read(stream));
        }

        [Fact]
        public void CheckForReadMethodWhenStreamIsNull()
        {
            MemoryStream stream = null;
            GZipAndCrypt gzipAndCrypt = new GZipAndCrypt();

            Assert.Throws<ArgumentNullException>(() => gzipAndCrypt.Read(stream));
        }

        [Fact]
        public void CheckForCompressionInWriteMethodShouldBeEqual()
        {
            MemoryStream stream = new MemoryStream();
            GZipAndCrypt gzipAndCrypt = new GZipAndCrypt();

            gzipAndCrypt.Write(stream, "testData", compress:true);

            stream.Seek(0, SeekOrigin.Begin);

            Assert.Equal("�\b\0\0\0\0\0\0\n*I-.qI,I\0\0\0��", gzipAndCrypt.Read(stream));
        }

        [Fact]
        public void CheckForDecompressionInReadMethodShouldBeEqual()
        {
            MemoryStream stream = new MemoryStream();
            GZipAndCrypt gzipAndCrypt = new GZipAndCrypt();

            gzipAndCrypt.Write(stream, "testData", compress: true);

            stream.Seek(0, SeekOrigin.Begin);

            Assert.Equal("testData", gzipAndCrypt.Read(stream, compressed:true));
        }
    }
}