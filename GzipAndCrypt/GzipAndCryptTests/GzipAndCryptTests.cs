using System;
using System.IO;
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
    }
}