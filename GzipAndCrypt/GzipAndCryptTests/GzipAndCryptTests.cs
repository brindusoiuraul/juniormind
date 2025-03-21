using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace GzipAndCrypt
{
    public class GzipAndCryptTests
    {
        /*
        [Fact]
        public void TestForReturningASimpleStringShouldReturnTrue()
        {
            string testString = "test";
            GzipAndCrypt readTest = new GzipAndCrypt();

            Assert.Equal(testString, readTest.Read());
        }

        [Fact]
        public void TestForReturningASimpleStringShouldReturnFalse()
        {
            string testString = "tes";
            GzipAndCrypt readTest = new GzipAndCrypt();

            Assert.NotEqual(testString, readTest.Read());
        }
        */

        [Fact]
        public void ReadCheckForAStreamShouldReturnTrue()
        {
            string message = "testData";
            MemoryStream memoryStream = new MemoryStream();

            using (StreamWriter writer = new StreamWriter(memoryStream, Encoding.UTF8, 1024, leaveOpen: true))
            {
                writer.Write(message);
                writer.Flush();

                memoryStream.Position = 0;
            }

            GzipAndCrypt gzipAndCrypt = new GzipAndCrypt();

            Assert.Equal("testData", gzipAndCrypt.Read(memoryStream));
        }

        [Fact]
        public void ReadCheckForAStreamShouldReturnFalse()
        {
            string message = "testData";
            MemoryStream memoryStream = new MemoryStream();

            using (StreamWriter writer = new StreamWriter(memoryStream, Encoding.UTF8, 1024, leaveOpen: true))
            {
                writer.Write(message);
                writer.Flush();

                memoryStream.Position = 0;
            }

            GzipAndCrypt gzipAndCrypt = new GzipAndCrypt();

            Assert.NotEqual("testDat", gzipAndCrypt.Read(memoryStream));
        }

        [Fact]
        public void ReadCheckForWhenStreamIsNotReadableShouldThrowArgumentException()
        {
            string message = "testData";
            MemoryStream memoryStream = new MemoryStream();

            using (StreamWriter writer = new StreamWriter(memoryStream, Encoding.UTF8, 1024))
            {
                writer.Write(message);
                writer.Flush();

                memoryStream.Position = 0;
            }

            GzipAndCrypt gzipAndCrypt = new GzipAndCrypt();

            var exception = Assert.Throws<ArgumentException>(() => gzipAndCrypt.Read(memoryStream));

            Assert.Equal("Stream is not Readable. Please introduce a readable stream!", exception.Message);
        }

        [Fact]
        public void ReadCheckForWhenStreamIsNullShouldThrowArgumentNullException()
        {
            MemoryStream memoryStream = new MemoryStream();

            memoryStream = null;

            GzipAndCrypt gzipAndCrypt = new GzipAndCrypt();

            var exception = Assert.Throws<ArgumentNullException>(() => gzipAndCrypt.Read(memoryStream));

            Assert.Equal("Stream cannot be Null! (Parameter 'stream')", exception.Message);
        }

        [Fact]
        public void CheckForWriteMethodShouldReturnTrue()
        {
            MemoryStream memoryStream = new MemoryStream();
            GzipAndCrypt gzipAndCrypt = new GzipAndCrypt();

            string message = "testData";

            gzipAndCrypt.Write(memoryStream, message);

            Assert.Equal("testData", gzipAndCrypt.Read(memoryStream));
        }

        [Fact]
        public void CheckForWriteMethodShouldReturnFalse()
        {
            MemoryStream memoryStream = new MemoryStream();
            GzipAndCrypt gzipAndCrypt = new GzipAndCrypt();

            string message = "testData";

            gzipAndCrypt.Write(memoryStream, message);

            Assert.NotEqual("testDat", gzipAndCrypt.Read(memoryStream));
        }

        [Fact]
        public void WriteMethodCheckForStreamValidation()
        {
            MemoryStream memoryStream = new MemoryStream();
            GzipAndCrypt gzipAndCrypt = new GzipAndCrypt();

            string message = "testData";

            memoryStream.Close();

            var exception2 = Assert.Throws<ArgumentException>(() => gzipAndCrypt.Write(memoryStream, message));
            Assert.Equal("Stream is not Readable. Please introduce a readable stream!", exception2.Message);

            memoryStream = null;

            var exception = Assert.Throws<ArgumentNullException>(() => gzipAndCrypt.Write(memoryStream, message));

            Assert.Equal("Stream cannot be Null! (Parameter 'stream')", exception.Message);
        }

        [Fact]
        public void CheckForWriteWhenEncryptIsFalseShouldReturnTrue()
        {
            GzipAndCrypt gzipAndCrypt = new GzipAndCrypt();
            MemoryStream memoryStream = new MemoryStream();
            gzipAndCrypt.Write(memoryStream, "testData");

            Assert.NotEqual("dWZ0dUVidWI", gzipAndCrypt.Read(memoryStream));
        }

        [Fact]
        public void CheckForWriteWhenEncryptIsTrueShouldBeEqual()
        {
            GzipAndCrypt gzipAndCrypt = new GzipAndCrypt();
            MemoryStream memoryStream = new MemoryStream();
            gzipAndCrypt.Write(memoryStream, "testData", true);

            Assert.Equal("dWZ0dUVidWI=", gzipAndCrypt.Read(memoryStream));
        }

        [Fact]
        public void CheckForWriteWhenOnlyCompressIsTrueShouldBeEqual()
        {
            GzipAndCrypt gzipAndCrypt = new GzipAndCrypt();
            MemoryStream memoryStream = new MemoryStream();
            gzipAndCrypt.Write(memoryStream, "testData", false, true);

            Assert.Equal("H4sIAAAAAAAACitJLS5xSSxJBABgmdc5CAAAAA==", gzipAndCrypt.Read(memoryStream));
        }

        [Fact]
        public void CheckForWriteWhenEncryptAndCompressAreTrueShouldBeEqual()
        {
            GzipAndCrypt gzipAndCrypt = new GzipAndCrypt();
            MemoryStream memoryStream = new MemoryStream();
            gzipAndCrypt.Write(memoryStream, "testData", true, true);

            Assert.Equal("H4sIAAAAAAAACksJjzJICQ3LTAn3tAUAV/neTgwAAAA=", gzipAndCrypt.Read(memoryStream));
        }

        [Fact]
        public void CheckForReadWhenEncryptIsTrue()
        {
            string message = "dWZ0dUVidWI=";

            GzipAndCrypt gzipAndCrypt = new GzipAndCrypt();
            MemoryStream memoryStream = new MemoryStream();
            gzipAndCrypt.Write(memoryStream, message, false, false);

            string readData = gzipAndCrypt.Read(memoryStream, true);

            Assert.Equal("testData", readData);
        }

        [Fact]
        public void CheckForReadWhenCompressIsTrue()
        {
            string message = "H4sIAAAAAAAACitJLS5xSSxJBABgmdc5CAAAAA==";

            GzipAndCrypt gzipAndCrypt= new GzipAndCrypt();
            MemoryStream memoryStream = new MemoryStream();
            gzipAndCrypt.Write(memoryStream, message, false, false);

            string readData = gzipAndCrypt.Read(memoryStream, false, true);

            Assert.Equal("testData", readData);
        }

        [Fact]
        public void CheckForWhenTextIsBothEncryptedAndCompressed()
        {
            string message = "testData";

            GzipAndCrypt gzipAndCrypt = new GzipAndCrypt();
            MemoryStream memoryStream = new MemoryStream();
            gzipAndCrypt.Write(memoryStream, message, true, true);

            string readData = gzipAndCrypt.Read(memoryStream, true, true);

            Assert.Equal("testData", readData);
        }
    }
}